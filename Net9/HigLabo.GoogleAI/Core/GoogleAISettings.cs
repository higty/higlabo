using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.GoogleAI;

public class GoogleAISettings
{
    public string ApiKey { get; set; } = "";

    public GoogleAISettings() { }
    public GoogleAISettings(string apiKey)
    {
        this.ApiKey = apiKey;
    }
}
