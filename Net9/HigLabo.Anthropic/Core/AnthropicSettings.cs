using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic;

public class AnthropicSettings
{
    public string ApiKey { get; set; } = "";
    public string Version { get; set; } = "2026-10-21";
    public string BetaVersion { get; set; } = "";

    public AnthropicSettings() { }
    public AnthropicSettings(string apiKey)
    {
        ApiKey = apiKey;
    }
}
