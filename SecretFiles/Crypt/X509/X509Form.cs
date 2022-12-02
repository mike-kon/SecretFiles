using SecretFiles.Crypt.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretFiles.Crypt.X509
{
    [WinReester(ReistryHKEY.HKEY_CURRENTUSER, @"SOFTWARE\mikesoft\SecretFiles\X509Form")]
    public partial class X509Form : Form
    {
        private class X509TypeItem
        {
            public X509ContentType Type { get; set; }
            public string Name { get; set; }
        }

        private readonly X509TypeItem[] X509TypeItemList =
        {
            new X509TypeItem {Type = X509ContentType.Cert, Name ="Cert"},
            new X509TypeItem {Type = X509ContentType.SerializedCert, Name ="SerializedCert"},
            new X509TypeItem {Type = X509ContentType.Pfx, Name ="Pfx"},
            new X509TypeItem {Type = X509ContentType.Pkcs12, Name ="Pkcs12"},
            new X509TypeItem {Type = X509ContentType.Pkcs7, Name ="Pkcs7"},
            new X509TypeItem {Type = X509ContentType.SerializedStore, Name ="SerializedStore"},
            new X509TypeItem {Type = X509ContentType.Authenticode, Name ="Authenticode"},
        };

        public X509Form()
        {
            InitializeComponent();
            EdCertType.DataSource = X509TypeItemList;
            EdCertType.DisplayMember = "Name";
            EdCertType.ValueMember = "Type";
            WinReestr.Load(this);
        }

        #region Внешние свойства
        [WinReestrField]
        public string CertDir
        {
            get { return EdCertDir.Text; }
            set { EdCertDir.Text = value; }
        }
        [WinReestrField]
        public string Domain
        {
            get { return EdDomain.Text; }
            set { EdDomain.Text = value; }
        }
        [WinReestrField]
        public string Address
        {
            get { return EdAddress.Text; }
            set { EdAddress.Text = value; }
        }
        [WinReestrField]
        public string Password
        {
            get { return EdPassword.Text; }
            set { EdPassword.Text = value; }
        }
        [WinReestrField]
        public DateTime Expired
        {
            get { return EdExpired.Value; }
            set { EdExpired.Value = value; }
        }
        [WinReestrField]
        public X509ContentType CertType
        {
            get { return (X509ContentType)EdCertType.SelectedValue; }
            set { EdCertType.SelectedValue = value; }
        }        
        public string CertFile
        {
            get { return EdCertFile.Text; }
            set { EdCertFile.Text = value; }
        }        
        #endregion

        private void BtnCertDir_Click(object sender, EventArgs e)
        {
            if (DlgCertPath.ShowDialog() == DialogResult.OK)
                EdCertDir.Text = DlgCertPath.SelectedPath;
        }

        private void BtnCertFile_Click(object sender, EventArgs e)
        {
            if (DlgSaveCert.ShowDialog() == DialogResult.OK)
                EdCertFile.Text = DlgSaveCert.FileName;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            WinReestr.Save(this);
        }
    }
}
