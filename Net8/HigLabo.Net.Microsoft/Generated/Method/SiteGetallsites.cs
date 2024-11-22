using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-getallsites?view=graph-rest-1.0
/// </summary>
public partial class SiteGetallsitesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Site_GetAllSites: return $"/site/getAllSites";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Site_GetAllSites,
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
public partial class SiteGetallsitesResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-getallsites?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-getallsites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteGetallsitesResponse> SiteGetallsitesAsync()
    {
        var p = new SiteGetallsitesParameter();
        return await this.SendAsync<SiteGetallsitesParameter, SiteGetallsitesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-getallsites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteGetallsitesResponse> SiteGetallsitesAsync(CancellationToken cancellationToken)
    {
        var p = new SiteGetallsitesParameter();
        return await this.SendAsync<SiteGetallsitesParameter, SiteGetallsitesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-getallsites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteGetallsitesResponse> SiteGetallsitesAsync(SiteGetallsitesParameter parameter)
    {
        return await this.SendAsync<SiteGetallsitesParameter, SiteGetallsitesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-getallsites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteGetallsitesResponse> SiteGetallsitesAsync(SiteGetallsitesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SiteGetallsitesParameter, SiteGetallsitesResponse>(parameter, cancellationToken);
    }
}
