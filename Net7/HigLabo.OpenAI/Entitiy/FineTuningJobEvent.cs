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
        public int Created_At { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
            }
        }
        public string Level { get; set; } = "";
        public string Message { get; set; } = "";
        public string Object { get; set; } = "";
    }
}
