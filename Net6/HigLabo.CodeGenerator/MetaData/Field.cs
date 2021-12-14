using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class Field
    {
        public FieldModifier Modifier { get; private set; }
        public TypeName TypeName { get; private set; }
        public String Name { get; set; }
        public String Initializer { get; set; }
        public Field(String typeName, String name)
            : this(new TypeName(typeName), name)
        {
        }
        public Field(String typeName, String name, String initializer)
            : this(new TypeName(typeName), name)
        {
            this.Initializer = initializer;
        }
        public Field(TypeName typeName, String name)
        {
            this.Modifier = new FieldModifier();
            this.TypeName = typeName;
            this.Name = name;
        }
        public override string ToString()
        {
            return String.Format("{0}:{1}", this.Name, this.TypeName.ToString());
        }
    }
}
