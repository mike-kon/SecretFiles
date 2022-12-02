using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretFiles
{
    public interface IWorkSecretStream
    {
        void Crypt(Stream cryptStream, Stream destStream);
        void Decrypt(Stream cryptStream, Stream destStream);
    }
}
