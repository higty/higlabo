using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
/// </summary>
public partial class BundleListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Drive_Bundles: return $"/drive/bundles";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Drive_Bundles,
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
public partial class BundleListResponse : RestApiResponse<Bundle>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BundleListResponse> BundleListAsync()
    {
        var p = new BundleListParameter();
        return await this.SendAsync<BundleListParameter, BundleListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BundleListResponse> BundleListAsync(CancellationToken cancellationToken)
    {
        var p = new BundleListParameter();
        return await this.SendAsync<BundleListParameter, BundleListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BundleListResponse> BundleListAsync(BundleListParameter parameter)
    {
        return await this.SendAsync<BundleListParameter, BundleListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BundleListResponse> BundleListAsync(BundleListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BundleListParameter, BundleListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Bundle> BundleListEnumerateAsync(BundleListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<BundleListParameter, BundleListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Bundle>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
