using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class ConstructorModifier
    {
        public AccessModifier AccessModifier { get; set; }
        public Boolean Static { get; set; }
        public ConstructorModifier(AccessModifier accessModifier)
        {
            this.AccessModifier = accessModifier;
            this.Static = false;
        }
    }
}
