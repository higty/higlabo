namespace HigLabo.Bing;

public class NewsAnswer : BingRestApiResponse
{
    public string Id { get; set; } = "";
    public string ReadLink { get; set; } = "";
    public SortValue[]? Sort { get; set; } 
    public long? TotalEstimatedMatches { get; set; }
    public NewsArticle[] Value { get; set; } = Array.Empty<NewsArticle>();
    public string WebSearchUrl { get; set; } = "";
}
