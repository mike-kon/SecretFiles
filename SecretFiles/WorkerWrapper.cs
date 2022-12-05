using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretFiles
{
    public static class WorkerWrapper
    {
        public static void Encrypt(IWorkSecretFile workSecret, string source, string crypt)
        {
            workSecret.Crypt(source, crypt);
        }

        public static void Decrypt(IWorkSecretFile workSecret, string crypt, string dest)
        {
            workSecret.Decrypt(crypt, dest);
        }

        public static bool GenerateKeys(IGenerateKeys generator, IWin32Window owner = null)
        {
            if (generator.GenerateForm.ShowDialog(owner) == DialogResult.OK)
            {
                generator.GenerateKeys();
                return true;
            }
            return false;
        }

        public static void ExportPublicKey(IAsyncKey workSecret, string path)
        {
            workSecret.ExportPublikey(path);
        }
    }
}
