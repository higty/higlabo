using HigLabo.Core;

namespace HigLabo.Bing;

public class WebPage
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Url { get; set; } = "";
    public string DisplayUrl { get; set; } = "";
    public string Snippet { get; set; } = "";
    public string DatePublished { get; set; } = "";
    public DateTimeOffset? PublishTime
    {
        get
        {
            return this.DatePublished.ToDateTimeOffset();
        }
    }
    public string DatePublishedFreshnessText { get; set; } = "";
    public bool? IsFamilyFriendly { get; set; }
    public DateTimeOffset? DateLastCrawled { get; set; } 
    public string CachedPageUrl { get; set; } = "";
    public string Language { get; set; } = "";
    public bool IsNavigational { get; set; }
    public bool NoCache { get; set; }

    public override string ToString()
    {
        return this.Name;
    }
}
