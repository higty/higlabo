using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class GroqSettings
{
    public string ApiKey { get; set; } = "";

    public GroqSettings() { }
    public GroqSettings(string apiKey)
    {
        this.ApiKey = apiKey;
    }
}
