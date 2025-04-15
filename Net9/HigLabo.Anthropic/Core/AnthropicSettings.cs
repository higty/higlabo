using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic;

public class AnthropicSettings
{
    public string ApiKey { get; set; } = "";
    public string Version { get; set; } = "2023-06-01";
    public string BetaVersion { get; set; } = "tools-2024-04-04";

    public AnthropicSettings() { }
    public AnthropicSettings(string apiKey)
    {
        ApiKey = apiKey;
    }
}
