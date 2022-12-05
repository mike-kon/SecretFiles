using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SecretFiles.Crypt.X509
{
    public class X509WorkSecret : WorkSecret, IAsyncKey
    {
        private X509Certificate2 Certificate;


        public X509WorkSecret(string certpath, string password)
        {
            try
            {
                Certificate = new X509Certificate2(certpath, password);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Не могу инициировать модуль шифрации / дешифрации", ex);
            }
        }

        const int cryptbuffsize = 245;
        const int decryptbuffsize = 256;

        public override void Crypt(Stream readStream, Stream cryptStream)
        {
            if (!readStream.CanRead)
                throw new ApplicationException($"Поток не предназначен для чтения");
            if (!cryptStream.CanWrite)
                throw new ApplicationException($"Поток не предназначен для записи");
            var publicKey = Certificate.GetRSAPublicKey();
            while (true)
            {
                byte[] buff = new byte[cryptbuffsize];
                byte[] data;
                var readeddata = readStream.Read(buff, 0, cryptbuffsize);
                if (readeddata == 0)
                    break;
                if (readeddata < cryptbuffsize)
                {
                    data = new byte[readeddata];
                    Array.Copy(buff, data, readeddata);
                }
                else
                    data = buff;
                var cryptdata = publicKey.Encrypt(data, RSAEncryptionPadding.Pkcs1);
                cryptStream.Write(cryptdata, 0, cryptdata.Length);

            }
            cryptStream.Flush();
        }

        public override void Decrypt(Stream cryptStream, Stream destStream)
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
            destStream.Flush();
        }

        public void ExportPublikey(string path)
        {
            var builder = new StringBuilder();
            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(Certificate.RawData, Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END CERTIFICATE-----");
            File.WriteAllText(path, builder.ToString());
        }

        /// <summary>
        /// У самоподписанного сертификата это не реализовано
        /// </summary>
        /// <param name="path"></param>
        public void ExportRequestSign(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// У самоподписанного сертификата это не реализовано
        /// </summary>
        /// <param name="path"></param>
        public void InportResponceSign(string path)
        {
            throw new NotImplementedException();
        }
    }
}
