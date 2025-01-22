using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator;

public class Enum
{
    public string Comment { get; set; } = "";
    public ClassModifier Modifier { get; private set; }
    public String Name { get; set; } = "";
    public String BaseClass { get; set; } = "";
    public List<EnumValue> Values { get; private set; } = new();

    public Enum()
        : this(AccessModifier.Public, "")
    {
    }
    public Enum(AccessModifier modifier, String name)
    {
        this.Modifier = new ClassModifier(modifier);
        this.Name = name;
    }
    public override string ToString()
    {
        return String.Format("{0} {1}", this.Modifier, this.Name);
    }
}
