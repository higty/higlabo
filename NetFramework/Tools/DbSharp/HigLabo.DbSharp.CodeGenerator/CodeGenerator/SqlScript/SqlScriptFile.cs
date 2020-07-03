using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public abstract class SqlScriptFile
    {
        public List<Table> Tables { get; private set; }
        public SqlScriptFile()
        {
            this.Tables = new List<Table>();
        }
        public abstract String CreateBodyText();
        public void WriteAllText(String filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, this.CreateBodyText(), encoding);
        }
    }
}
