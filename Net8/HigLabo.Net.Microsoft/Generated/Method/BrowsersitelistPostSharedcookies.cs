using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sharedcookies?view=graph-rest-1.0
/// </summary>
public partial class BrowsersitelistPostSharedcookiesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? BrowserSiteListId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_SharedCookies: return $"/admin/edge/internetExplorerMode/siteLists/{BrowserSiteListId}/sharedCookies";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum BrowsersitelistPostSharedcookiesParameterBrowserSharedCookieSourceEnvironment
    {
        MicrosoftEdge,
        InternetExplorer11,
        Both,
        UnknownFutureValue,
    }
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
    public enum ApiPath
    {
        Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_SharedCookies,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Comment { get; set; }
    public string? DisplayName { get; set; }
    public bool? HostOnly { get; set; }
    public string? HostOrDomain { get; set; }
    public string? Path { get; set; }
    public BrowsersitelistPostSharedcookiesParameterBrowserSharedCookieSourceEnvironment SourceEnvironment { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public DateTimeOffset? DeletedDateTime { get; set; }
    public BrowserSharedCookieHistory[]? History { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public BrowserSharedCookieBrowserSharedCookieStatus Status { get; set; }
}
public partial class BrowsersitelistPostSharedcookiesResponse : RestApiResponse
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
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sharedcookies?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sharedcookies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistPostSharedcookiesResponse> BrowsersitelistPostSharedcookiesAsync()
    {
        var p = new BrowsersitelistPostSharedcookiesParameter();
        return await this.SendAsync<BrowsersitelistPostSharedcookiesParameter, BrowsersitelistPostSharedcookiesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sharedcookies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistPostSharedcookiesResponse> BrowsersitelistPostSharedcookiesAsync(CancellationToken cancellationToken)
    {
        var p = new BrowsersitelistPostSharedcookiesParameter();
        return await this.SendAsync<BrowsersitelistPostSharedcookiesParameter, BrowsersitelistPostSharedcookiesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sharedcookies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistPostSharedcookiesResponse> BrowsersitelistPostSharedcookiesAsync(BrowsersitelistPostSharedcookiesParameter parameter)
    {
        return await this.SendAsync<BrowsersitelistPostSharedcookiesParameter, BrowsersitelistPostSharedcookiesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sharedcookies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistPostSharedcookiesResponse> BrowsersitelistPostSharedcookiesAsync(BrowsersitelistPostSharedcookiesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BrowsersitelistPostSharedcookiesParameter, BrowsersitelistPostSharedcookiesResponse>(parameter, cancellationToken);
    }
}
