using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class InterfaceProperty
    {
        public TypeName TypeName { get; set; }
        public String Name { get; set; }
        public Boolean Get { get; set; }
        public Boolean Set { get; set; }
        public InterfaceProperty(String typeName, String name, Boolean get, Boolean set)
            : this(new TypeName(typeName), name, get, set)
        {
        }
        public InterfaceProperty(TypeName typeName, String name, Boolean get, Boolean set)
        {
            this.TypeName = typeName;
            this.Name = name;
            this.Get = get;
            this.Set = set;
        }
    }
}
