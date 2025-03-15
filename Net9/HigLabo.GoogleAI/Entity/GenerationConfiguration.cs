using Newtonsoft.Json;

namespace HigLabo.GoogleAI;

public class GenerationConfiguration
{
    public double? Temperature { get; set; }
    public int? MaxOutputTokens { get; set; }
    public int? TopK { get; set; }
    public double? TopP { get; set; }
    public int? CandidateCount { get; set; }
    public List<string>? StopSequences { get; set; }
    public string? ResponseMimeType { get; set; }
    public List<string>? ResponseModalities { get; set; }
}
