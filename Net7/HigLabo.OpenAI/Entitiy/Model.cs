using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class Model
    {
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public Int64 Created { get; set; }
        public string Owned_By { get; set; } = "";

        public DateTimeOffset CreateTime 
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
            }
        }
    }
}
