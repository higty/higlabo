using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic
{
    public class MessageDelta
    {
        public class DeltaObject
        {
            public string Stop_Reason { get; set; } = "";
            public string Stop_Sequence { get; set; } = "";
        }
        public class UsageObject
        {
            public int Output_Tokens { get; set; }
        }
        public string Type { get; set; } = "";
        public DeltaObject Delta { get; set; } = new();
        public UsageObject Usage { get; set; } = new();
    }
}
