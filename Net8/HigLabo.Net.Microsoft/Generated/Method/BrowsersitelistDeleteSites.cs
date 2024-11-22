using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sites?view=graph-rest-1.0
/// </summary>
public partial class BrowsersitelistDeleteSitesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? BrowserSiteListId { get; set; }
        public string? BrowserSiteId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_Sites_BrowserSiteId: return $"/admin/edge/internetExplorerMode/siteLists/{BrowserSiteListId}/sites/{BrowserSiteId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_Sites_BrowserSiteId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class BrowsersitelistDeleteSitesResponse : RestApiResponse
{
    public enum BrowserSiteListBrowserSiteListStatus
    {
        Draft,
        Published,
        Pending,
        UnknownFutureValue,
    }

    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public IdentitySet? PublishedBy { get; set; }
    public DateTimeOffset? PublishedDateTime { get; set; }
    public string? Revision { get; set; }
    public BrowserSiteListBrowserSiteListStatus Status { get; set; }
    public BrowserSharedCookie[]? SharedCookies { get; set; }
    public BrowserSite[]? Sites { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sites?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistDeleteSitesResponse> BrowsersitelistDeleteSitesAsync()
    {
        var p = new BrowsersitelistDeleteSitesParameter();
        return await this.SendAsync<BrowsersitelistDeleteSitesParameter, BrowsersitelistDeleteSitesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistDeleteSitesResponse> BrowsersitelistDeleteSitesAsync(CancellationToken cancellationToken)
    {
        var p = new BrowsersitelistDeleteSitesParameter();
        return await this.SendAsync<BrowsersitelistDeleteSitesParameter, BrowsersitelistDeleteSitesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistDeleteSitesResponse> BrowsersitelistDeleteSitesAsync(BrowsersitelistDeleteSitesParameter parameter)
    {
        return await this.SendAsync<BrowsersitelistDeleteSitesParameter, BrowsersitelistDeleteSitesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistDeleteSitesResponse> BrowsersitelistDeleteSitesAsync(BrowsersitelistDeleteSitesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BrowsersitelistDeleteSitesParameter, BrowsersitelistDeleteSitesResponse>(parameter, cancellationToken);
    }
}
