using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretFiles.Crypt.X509
{
    public class X509Generate : IGenerateKeys
    {
        private X509Form _From;
        public Form GenerateForm => _From;
        
        public string CertDir => _From.CertDir;
        public string Domain => _From.Domain;
        public DateTime Expirate => _From.Expired;
        public string Address => _From.Address;
        public string CertFile => _From.CertFile;
        public string Password => _From.Password;
        public X509ContentType CertType => _From.CertType;

        public X509Generate()
        {
            _From = new X509Form();
        }

        public void GenerateKeys()
        {
            // Каталог для сертификатов
            if (!Directory.Exists(CertDir))
                Directory.CreateDirectory(CertDir);

            // Корневой самоподписанный сертификат
            var caKey = RSA.Create(2048);
            var certReq = new CertificateRequest(Domain, caKey, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            certReq.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
            certReq.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(certReq.PublicKey, false));

            var caCert = certReq.CreateSelfSigned(DateTime.Now, Expirate);
            //Клиентский сертификат
            var clientKey = RSA.Create(2048);
            var clientReq = new CertificateRequest(Address, clientKey, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            clientReq.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));
            clientReq.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation, false));
            clientReq.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(clientReq.PublicKey, false));

            byte[] serialNumber = BitConverter.GetBytes(DateTime.Now.ToBinary());
            var clientCert = clientReq.Create(caCert, DateTimeOffset.Now, Expirate, serialNumber);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(clientCert.RawData, Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END CERTIFICATE-----");
            File.WriteAllText($@"{CertDir}\{CertFile}.crt", builder.ToString());


            var exportCert = new X509Certificate2(clientCert.Export(X509ContentType.Cert), (string)null, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet).CopyWithPrivateKey(clientKey);
            File.WriteAllBytes($@"{CertDir}\{CertFile}.{CertType.ToString()}", exportCert.Export(CertType,Password));
        }
    }
}
