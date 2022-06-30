using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class Method
    {
        public string Comment { get; set; }
        public MethodModifier Modifier { get; private set; }
        public TypeName ReturnTypeName { get; set; }
        public String Name { get; set; }
        public List<MethodParameter> Parameters { get; private set; }
        public List<String> GenericParameters { get; private set; }
        public CodeBlockCollection Body { get; private set; }
        public Method(MethodAccessModifier accessModifier, String name)
        {
            this.Modifier = new MethodModifier(accessModifier);
            this.ReturnTypeName = new TypeName("void");
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

        public Method Copy()
        {
            var md = new Method(this.Modifier.AccessModifier, this.Name);
            md.Modifier.Static = this.Modifier.Static;
            md.Modifier.Polymophism = this.Modifier.Polymophism;
            foreach (var item in this.GenericParameters)
            {
                md.GenericParameters.Add(item);
            }
            foreach (var item in this.Parameters)
            {
                var p = new MethodParameter(item.TypeName, item.Name);
                md.Parameters.Add(p);
            }
            md.ReturnTypeName = this.ReturnTypeName;

            foreach (var item in this.Body)
            {
                md.Body.Add(item);
            }
            return md;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append("(");
            for (int i = 0; i < this.Parameters.Count; i++)
            {
                sb.Append(this.Parameters[i].Name);
                if (i < this.Parameters.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(")");

            return sb.ToString();
        }
    }
}
