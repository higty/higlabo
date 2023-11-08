using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class FineTuningJobEvent
    {
        public string Id { get; set; } = "";
        public int CreateAt { get; set; }
        public string Level { get; set; } = "";
        public string Message { get; set; } = "";
        public string Object { get; set; } = "";
    }
}
