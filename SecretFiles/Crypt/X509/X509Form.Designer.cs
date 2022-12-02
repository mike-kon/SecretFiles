namespace SecretFiles.Crypt.X509
{
    partial class X509Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.EdCertDir = new System.Windows.Forms.TextBox();
            this.BtnCertDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EdDomain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EdPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EdCertFile = new System.Windows.Forms.TextBox();
            this.BtnCertFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.EdExpired = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.EdCertType = new System.Windows.Forms.ComboBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.DlgCertPath = new System.Windows.Forms.FolderBrowserDialog();
            this.DlgSaveCert = new System.Windows.Forms.SaveFileDialog();
            this.EdAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Каталог для сертификата";
            // 
            // EdCertDir
            // 
            this.EdCertDir.Location = new System.Drawing.Point(153, 23);
            this.EdCertDir.Name = "EdCertDir";
            this.EdCertDir.Size = new System.Drawing.Size(401, 20);
            this.EdCertDir.TabIndex = 0;
            // 
            // BtnCertDir
            // 
            this.BtnCertDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCertDir.Location = new System.Drawing.Point(560, 21);
            this.BtnCertDir.Name = "BtnCertDir";
            this.BtnCertDir.Size = new System.Drawing.Size(28, 23);
            this.BtnCertDir.TabIndex = 1;
            this.BtnCertDir.Text = "...";
            this.BtnCertDir.UseVisualStyleBackColor = true;
            this.BtnCertDir.Click += new System.EventHandler(this.BtnCertDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Домен";
            // 
            // EdDomain
            // 
            this.EdDomain.Location = new System.Drawing.Point(75, 60);
            this.EdDomain.Name = "EdDomain";
            this.EdDomain.Size = new System.Drawing.Size(155, 20);
            this.EdDomain.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Срок действия до";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пароль";
            // 
            // EdPassword
            // 
            this.EdPassword.Location = new System.Drawing.Point(75, 88);
            this.EdPassword.Name = "EdPassword";
            this.EdPassword.PasswordChar = '*';
            this.EdPassword.Size = new System.Drawing.Size(155, 20);
            this.EdPassword.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Файл сертификата";
            // 
            // EdCertFile
            // 
            this.EdCertFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EdCertFile.Location = new System.Drawing.Point(123, 148);
            this.EdCertFile.Name = "EdCertFile";
            this.EdCertFile.Size = new System.Drawing.Size(431, 20);
            this.EdCertFile.TabIndex = 7;
            // 
            // BtnCertFile
            // 
            this.BtnCertFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCertFile.Location = new System.Drawing.Point(560, 146);
            this.BtnCertFile.Name = "BtnCertFile";
            this.BtnCertFile.Size = new System.Drawing.Size(28, 23);
            this.BtnCertFile.TabIndex = 8;
            this.BtnCertFile.Text = "...";
            this.BtnCertFile.UseVisualStyleBackColor = true;
            this.BtnCertFile.Click += new System.EventHandler(this.BtnCertFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(236, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Сеть";
            // 
            // EdExpired
            // 
            this.EdExpired.Location = new System.Drawing.Point(339, 86);
            this.EdExpired.Name = "EdExpired";
            this.EdExpired.Size = new System.Drawing.Size(140, 20);
            this.EdExpired.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Тип файла";
            // 
            // EdCertType
            // 
            this.EdCertType.FormattingEnabled = true;
            this.EdCertType.Location = new System.Drawing.Point(79, 117);
            this.EdCertType.Name = "EdCertType";
            this.EdCertType.Size = new System.Drawing.Size(121, 21);
            this.EdCertType.TabIndex = 6;
            // 
            // BtnOk
            // 
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Location = new System.Drawing.Point(88, 218);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 9;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(204, 218);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // DlgCertPath
            // 
            this.DlgCertPath.Description = "Путь для файлов сертификата";
            // 
            // DlgSaveCert
            // 
            this.DlgSaveCert.Filter = "все|*.*";
            // 
            // EdAddress
            // 
            this.EdAddress.Location = new System.Drawing.Point(273, 60);
            this.EdAddress.Name = "EdAddress";
            this.EdAddress.Size = new System.Drawing.Size(118, 20);
            this.EdAddress.TabIndex = 3;
            // 
            // X509Form
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(600, 265);
            this.ControlBox = false;
            this.Controls.Add(this.EdAddress);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.EdCertType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EdExpired);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnCertFile);
            this.Controls.Add(this.EdCertFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EdPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EdDomain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCertDir);
            this.Controls.Add(this.EdCertDir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "X509Form";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "X509Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EdCertDir;
        private System.Windows.Forms.Button BtnCertDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EdDomain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EdPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EdCertFile;
        private System.Windows.Forms.Button BtnCertFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker EdExpired;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox EdCertType;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.FolderBrowserDialog DlgCertPath;
        private System.Windows.Forms.SaveFileDialog DlgSaveCert;
        private System.Windows.Forms.TextBox EdAddress;
    }
}