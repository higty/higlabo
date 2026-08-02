namespace HigLabo.Anthropic;

public static class ModelNames
{
    public const string ClaudeFable5 = "claude-fable-5";
    public const string ClaudeMythos5 = "claude-mythos-5";
    public const string ClaudeOpus5 = "claude-opus-5";
    public const string ClaudeSonnet5 = "claude-sonnet-5";
    public const string ClaudeOpus4_8 = "claude-opus-4-8";
    public const string ClaudeOpus4_7 = "claude-opus-4-7";
    public const string ClaudeOpus4_6 = "claude-opus-4-6";
    public const string ClaudeOpus4_5 = "claude-opus-4-5";
    public const string ClaudeOpus4_1 = "claude-opus-4-1-20250805";
    public const string ClaudeOpus4 = "claude-opus-4-20250514";
    public const string ClaudeSonnet4_6 = "claude-sonnet-4-6";
    public const string ClaudeSonnet4_5 = "claude-sonnet-4-5";
    public const string ClaudeSonnet4 = "claude-sonnet-4-20250514";
    public const string Claude3_7Sonnet = "claude-3-7-sonnet-20250219";
    public const string ClaudeHaiku4_5 = "claude-haiku-4-5";
    public const string Claude3_5Haiku = "claude-3-5-haiku-20241022";
    public const string Claude3Haiku = "claude-3-haiku-20240307";

    public static decimal? CalculateCost(string modelName, MessageUsage usage)
    {
        switch (modelName.Trim().ToLowerInvariant())
        {
            case ClaudeFable5:
            case ClaudeMythos5:
                return CalculateCost(usage, 10.00m, 12.50m, 20.00m, 1.00m, 50.00m);
            case ClaudeOpus5:
            case ClaudeOpus4_8:
            case ClaudeOpus4_7:
            case ClaudeOpus4_6:
            case ClaudeOpus4_5:
                return CalculateCost(usage, 5.00m, 6.25m, 10.00m, 0.50m, 25.00m);
            case ClaudeSonnet5:
                return CalculateCost(usage, 2.00m, 2.50m, 4.00m, 0.20m, 10.00m);
            case ClaudeOpus4_1:
            case ClaudeOpus4:
                return CalculateCost(usage, 15.00m, 18.75m, 30.00m, 1.50m, 75.00m);
            case ClaudeSonnet4_6:
            case ClaudeSonnet4_5:
            case ClaudeSonnet4:
            case Claude3_7Sonnet:
                return CalculateCost(usage, 3.00m, 3.75m, 6.00m, 0.30m, 15.00m);
            case ClaudeHaiku4_5:
                return CalculateCost(usage, 1.00m, 1.25m, 2.00m, 0.10m, 5.00m);
            case Claude3_5Haiku:
                return CalculateCost(usage, 0.80m, 1.00m, 1.60m, 0.08m, 4.00m);
            case Claude3Haiku:
                return CalculateCost(usage, 0.25m, 0.30m, 0.50m, 0.03m, 1.25m);
            default: return null;
        }
    }
    public static decimal CalculateCost(MessageUsage usage, decimal inputPrice, decimal cacheWrite5mPrice, decimal cacheWrite1hPrice, decimal cacheReadPrice, decimal outputPrice)
    {
        return (
            (usage.Input_Tokens * inputPrice) +
            (usage.GetCacheCreation5mInputTokens() * cacheWrite5mPrice) +
            (usage.Cache_Creation.Ephemeral_1h_Input_Tokens * cacheWrite1hPrice) +
            (usage.Cache_Read_Input_Tokens * cacheReadPrice) +
            (usage.Output_Tokens * outputPrice)
        ) / 1_000_000m;
    }
}
