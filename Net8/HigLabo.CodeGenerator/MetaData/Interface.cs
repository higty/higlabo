using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator;

public class Interface
{
    public AccessModifier Modifier { get; set; }
    public String Name { get; set; }
    public List<TypeName> ImplementInterfaces { get; private set; } = new List<TypeName>();
    public List<InterfaceProperty> Properties { get; private set; } = new List<InterfaceProperty>();
    public List<InterfaceMethod> Methods { get; private set; } = new List<InterfaceMethod>();
    public Interface(String name)
    {
        this.Modifier = AccessModifier.Public;
        this.Name = name;
    }
    public override string ToString()
    {
        return this.Name;
    }
}
