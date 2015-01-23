using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HigLabo.CodeGenerator
{
    public class TypeName
    {
        public String Name { get; set; }
        public List<TypeName> GenericTypes { get; private set; }
        public TypeName(String name)
        {
            this.Name = name;
            this.GenericTypes = new List<TypeName>();
        }
    }
}
