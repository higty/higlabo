using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.CodeGenerator;

public class ApiParameter
{
    public string Name { get; set; } = "";
    public string TypeName { get; set; } = "";
    public bool Required { get; set; }

    public string EntityUrl { get; set; } = "";
    public bool IsEnum { get; set; } = false;
    public List<string> EnumValues { get; init; } = new List<string>();

    public override string ToString()
    {
        return $"{this.TypeName} {this.Name}";
    }
}
