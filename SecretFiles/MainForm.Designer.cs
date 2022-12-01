namespace SecretFiles
{
    partial class MainForm
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
            this.BtnKeyGen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.EdFileName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCryptPub = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnCryptSecret = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.EdLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnKeyGen
            // 
            this.BtnKeyGen.Location = new System.Drawing.Point(13, 12);
            this.BtnKeyGen.Name = "BtnKeyGen";
            this.BtnKeyGen.Size = new System.Drawing.Size(206, 23);
            this.BtnKeyGen.TabIndex = 0;
            this.BtnKeyGen.Text = "Сгенерировать пару secret/pub";
            this.BtnKeyGen.UseVisualStyleBackColor = true;
            this.BtnKeyGen.Click += new System.EventHandler(this.BtnKeyGen_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnOpenFile);
            this.groupBox1.Controls.Add(this.EdFileName);
            this.groupBox1.Location = new System.Drawing.Point(13, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOpenFile.Location = new System.Drawing.Point(455, 17);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(28, 23);
            this.BtnOpenFile.TabIndex = 1;
            this.BtnOpenFile.Text = "...";
            this.BtnOpenFile.UseVisualStyleBackColor = true;
            this.BtnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // EdFileName
            // 
            this.EdFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EdFileName.Location = new System.Drawing.Point(7, 20);
            this.EdFileName.Name = "EdFileName";
            this.EdFileName.Size = new System.Drawing.Size(442, 20);
            this.EdFileName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BtnCryptPub);
            this.groupBox2.Location = new System.Drawing.Point(13, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 68);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шифрование";
            // 
            // BtnCryptPub
            // 
            this.BtnCryptPub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCryptPub.Location = new System.Drawing.Point(7, 26);
            this.BtnCryptPub.Name = "BtnCryptPub";
            this.BtnCryptPub.Size = new System.Drawing.Size(475, 23);
            this.BtnCryptPub.TabIndex = 0;
            this.BtnCryptPub.Text = "Зашифровать";
            this.BtnCryptPub.UseVisualStyleBackColor = true;
            this.BtnCryptPub.Click += new System.EventHandler(this.BtnCryptPub_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.BtnCryptSecret);
            this.groupBox3.Location = new System.Drawing.Point(17, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 58);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дешифрация";
            // 
            // BtnCryptSecret
            // 
            this.BtnCryptSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCryptSecret.Location = new System.Drawing.Point(6, 19);
            this.BtnCryptSecret.Name = "BtnCryptSecret";
            this.BtnCryptSecret.Size = new System.Drawing.Size(472, 23);
            this.BtnCryptSecret.TabIndex = 0;
            this.BtnCryptSecret.Text = "Дешифровать";
            this.BtnCryptSecret.UseVisualStyleBackColor = true;
            this.BtnCryptSecret.Click += new System.EventHandler(this.BtnCryptSecret_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.EdLog);
            this.groupBox4.Location = new System.Drawing.Point(13, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(489, 138);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Лог";
            // 
            // EdLog
            // 
            this.EdLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EdLog.Location = new System.Drawing.Point(3, 16);
            this.EdLog.Multiline = true;
            this.EdLog.Name = "EdLog";
            this.EdLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EdLog.Size = new System.Drawing.Size(483, 119);
            this.EdLog.TabIndex = 0;
            this.EdLog.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 418);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnKeyGen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ассинхронный ключ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnKeyGen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnOpenFile;
        private System.Windows.Forms.TextBox EdFileName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCryptPub;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnCryptSecret;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox EdLog;
    }
}

