namespace HigLabo.GoogleAI;

public class Candidate
{
    public Content Content { get; set; } = new();
    public FinishReason FinishReason { get; set; }
    public List<SafetyRating> SafetyRatings { get; set; } = new();
    public GroundingMetaData? GroundingMetaData { get; set; }
    public CitationMetadata? CitationMetadata { get; set; }
    public UsageMetaData UsageMetaData { get; set; } = new();
}