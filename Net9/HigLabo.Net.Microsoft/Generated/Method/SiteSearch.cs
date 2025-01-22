using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
/// </summary>
public partial class SiteSearchParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites: return $"/sites";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Sites,
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
public partial class SiteSearchResponse : RestApiResponse<Site>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteSearchResponse> SiteSearchAsync()
    {
        var p = new SiteSearchParameter();
        return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteSearchResponse> SiteSearchAsync(CancellationToken cancellationToken)
    {
        var p = new SiteSearchParameter();
        return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteSearchResponse> SiteSearchAsync(SiteSearchParameter parameter)
    {
        return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteSearchResponse> SiteSearchAsync(SiteSearchParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Site> SiteSearchEnumerateAsync(SiteSearchParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Site>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
