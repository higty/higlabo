using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class SqlScriptFileGeneratedEventArgs : EventArgs
    {
        public String FilePath { get; private set; }
        public DateTime ExecutedTime { get; private set; }
        public SqlScriptFileGeneratedEventArgs(String filePath)
        {
            this.FilePath = filePath;
            this.ExecutedTime = DateTime.Now;
        }
    }
}
