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
        public override string ToString()
        {
            if (this.GenericTypes.Count == 0)
            {
                return this.Name;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append("<");
            for (int i = 0; i < this.GenericTypes.Count; i++)
            {
                sb.Append(this.GenericTypes[i].ToString());
                if (i < this.GenericTypes.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(">");

            return sb.ToString();
        }
    }
}
