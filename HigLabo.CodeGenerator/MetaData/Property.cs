using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class Property
    {
        public List<String> Attributes { get; private set; }
        public MethodModifier Modifier { get; private set; }
        public TypeName TypeName { get; set; }
        public String Name { get; set; }
        public PropertyBody Get { get; set; }
        public PropertyBody Set { get; set; }
        public Property(String typeName, String name)
            : this(new TypeName(typeName), name)
        {
        }
        public Property(TypeName typeName, String name)
        {
            this.Attributes = new List<string>();
            this.Modifier = new MethodModifier(MethodAccessModifier.Public);
            this.TypeName = typeName;
            this.Name = name;
            this.Get = new PropertyBody(PropertyBodyType.Get);
            this.Set = new PropertyBody(PropertyBodyType.Set);
        }
        public override string ToString()
        {
            return String.Format("{0}:{1}", this.Name, this.TypeName.ToString());
        }
    }
}
