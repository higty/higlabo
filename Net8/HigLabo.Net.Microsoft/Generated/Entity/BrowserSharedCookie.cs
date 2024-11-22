using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/browsersharedcookie?view=graph-rest-1.0
/// </summary>
public partial class BrowserSharedCookie
{
    public enum BrowserSharedCookieBrowserSharedCookieSourceEnvironment
    {
        MicrosoftEdge,
        InternetExplorer11,
        Both,
        UnknownFutureValue,
    }
    public enum BrowserSharedCookieBrowserSharedCookieStatus
    {
        Published,
        PendingAdd,
        PendingEdit,
        PendingDelete,
        UnknownFutureValue,
    }

    public string? Comment { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public DateTimeOffset? DeletedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public BrowserSharedCookieHistory[]? History { get; set; }
    public bool? HostOnly { get; set; }
    public string? HostOrDomain { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? Path { get; set; }
    public BrowserSharedCookieBrowserSharedCookieSourceEnvironment SourceEnvironment { get; set; }
    public BrowserSharedCookieBrowserSharedCookieStatus Status { get; set; }
}
