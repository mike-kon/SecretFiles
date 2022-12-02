using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretFiles
{
    public interface IGenerateKeys
    {
        Form GenerateForm { get; }
        void GenerateKeys();
    }
}
