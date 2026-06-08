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
    public decimal? CalculateCost(string modelName)
    {
        switch (modelName.Trim().ToLowerInvariant())
        {
            case ModelNames.Gemini_3_5_Flash:
                return this.CalculateCost(1.50m, 0.15m, 9.00m);
            case ModelNames.Gemini_3_1_Flash_Lite:
            case ModelNames.Gemini_3_1_Flash_Lite_Preview:
                return this.CalculateCost(0.25m, 0.025m, 1.50m);
            case ModelNames.Gemini_3_1_Pro_Preview:
            case ModelNames.Gemini_3_1_Pro_Preview_CustomTools:
            case ModelNames.Gemini_3_Pro_Preview:
                return this.PromptTokenCount > 200_000
                    ? this.CalculateCost(4.00m, 0.40m, 18.00m)
                    : this.CalculateCost(2.00m, 0.20m, 12.00m);
            case ModelNames.Gemini_3_Flash_Preview:
                return this.CalculateCost(0.50m, 0.05m, 3.00m);
            case ModelNames.Gemini_2_5_Pro:
                return this.PromptTokenCount > 200_000
                    ? this.CalculateCost(2.50m, 0.25m, 15.00m)
                    : this.CalculateCost(1.25m, 0.125m, 10.00m);
            case ModelNames.Gemini_2_5_Flash:
                return this.CalculateCost(0.30m, 0.03m, 2.50m);
            case ModelNames.Gemini_2_5_Flash_Lite:
                return this.CalculateCost(0.10m, 0.01m, 0.40m);
            case ModelNames.Gemini_3_1_Flash_Image_Preview:
            case ModelNames.Gemini_3_Pro_Image_Preview:
                return this.CalculateCost(0.50m, 0.50m, 3.00m);
            default: return null;
        }
    }
    public decimal CalculateCost(decimal inputPrice, decimal cachedInputPrice, decimal outputPrice)
    {
        return (
            (this.GetInputTokenCount() * inputPrice) +
            (this.CachedContentTokenCount * cachedInputPrice) +
            (this.GetOutputTokenCount() * outputPrice)
        ) / 1_000_000m;
    }
}
public class ModalityTokenCount
{
    public string Modality { get; set; } = "";
    public int TokenCount { get; set; }
}
