using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class SourceCodeGeneratorDefaultSettings
    {
        public String Indent { get; set; }

        public SourceCodeGeneratorDefaultSettings()
        {
            this.Indent = "    ";
        }
    }
}
