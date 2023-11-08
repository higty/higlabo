using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class Tool
    {
        public string Type { get; set; } = "";
        public object Function { get; set; }

        public Tool(string type, object function)
        {
            Type = type;
            Function = function;
        }
    }
}
