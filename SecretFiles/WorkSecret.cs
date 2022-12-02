using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretFiles
{
    public abstract class WorkSecret : IWorkSecretStream, IWorkSecretFile
    {

        public void Crypt(string sourceFile, string cryptFile)
        {
            using (var ReadStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (var CryptStream = new FileStream(cryptFile, FileMode.Create, FileAccess.Write))
            {
                Crypt(ReadStream, CryptStream);
                ReadStream.Close();
                CryptStream.Close();
            }
        }

        public abstract void Crypt(Stream cryptStream, Stream destStream);

        public void Decrypt(string cryptFile, string destFile)
        {
            using (var CryptStream = new FileStream(cryptFile, FileMode.Open, FileAccess.Read))
            using (var DestStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                Decrypt(CryptStream, DestStream);
                CryptStream.Close();
                DestStream.Close();
            }
        }

        public abstract void Decrypt(Stream cryptStream, Stream destStream);
    }
}
