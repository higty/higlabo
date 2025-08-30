using Newtonsoft.Json;

namespace HigLabo.GoogleAI;

public class GenerationConfiguration
{
    public double? Temperature { get; set; }
    public double? TopP { get; set; }
    public int? TopK { get; set; }
    public int? CandidateCount { get; set; }
    public int? MaxOutputTokens { get; set; }
    public string? MediaResolution { get; set; }
    public float? PresencePenalty { get; set; }
    public float? FrequencyPenalty { get; set; }
    public List<string>? StopSequences { get; set; }
    public string? ResponseMimeType { get; set; }
    public object? ResponseSchema { get; set; }
    public int? Seed { get; set; }
    public bool? ResponseLogprobs { get; set; }
    public int? Logprobs { get; set; }
    public bool? AudioTimestamp { get; set; }

    public List<string>? ResponseModalities { get; set; }
    public SpeechConfiguration? SpeechConfig { get; set; }
    public ThinkingConfiguration? ThinkingConfig { get; set; }
}
