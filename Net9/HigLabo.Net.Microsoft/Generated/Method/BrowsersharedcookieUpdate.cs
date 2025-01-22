using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
/// </summary>
public partial class BrowserSharedcookieUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? BrowserSiteListId { get; set; }
        public string? BrowserSharedCookieId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_SharedCookies_BrowserSharedCookieId: return $"/admin/edge/internetExplorerMode/siteLists/{BrowserSiteListId}/sharedCookies/{BrowserSharedCookieId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum BrowserSharedcookieUpdateParameterBrowserSharedCookieSourceEnvironment
    {
        MicrosoftEdge,
        InternetExplorer11,
        Both,
        UnknownFutureValue,
    }
    public enum ApiPath
    {
        Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_SharedCookies_BrowserSharedCookieId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public string? Comment { get; set; }
    public string? DisplayName { get; set; }
    public bool? HostOnly { get; set; }
    public string? HostOrDomain { get; set; }
    public string? Path { get; set; }
    public BrowserSharedcookieUpdateParameterBrowserSharedCookieSourceEnvironment SourceEnvironment { get; set; }
}
public partial class BrowserSharedcookieUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowserSharedcookieUpdateResponse> BrowserSharedcookieUpdateAsync()
    {
        var p = new BrowserSharedcookieUpdateParameter();
        return await this.SendAsync<BrowserSharedcookieUpdateParameter, BrowserSharedcookieUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowserSharedcookieUpdateResponse> BrowserSharedcookieUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new BrowserSharedcookieUpdateParameter();
        return await this.SendAsync<BrowserSharedcookieUpdateParameter, BrowserSharedcookieUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowserSharedcookieUpdateResponse> BrowserSharedcookieUpdateAsync(BrowserSharedcookieUpdateParameter parameter)
    {
        return await this.SendAsync<BrowserSharedcookieUpdateParameter, BrowserSharedcookieUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowserSharedcookieUpdateResponse> BrowserSharedcookieUpdateAsync(BrowserSharedcookieUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BrowserSharedcookieUpdateParameter, BrowserSharedcookieUpdateResponse>(parameter, cancellationToken);
    }
}
