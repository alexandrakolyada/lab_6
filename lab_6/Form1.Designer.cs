namespace lab_6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSaveKeys = new System.Windows.Forms.Button();
            this.btnGenerateKeys = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecryptFile = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEncryptFile = new System.Windows.Forms.Button();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblPublicKey = new System.Windows.Forms.Label();
            this.вса = new System.Windows.Forms.Label();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveKeys
            // 
            this.btnSaveKeys.Location = new System.Drawing.Point(404, 250);
            this.btnSaveKeys.Name = "btnSaveKeys";
            this.btnSaveKeys.Size = new System.Drawing.Size(182, 23);
            this.btnSaveKeys.TabIndex = 0;
            this.btnSaveKeys.Text = "Зберегти ключі";
            this.btnSaveKeys.UseVisualStyleBackColor = true;
            this.btnSaveKeys.Click += new System.EventHandler(this.btnSaveKeys_Click);
            // 
            // btnGenerateKeys
            // 
            this.btnGenerateKeys.Location = new System.Drawing.Point(404, 221);
            this.btnGenerateKeys.Name = "btnGenerateKeys";
            this.btnGenerateKeys.Size = new System.Drawing.Size(182, 23);
            this.btnGenerateKeys.TabIndex = 1;
            this.btnGenerateKeys.Text = "Генерувати ключі";
            this.btnGenerateKeys.UseVisualStyleBackColor = true;
            this.btnGenerateKeys.Click += new System.EventHandler(this.btnGenerateKeys_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(404, 279);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Вихід";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(403, 58);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(183, 23);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Зашифрувати текст";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecryptFile
            // 
            this.btnDecryptFile.Location = new System.Drawing.Point(404, 164);
            this.btnDecryptFile.Name = "btnDecryptFile";
            this.btnDecryptFile.Size = new System.Drawing.Size(182, 23);
            this.btnDecryptFile.TabIndex = 4;
            this.btnDecryptFile.Text = "Розшифрувати файл";
            this.btnDecryptFile.UseVisualStyleBackColor = true;
            this.btnDecryptFile.Click += new System.EventHandler(this.btnDecryptFile_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(403, 87);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(183, 23);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "Розшифрувати текст";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(486, 279);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Очистити";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnEncryptFile
            // 
            this.btnEncryptFile.Location = new System.Drawing.Point(403, 132);
            this.btnEncryptFile.Name = "btnEncryptFile";
            this.btnEncryptFile.Size = new System.Drawing.Size(183, 23);
            this.btnEncryptFile.TabIndex = 7;
            this.btnEncryptFile.Text = "Зашифрувати файл";
            this.btnEncryptFile.UseVisualStyleBackColor = true;
            this.btnEncryptFile.Click += new System.EventHandler(this.btnEncryptFile_Click);
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Location = new System.Drawing.Point(28, 48);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPublicKey.Size = new System.Drawing.Size(350, 62);
            this.txtPublicKey.TabIndex = 8;
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Location = new System.Drawing.Point(28, 132);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrivateKey.Size = new System.Drawing.Size(350, 55);
            this.txtPrivateKey.TabIndex = 9;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(31, 209);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(347, 85);
            this.txtMessage.TabIndex = 10;
            // 
            // lblPublicKey
            // 
            this.lblPublicKey.AutoSize = true;
            this.lblPublicKey.Location = new System.Drawing.Point(25, 29);
            this.lblPublicKey.Name = "lblPublicKey";
            this.lblPublicKey.Size = new System.Drawing.Size(144, 16);
            this.lblPublicKey.TabIndex = 11;
            this.lblPublicKey.Text = "Відкритий ключ (e, n):";
            // 
            // вса
            // 
            this.вса.AutoSize = true;
            this.вса.Location = new System.Drawing.Point(28, 190);
            this.вса.Name = "вса";
            this.вса.Size = new System.Drawing.Size(179, 16);
            this.вса.TabIndex = 12;
            this.вса.Text = "Повідомлення/результат: ";
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.AutoSize = true;
            this.lblPrivateKey.Location = new System.Drawing.Point(28, 113);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(141, 16);
            this.lblPrivateKey.TabIndex = 13;
            this.lblPrivateKey.Text = "Закритий ключ (d, n):";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(28, 315);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(163, 16);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Статус: очікування дій...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPrivateKey);
            this.Controls.Add(this.вса);
            this.Controls.Add(this.lblPublicKey);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtPrivateKey);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.btnEncryptFile);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnDecryptFile);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGenerateKeys);
            this.Controls.Add(this.btnSaveKeys);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveKeys;
        private System.Windows.Forms.Button btnGenerateKeys;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecryptFile;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblPublicKey;
        private System.Windows.Forms.Label вса;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.Label lblStatus;
    }
}

