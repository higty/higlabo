using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/browsersharedcookiehistory?view=graph-rest-1.0
/// </summary>
public partial class BrowserSharedCookieHistory
{
    public enum BrowserSharedCookieHistoryBrowserSharedCookieSourceEnvironment
    {
        MicrosoftEdge,
        InternetExplorer11,
        Both,
        UnknownFutureValue,
    }

    public string? Comment { get; set; }
    public string? DisplayName { get; set; }
    public bool? HostOnly { get; set; }
    public string? HostOrDomain { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public string? Path { get; set; }
    public DateTimeOffset? PublishedDateTime { get; set; }
    public BrowserSharedCookieHistoryBrowserSharedCookieSourceEnvironment SourceEnvironment { get; set; }
}
