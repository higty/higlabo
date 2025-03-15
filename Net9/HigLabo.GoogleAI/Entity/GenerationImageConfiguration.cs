using Newtonsoft.Json;

namespace HigLabo.GoogleAI;

public class GenerationImageConfiguration
{
    public string? Prompt { get; set; }
    public string? AspectRatio { get; set; }
    public int? NumberOfImages { get; set; }
    public string? PersonGeneration { get; set; }
}
