namespace HigLabo.GoogleAI;

public class UsageMetadata
{
    public int PromptTokenCount { get; set; }
    public int CachedContentTokenCount { get; set; }
    public int CandidatesTokenCount { get; set; }
    public int ToolUsePromptTokenCount { get; set; }
    public int ThoughtsTokenCount { get; set; }
    public int TotalTokenCount { get; set; }
    public List<ModalityTokenCount> PromptTokensDetails { get; set; } = new();
    public List<ModalityTokenCount> CacheTokensDetails { get; set; } = new();
    public List<ModalityTokenCount> CandidatesTokensDetails { get; set; } = new();
    public List<ModalityTokenCount> ToolUsePromptTokensDetails { get; set; } = new();
    public string ServiceTier { get; set; } = "";

    public int GetInputTokenCount()
    {
        return Math.Max(0, this.PromptTokenCount - this.CachedContentTokenCount) + this.ToolUsePromptTokenCount;
    }
    public int GetOutputTokenCount()
    {
        return this.CandidatesTokenCount + this.ThoughtsTokenCount;
    }
}
public class ModalityTokenCount
{
    public string Modality { get; set; } = "";
    public int TokenCount { get; set; }
}
