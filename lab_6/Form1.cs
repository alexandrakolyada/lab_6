using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Numerics;

namespace lab_6
{
    public partial class Form1 : Form
    {
        private BigInteger n, e, d;
        private bool keysGenerated = false;
        private readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private readonly int keySize = 1024; // Розмір ключа в бітах

        public Form1()
        {
            InitializeComponent();
            ConfigureUI();
        }

        private void ConfigureUI()
        {
            this.Text = "Асиметричне шифрування RSA (1024-біт)";
            btnClear.Text = "Очистити";
            btnExit.Text = "Вихід";
            btnGenerateKeys.Text = "Генерувати ключі";
            btnSaveKeys.Text = "Зберегти ключі";
            btnEncrypt.Text = "Зашифрувати текст";
            btnDecrypt.Text = "Розшифрувати текст";
            btnEncryptFile.Text = "Зашифрувати файл";
            btnDecryptFile.Text = "Розшифрувати файл";
            lblStatus.Text = "Статус: очікування генерації ключів";
            lblPublicKey.Text = "Відкритий ключ (e, n):";
            lblPrivateKey.Text = "Закритий ключ (d, n):";
        }

        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            var sw = Stopwatch.StartNew();

            BigInteger p = GenerateLargePrime(keySize / 2);
            BigInteger q = GenerateLargePrime(keySize / 2);

            n = p * q;
            BigInteger phi = (p - 1) * (q - 1);
            this.e = 65537; // Використовуємо поле класу, а не параметр події
            d = ModInverse(this.e, phi);

            sw.Stop();

            txtPublicKey.Text = $"e: {this.e}\nn: {n}";
            txtPrivateKey.Text = $"d: {d}\nn: {n}";
            keysGenerated = true;

            lblStatus.Text = $"Статус: ключі згенеровані за {sw.ElapsedMilliseconds} мс";
            MessageBox.Show($"1024-бітні ключі успішно згенеровані!\nЧас генерації: {sw.ElapsedMilliseconds} мс",
                "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private BigInteger GenerateLargePrime(int bits)
        {
            BigInteger number;
            do
            {
                number = GenerateRandomBigInteger(bits);
            } while (!IsProbablePrime(number, 10));

            return number;
        }

        private BigInteger GenerateRandomBigInteger(int bits)
        {
            byte[] bytes = new byte[bits / 8];
            rng.GetBytes(bytes);
            bytes[bytes.Length - 1] &= 0x7F;
            return new BigInteger(bytes);
        }

        private bool IsProbablePrime(BigInteger n, int k)
        {
            if (n == 2 || n == 3) return true;
            if (n < 2 || n % 2 == 0) return false;

            BigInteger d = n - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s++;
            }

            for (int i = 0; i < k; i++)
            {
                byte[] bytes = new byte[n.ToByteArray().Length];
                BigInteger a;
                do
                {
                    rng.GetBytes(bytes);
                    a = new BigInteger(bytes);
                } while (a < 2 || a >= n - 2);

                BigInteger x = BigInteger.ModPow(a, d, n);
                if (x == 1 || x == n - 1) continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == 1) return false;
                    if (x == n - 1) break;
                }

                if (x != n - 1) return false;
            }

            return true;
        }

        private BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m;
            BigInteger y = 0, x = 1;

            if (m == 1) return 0;

            while (a > 1)
            {
                BigInteger q = a / m;
                BigInteger t = m;

                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0) x += m0;

            return x;
        }

        private void btnEncrypt_Click(object sender, EventArgs eventArgs)
        {
            if (!keysGenerated)
            {
                MessageBox.Show("Спочатку згенеруйте ключі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Введіть текст для шифрування!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var sw = Stopwatch.StartNew();
                string plainText = txtMessage.Text;
                byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                int blockSize = (keySize / 8) - 12;

                using (MemoryStream ms = new MemoryStream())
                {
                    for (int i = 0; i < bytes.Length; i += blockSize)
                    {
                        int length = Math.Min(blockSize, bytes.Length - i);
                        byte[] block = new byte[length];
                        Array.Copy(bytes, i, block, 0, length);

                        BigInteger m = new BigInteger(block);
                        if (m >= n)
                        {
                            MessageBox.Show("Помилка: дані занадто великі для обраного ключа", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        BigInteger c = BigInteger.ModPow(m, e, n);
                        byte[] encryptedBlock = c.ToByteArray();
                        ms.Write(BitConverter.GetBytes(encryptedBlock.Length), 0, 4);
                        ms.Write(encryptedBlock, 0, encryptedBlock.Length);
                    }

                    txtMessage.Text = Convert.ToBase64String(ms.ToArray());
                    sw.Stop();
                    lblStatus.Text = $"Статус: текст зашифровано за {sw.ElapsedMilliseconds} мс";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при шифруванні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs eventArgs)
        {
            if (!keysGenerated)
            {
                MessageBox.Show("Спочатку згенеруйте ключі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Введіть зашифрований текст!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var sw = Stopwatch.StartNew();
                byte[] encryptedData = Convert.FromBase64String(txtMessage.Text);

                using (MemoryStream ms = new MemoryStream(encryptedData))
                using (MemoryStream result = new MemoryStream())
                {
                    byte[] lengthBytes = new byte[4];

                    while (ms.Position < ms.Length)
                    {
                        ms.Read(lengthBytes, 0, 4);
                        int blockLength = BitConverter.ToInt32(lengthBytes, 0);
                        byte[] encryptedBlock = new byte[blockLength];
                        ms.Read(encryptedBlock, 0, blockLength);

                        BigInteger c = new BigInteger(encryptedBlock);
                        BigInteger m = BigInteger.ModPow(c, d, n);
                        byte[] decryptedBlock = m.ToByteArray();

                        result.Write(decryptedBlock, 0, decryptedBlock.Length);
                    }

                    txtMessage.Text = Encoding.UTF8.GetString(result.ToArray());
                    sw.Stop();
                    lblStatus.Text = $"Статус: текст розшифровано за {sw.ElapsedMilliseconds} мс";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при дешифруванні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            if (!keysGenerated)
            {
                MessageBox.Show("Спочатку згенеруйте ключі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Зашифровані файли (*.rsa)|*.rsa";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sw = Stopwatch.StartNew();
                        byte[] fileData = File.ReadAllBytes(openFileDialog.FileName);
                        int blockSize = (keySize / 8) - 12;

                        using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            for (int i = 0; i < fileData.Length; i += blockSize)
                            {
                                int length = Math.Min(blockSize, fileData.Length - i);
                                byte[] block = new byte[length];
                                Array.Copy(fileData, i, block, 0, length);

                                BigInteger m = new BigInteger(block);
                                if (m >= n)
                                {
                                    MessageBox.Show("Помилка: файл занадто великий для обраного ключа", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                BigInteger c = BigInteger.ModPow(m, this.e, n);
                                byte[] encryptedBlock = c.ToByteArray();
                                fs.Write(BitConverter.GetBytes(encryptedBlock.Length), 0, 4);
                                fs.Write(encryptedBlock, 0, encryptedBlock.Length);
                            }
                        }

                        sw.Stop();
                        lblStatus.Text = $"Статус: файл зашифровано за {sw.ElapsedMilliseconds} мс";
                        MessageBox.Show($"Файл успішно зашифровано!\nЧас шифрування: {sw.ElapsedMilliseconds} мс",
                            "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при шифруванні файлу: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            if (!keysGenerated)
            {
                MessageBox.Show("Спочатку згенеруйте ключі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Зашифровані файли (*.rsa)|*.rsa";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sw = Stopwatch.StartNew();
                        using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                        using (FileStream result = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            byte[] lengthBytes = new byte[4];

                            while (fs.Position < fs.Length)
                            {
                                fs.Read(lengthBytes, 0, 4);
                                int blockLength = BitConverter.ToInt32(lengthBytes, 0);
                                byte[] encryptedBlock = new byte[blockLength];
                                fs.Read(encryptedBlock, 0, blockLength);

                                BigInteger c = new BigInteger(encryptedBlock);
                                BigInteger m = BigInteger.ModPow(c, this.d, n);
                                byte[] decryptedBlock = m.ToByteArray();

                                result.Write(decryptedBlock, 0, decryptedBlock.Length);
                            }
                        }

                        sw.Stop();
                        lblStatus.Text = $"Статус: файл розшифровано за {sw.ElapsedMilliseconds} мс";
                        MessageBox.Show($"Файл успішно розшифровано!\nЧас дешифрування: {sw.ElapsedMilliseconds} мс",
                            "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при дешифруванні файлу: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSaveKeys_Click(object sender, EventArgs e)
        {
            if (!keysGenerated)
            {
                MessageBox.Show("Спочатку згенеруйте ключі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName,
                        $"Відкритий ключ (e, n):\n{this.e}\n{n}\n\nЗакритий ключ (d, n):\n{d}\n{n}");
                    MessageBox.Show("Ключі успішно збережено!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні ключів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMessage.Clear();
            lblStatus.Text = "Статус: поля очищено";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
