using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class Constructor
    {
        public ConstructorModifier Modifier { get; private set; }
        public String Name { get; set; }
        public List<MethodParameter> Parameters { get; private set; }
        public List<String> GenericParameters { get; private set; }
        public CodeBlockCollection Body { get; private set; }
        public Constructor(AccessModifier accessModifier, String name)
        {
            this.Modifier = new ConstructorModifier(accessModifier);
            this.Name = name;
            this.Parameters = new List<MethodParameter>();
            this.GenericParameters = new List<String>();
            this.Body = new CodeBlockCollection();
        }
        public MethodParameter AddParameter(String typeName, String name)
        {
            var p = new MethodParameter(typeName, name);
            this.Parameters.Add(p);
            return p;
        }
    }
}
