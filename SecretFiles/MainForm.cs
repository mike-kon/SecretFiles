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
    public partial class MainForm : Form
    {
        const string CryptFileDir = "Crypt";
        const string ResFileDir = "Result";
        public MainForm()
        {
            InitializeComponent();
            if (!Directory.Exists(CryptFileDir))
                Directory.CreateDirectory(CryptFileDir);
            if (!Directory.Exists(ResFileDir))
                Directory.CreateDirectory(ResFileDir);
            EdFileName.Text = @"C:\mikesoft\projects\SecretFiles\SecretFiles\bin\Debug\Test\Общий план.pdf";
        }

        private async void BtnKeyGen_Click_1(object sender, EventArgs e)
        {
            try
            {
                Application.UseWaitCursor = true;
                await Task.Run(() => WorkSecret.GenerateKeys());
                WriteLog("Сертификаты созданы");
                MessageBox.Show(this, "Сертификаты созданы", "complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void BtnCryptPub_Click(object sender, EventArgs e)
        {
            try
            {
                Application.UseWaitCursor = true;
                var work = new WorkSecret();
                string sourcefilename = EdFileName.Text;
                if (string.IsNullOrWhiteSpace(sourcefilename))
                    return;
                string cryptfilename = $@"{CryptFileDir}\{Path.GetFileName(sourcefilename)}.crypt";
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
                //            var sourcestream = new FileStream(sourcefilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                //            var cryptstream = new FileStream(cryptfilename, FileMode.Create, FileAccess.Write, FileShare.Write);
                work.Crypt(sourcefilename, cryptfilename);

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

        private void BtnCryptSecret_Click(object sender, EventArgs e)
        {
            try
            {
                Application.UseWaitCursor = true;
                var work = new WorkSecret();
                string cryptfilename = EdFileName.Text;
                string destfilename = $@"{ResFileDir}\{Path.GetFileNameWithoutExtension(cryptfilename)}";
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
                var cryptstream = new FileStream(cryptfilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                var deststraem = new FileStream(destfilename, FileMode.Create, FileAccess.Write, FileShare.Write);
                work.Derypt(cryptstream, deststraem);
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
                Filter = "Все файлы|*.*|Зашифрованные файлы|*.crypt",
                Multiselect = false,
                Title = "Выберите файл"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                EdFileName.Text = dlg.FileName;
        }

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
