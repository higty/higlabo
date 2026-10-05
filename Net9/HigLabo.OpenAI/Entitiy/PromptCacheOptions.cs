namespace HigLabo.OpenAI;

/// <summary>Prompt caching controls for GPT-5.6 and later supported models.</summary>
public class PromptCacheOptions
{
    public string? Mode { get; set; }
    public string? Ttl { get; set; }
    public bool? Prewarm { get; set; }
}

public class PromptCacheBreakpoint
{
    public string Mode { get; set; } = "explicit";
}
