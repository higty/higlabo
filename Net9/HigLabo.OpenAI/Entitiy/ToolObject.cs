using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class ToolObject
{
    public string Type { get; set; } = "";
    public FunctionObject? Function { get; set; }

    public ToolObject() { }
    public ToolObject(string type)
    {
        this.Type = type;
    }
}
