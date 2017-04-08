using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharpApplication
{
    public class SchemaFileInfo
    {
        public String FilePath { get; set; }
        public String OutputDirectoryPath { get; set; }
        public String SqlScriptOutputDirectoryPath { get; set; }
        public String ConnectionStringName { get; set; }

        public SchemaFileInfo()
        {
            this.FilePath = "";
            this.OutputDirectoryPath = Environment.CurrentDirectory + "\\Output\\";
            this.SqlScriptOutputDirectoryPath = Environment.CurrentDirectory + "\\Output\\";
        }
    }
}
