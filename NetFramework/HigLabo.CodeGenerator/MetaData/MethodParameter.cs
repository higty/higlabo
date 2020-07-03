using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class MethodParameter
    {
        public TypeName TypeName { get; private set; }
        public String Name { get; set; }
        public MethodParameter(String typeName, String name)
            : this(new TypeName(typeName), name)
        {
        }
        public MethodParameter(TypeName typeName, String name)
        {
            this.TypeName = typeName;
            this.Name = name;
        }
    }
}
