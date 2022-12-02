using SecretFiles.Crypt.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretFiles
{
    [WinReester(ReistryHKEY.HKEY_CURRENTUSER, @"SOFTWARE\mikesoft\SecretFiles\MainForm")]
    public partial class MainForm : Form
    {
        const string ResFileDir = "Result";
        public MainForm()
        {
            InitializeComponent();
            WinReestr.Load(this);
        }

        #region Properties
        [WinReestrField]
        public string Method
        {
            get { return EdMethod.Text; }
            set { EdMethod.Text = value; }
        }
        [WinReestrField]
        public string CertPath
        {
            get { return EdCertificate.Text; }
            set { EdCertificate.Text = value; }
        }
        [WinReestrField]
        public string SertPass
        {
            get { return EdPassword.Text; }
            set { EdPassword.Text = value; }
        }
        [WinReestrField]
        public string FilePath
        {
            get { return EdFileName.Text; }
            set { EdFileName.Text = value; }
        }

        #endregion

        #region VisualEvents
        private void BtnKeyGen_Click_1(object sender, EventArgs e)
        {
            try
            {
                GenerateKeys();
                WinReestr.Save(this);
            }
            catch (Exception ex)
            {
                HandlerException(ex);
            }
        }

        private void BtnCryptPub_Click(object sender, EventArgs e)
        {
            try
            {
                Application.UseWaitCursor = true;
                string sourcefilename = EdFileName.Text;
                if (string.IsNullOrWhiteSpace(sourcefilename))
                    return;
                string cryptfilename = $@"{sourcefilename}.crypt";
                if (!File.Exists(sourcefilename))
                {
                    MessageBox.Show(this, $"Файл {sourcefilename} не существует", "OS.IO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (File.Exists(cryptfilename))
                {
                    if (MessageBox.Show(this, $"Файл {cryptfilename} существует. Переписать?", "OS.IO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
                WinReestr.Save(this);
                Encrypt(sourcefilename, cryptfilename);
                EdFileName.Text = string.Empty;
                MessageBox.Show(this, "Шифрование завершено", "complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HandlerException(ex);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void BtnDecryptSecret_Click(object sender, EventArgs e)
        {
            try
            {
                Application.UseWaitCursor = true;
                string cryptfilename = EdFileName.Text;
                string destfilename = $@"{Path.GetDirectoryName(cryptfilename)}\{Path.GetFileNameWithoutExtension(cryptfilename)}";
                if (!File.Exists(cryptfilename))
                {
                    MessageBox.Show(this, $"Файл {cryptfilename} не существует", "OS.IO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (File.Exists(destfilename))
                {
                    if (MessageBox.Show(this, $"Файл {destfilename} существует. Переписать?", "OS.IO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
                WinReestr.Save(this);
                Decrypt(cryptfilename, destfilename);
                MessageBox.Show(this, "Дешифрование завершено", "complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HandlerException(ex);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Все файлы|*.*",
                Multiselect = false,
                Title = "Выберите файл"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                EdFileName.Text = dlg.FileName;
        }

        private void BtnCert_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Все файлы|*.*",
                Multiselect = false,
                Title = "Выберите файл"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                EdCertificate.Text = dlg.FileName;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WinReestr.Save(this);
        }

        #endregion

        #region Switchers
        private void GenerateKeys()
        {
            IGenerateKeys generator = null;
            switch (EdMethod.Text)
            {
                case "X509Certificate2":
                    generator = new X509Generate();
                    break;
                default:
                    throw new ApplicationException($"Неизвестный тип {EdMethod.Text}");
            }
            if (generator.GenerateForm.ShowDialog(this) == DialogResult.OK)
            {
                generator.GenerateKeys();
                WriteLog("Сертификаты созданы");
                MessageBox.Show(this, "Сертификаты созданы", "complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Encrypt(string source, string crypt)
        {
            IWorkSecretFile workSecret = null;
            switch (EdMethod.Text)
            {
                case "X509Certificate2":
                    workSecret = GetX509();
                    break;
            }
            workSecret.Crypt(source, crypt);
        }

        private void Decrypt(string crypt, string dest)
        {
            IWorkSecretFile workSecret = null;
            switch (EdMethod.Text)
            {
                case "X509Certificate2":
                    workSecret = GetX509();
                    break;
            }
            workSecret.Decrypt(crypt, dest);
        }
        #endregion

        #region Worker
        private IWorkSecretFile GetX509()
        {
            return new X509WorkSecret(EdCertificate.Text, EdPassword.Text);
        }
        #endregion

        private void HandlerException(Exception ex)
        {
            var str = new StringBuilder(EdLog.Text);
            str.AppendLine($"{DateTime.Now}: Exception");
            while (ex != null)
            {
                str.AppendLine(ex.Message);
                ex = ex.InnerException;
            }
            EdLog.Text = str.ToString();
        }

        private void WriteLog(string mes)
        {
            var str = new StringBuilder(EdLog.Text);
            str.AppendLine($"{DateTime.Now}:{mes}");
            EdLog.Text = str.ToString();
        }

    }
}
