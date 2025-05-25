using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class Tool
{
    public string Type { get; set; } = "";

    public Tool() { }
    public Tool(string type)
    {
        this.Type = type;
    }

    public override string ToString()
    {
        return this.Type;
    }
}
