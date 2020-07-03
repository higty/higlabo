using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class FieldModifier
    {
        public AccessModifier AccessModifier { get; set; }
        public Boolean Const { get; set; }
        public Boolean Static { get; set; }
        public Boolean ReadOnly { get; set; }
        public Boolean Volatile { get; set; }
        public FieldModifier()
        {
            this.AccessModifier = AccessModifier.Private;
        }
    }
}
