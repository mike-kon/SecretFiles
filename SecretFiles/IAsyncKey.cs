using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretFiles
{
    public interface IAsyncKey
    {
        void ExportPublikey(string path);
        void ExportRequestSign(string path);
        void InportResponceSign(string path);
    }
}
