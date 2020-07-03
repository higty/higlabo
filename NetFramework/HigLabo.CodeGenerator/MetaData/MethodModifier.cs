using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class MethodModifier
    {
        public MethodAccessModifier AccessModifier { get; set; }
        public Boolean Static { get; set; }
        public MethodPolymophism Polymophism { get; set; }
        public MethodModifier(MethodAccessModifier accessModifier)
        {
            this.AccessModifier = accessModifier;
            this.Static = false;
            this.Polymophism = MethodPolymophism.None;
        }
    }
}
