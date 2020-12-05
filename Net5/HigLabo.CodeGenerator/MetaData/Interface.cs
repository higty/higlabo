using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class Interface
    {
        public AccessModifier Modifier { get; set; }
        public String Name { get; set; }
        public List<InterfaceProperty> Properties { get; private set; }
        public List<InterfaceMethod> Methods { get; private set; }
        public Interface(String name)
        {
            this.Modifier = AccessModifier.Public;
            this.Name = name;
            this.Properties = new List<InterfaceProperty>();
            this.Methods = new List<InterfaceMethod>();
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
