using HigLabo.CodeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class SourceCodeFile
    {
        public String FilePath { get; set; }
        public SourceCode SourceCode { get; private set; }
        public SourceCodeFile(String filePath, SourceCode sourceCode)
        {
            this.FilePath = filePath;
            this.SourceCode = sourceCode;
        }
    }
}
