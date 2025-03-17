namespace HigLabo.GoogleAI;
public class PredictParameter
{
    public int? SampleCount { get; set; }
    public int? Seed { get; set; }
    public bool? EnhancePrompt { get; set; } 
    public string? NegativePrompt { get; set; } 
    public string? AspectRatio { get; set; } 
    public string? SampleImageStyle { get; set; }
    public string? PersonGeneration { get; set; }
    public string? SafetySetting { get; set; }
    public bool? AddWatermark { get; set; }
    public string? StorageUri { get; set; }
}
