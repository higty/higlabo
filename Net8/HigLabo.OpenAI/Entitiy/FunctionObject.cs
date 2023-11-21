using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class FunctionObject
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public object? Parameters { get; set; }
    }
}
