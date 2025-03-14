using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class ToolObject
{
    public class UserLocation
    {
        public string Type { get; set; } = "";
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Timezone { get; set; }
    }

    public string Type { get; set; } = "";
    public FunctionObject? Function { get; set; }

    public string? Search_Context_Size { get; set; }
    public UserLocation? User_Location { get; set; }

    public List<string>? Vector_Store_Ids { get; set; }
    public int? Max_Num_Results { get; set; }

    public ToolObject() { }
    public ToolObject(string type)
    {
        this.Type = type;
    }

    public override string ToString()
    {
        return this.Type;
    }
}
