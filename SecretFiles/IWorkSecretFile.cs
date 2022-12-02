using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretFiles
{
    public interface IWorkSecretFile
    {
        void Crypt(string source, string crypt);
        void Decrypt(string crypt, string dest);
    }
}
