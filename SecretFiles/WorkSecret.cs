using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SecretFiles
{
    public class WorkSecret
    {
        public const string PubFileName = "public.crt";
        public const string PfxFileName = "client.pfx";
        public const string P12FileName = "client.p12";
        public const string CertDir = "Cert";

        private X509Certificate2 Certificate;

        public WorkSecret()
        {
            try
            {
                Certificate = new X509Certificate2($@"{CertDir}\{P12FileName}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Не могу инициировать модуль шифрации / дешифрации", ex);
            }
        }

        public static void GenerateKeys()
        {
            // Каталог для сертификатов
            if (!Directory.Exists(CertDir))
                Directory.CreateDirectory(CertDir);

            // Корневой самоподписанный сертификат
            var caKey = RSA.Create(2048);
            string subject = "CN=mikekon.ru";
            var certReq = new CertificateRequest(subject, caKey, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            certReq.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
            certReq.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(certReq.PublicKey, false));
            // Все сертификаты создаем только на час...
            var expirate = DateTime.Now.AddHours(1);
            var caCert = certReq.CreateSelfSigned(DateTime.Now, expirate);

            //Клиентский сертификат
            var clientKey = RSA.Create(2048);
            subject = "CN=192.168.25.*";
            var clientReq = new CertificateRequest(subject, clientKey, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            clientReq.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));
            clientReq.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation, false));
            clientReq.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(clientReq.PublicKey, false));

            byte[] serialNumber = BitConverter.GetBytes(DateTime.Now.ToBinary());
            var clientCert = clientReq.Create(caCert, DateTimeOffset.Now, expirate, serialNumber);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(clientCert.RawData, Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END CERTIFICATE-----");
            File.WriteAllText($@"{CertDir}\{PubFileName}", builder.ToString());


            var exportCert = new X509Certificate2(clientCert.Export(X509ContentType.Cert), (string)null, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet).CopyWithPrivateKey(clientKey);
            File.WriteAllBytes($@"{CertDir}\{PfxFileName}", exportCert.Export(X509ContentType.Pfx));
            File.WriteAllBytes($@"{CertDir}\{P12FileName}", exportCert.Export(X509ContentType.Pkcs12));
        }

        const int cryptbuffsize =  245;
        const int decryptbuffsize = 256;

        public void Crypt(string source, string crypt)
        {
            var publicKey = Certificate.GetRSAPublicKey();
            using (var ReadFile = new FileStream(source, FileMode.Open, FileAccess.Read))
            using (var CryptStream = new FileStream(crypt, FileMode.Create, FileAccess.Write))
            {
                while (true)
                {
                    byte[] buff = new byte[cryptbuffsize];
                    byte[] data;
                    var readeddata = ReadFile.Read(buff, 0, cryptbuffsize);
                    if (readeddata == 0)
                        break;
                    if (readeddata < cryptbuffsize)
                    {
                        data = new byte[readeddata];
                        Array.Copy(buff,data, readeddata);
                    }
                    else
                        data = buff;                            
                    var cryptdata = publicKey.Encrypt(data, RSAEncryptionPadding.Pkcs1);
                    CryptStream.Write(cryptdata, 0, cryptdata.Length);
                    
                }
                ReadFile.Close();
                CryptStream.Flush();
                CryptStream.Close();
            }
        }

        public  void Derypt(Stream cryptStream, Stream destStream)
        {
            var privateKey = Certificate.GetRSAPrivateKey();
            byte[] cryptdata = new byte[decryptbuffsize];
            byte[] data;

            if (!cryptStream.CanRead)
                throw new ApplicationException($"Поток не предназначен для чтения");
            if (!destStream.CanWrite)
                throw new ApplicationException($"Поток не предназначен для записи");

            while (true)
            {
                var n = cryptStream.Read(cryptdata, 0, cryptdata.Length);
                if (n == 0)
                    break;
                data = privateKey.Decrypt(cryptdata, RSAEncryptionPadding.Pkcs1);
                destStream.Write(data, 0, data.Length);
            }
            cryptStream.Close();
            destStream.Flush();
            destStream.Close();
        }
    }
}
