using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class OpenAISettings
    {
        public string ApiKey { get; set; } = "";
        public string Organization { get; set; } = "";
        public bool UseBetaEndpoint { get; set; } = true;

        public OpenAISettings() { }
        public OpenAISettings(string apiKey)
        {
        }
    }
}
