using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class InterfaceMethod
    {
        public TypeName ReturnTypeName { get; set; }
        public String Name { get; set; }
        public List<MethodParameter> Parameters { get; private set; }
        public List<String> GenericParameters { get; private set; }
        public InterfaceMethod(String name)
        {
            this.ReturnTypeName = new TypeName("void");
            this.Name = name;
            this.Parameters = new List<MethodParameter>();
            this.GenericParameters = new List<String>();
        }
        public MethodParameter AddParameter(String typeName, String name)
        {
            var p = new MethodParameter(typeName, name);
            this.Parameters.Add(p);
            return p;
        }
    }
}
