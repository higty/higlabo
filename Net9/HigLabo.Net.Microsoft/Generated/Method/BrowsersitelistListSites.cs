using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sites?view=graph-rest-1.0
/// </summary>
public partial class BrowsersitelistListSitesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? BrowserSiteListId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_Sites: return $"/admin/edge/internetExplorerMode/siteLists/{BrowserSiteListId}/sites";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_Sites,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class BrowsersitelistListSitesResponse : RestApiResponse<BrowserSite>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sites?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistListSitesResponse> BrowsersitelistListSitesAsync()
    {
        var p = new BrowsersitelistListSitesParameter();
        return await this.SendAsync<BrowsersitelistListSitesParameter, BrowsersitelistListSitesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistListSitesResponse> BrowsersitelistListSitesAsync(CancellationToken cancellationToken)
    {
        var p = new BrowsersitelistListSitesParameter();
        return await this.SendAsync<BrowsersitelistListSitesParameter, BrowsersitelistListSitesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistListSitesResponse> BrowsersitelistListSitesAsync(BrowsersitelistListSitesParameter parameter)
    {
        return await this.SendAsync<BrowsersitelistListSitesParameter, BrowsersitelistListSitesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistListSitesResponse> BrowsersitelistListSitesAsync(BrowsersitelistListSitesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BrowsersitelistListSitesParameter, BrowsersitelistListSitesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sites?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<BrowserSite> BrowsersitelistListSitesEnumerateAsync(BrowsersitelistListSitesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<BrowsersitelistListSitesParameter, BrowsersitelistListSitesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<BrowserSite>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
