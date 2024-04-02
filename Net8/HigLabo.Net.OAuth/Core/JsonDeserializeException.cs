using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class JsonDeserializeException : Exception
    {
        public string Json { get; set; }
        public JsonDeserializeException(string json, Exception exception)
            : base(json + Environment.NewLine + Environment.NewLine + exception.Message, exception)
        {
            this.Json = json;
        }
    }
}
