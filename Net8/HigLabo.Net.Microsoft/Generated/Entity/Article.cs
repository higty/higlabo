using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-article?view=graph-rest-1.0
/// </summary>
public partial class Article
{
    public FormattedContent? Body { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public bool? IsFeatured { get; set; }
    public string? Id { get; set; }
    public string? ImageUrl { get; set; }
    public DateTimeOffset? LastUpdatedDateTime { get; set; }
    public FormattedContent? Summary { get; set; }
    public String[]? Tags { get; set; }
    public string? Title { get; set; }
    public ArticleIndicator[]? Indicators { get; set; }
}
