using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/browsersite?view=graph-rest-1.0
/// </summary>
public partial class BrowserSite
{
    public enum BrowserSiteBrowserSiteCompatibilityMode
    {
        Default,
        InternetExplorer8Enterprise,
        InternetExplorer7Enterprise,
        InternetExplorer11,
        InternetExplorer10,
        InternetExplorer9,
        InternetExplorer8,
        InternetExplorer7,
        InternetExplorer5,
        UnknownFutureValue,
    }
    public enum BrowserSiteBrowserSiteMergeType
    {
        NoMerge,
        Default,
        UnknownFutureValue,
    }
    public enum BrowserSiteBrowserSiteStatus
    {
        Published,
        PendingAdd,
        PendingEdit,
        PendingDelete,
        UnknownFutureValue,
    }
    public enum BrowserSiteBrowserSiteTargetEnvironment
    {
        InternetExplorerMode,
        InternetExplorer11,
        MicrosoftEdge,
        Configurable,
        None,
        UnknownFutureValue,
    }

    public bool? AllowRedirect { get; set; }
    public string? Comment { get; set; }
    public BrowserSiteBrowserSiteCompatibilityMode CompatibilityMode { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public DateTimeOffset? DeletedDateTime { get; set; }
    public BrowserSiteHistory[]? History { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public BrowserSiteBrowserSiteMergeType MergeType { get; set; }
    public BrowserSiteBrowserSiteStatus Status { get; set; }
    public BrowserSiteBrowserSiteTargetEnvironment TargetEnvironment { get; set; }
    public string? WebUrl { get; set; }
}
