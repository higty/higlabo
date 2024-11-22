namespace HigLabo.Bing;

public class WebAnswer
{
    public string Id { get; set; } = "";
    public bool? SomeResultsRemoved { get; set; }
    public long? TotalEstimatedMatches { get; set; }
    public WebPage[] Value { get; set; } = Array.Empty<WebPage>();
    public string WebSearchUrl { get; set; } = "";

    public override string ToString()
    {
        return this.WebSearchUrl;
    }
}
