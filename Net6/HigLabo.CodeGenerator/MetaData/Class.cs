using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class Class
    {
        public ClassModifier Modifier { get; private set; }
        public String Name { get; set; }
        public TypeName BaseClass { get; set; }
        public List<TypeName> ImplementInterfaces { get; private set; }
        public List<Field> Fields { get; private set; }
        public List<Property> Properties { get; private set; }
        public List<Constructor> Constructors { get; private set; }
        public List<Method> Methods { get; private set; }
        public List<Interface> Interfaces { get; private set; }
        public List<Class> Classes { get; private set; }
        public List<Enum> Enums { get; private set; }

        public Class(AccessModifier modifier, String name)
        {
            this.Modifier = new ClassModifier(modifier);
            this.Name = name;
            this.ImplementInterfaces = new List<TypeName>();
            this.Fields = new List<Field>();
            this.Properties = new List<Property>();
            this.Constructors = new List<Constructor>();
            this.Methods = new List<Method>();
            this.Interfaces = new List<Interface>();
            this.Classes = new List<Class>();
            this.Enums = new List<Enum>();
        }
        public void AddPropertyAndField(String typeName, String name)
        {
            var f = new Field(typeName, "_" + name);
            this.Fields.Add(f);

            var p = new Property(typeName, name);
            p.Get.Body.Add(SourceCodeLanguage.CSharp, "return _" + name + ";");
            p.Get.IsAutomaticProperty = true;
            p.Set.Body.Add(SourceCodeLanguage.CSharp, "_" + name + " = value;");
            p.Set.IsAutomaticProperty = true;
            this.Properties.Add(p);
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", this.Modifier.ToString(), this.Name);
        }
    }
}
