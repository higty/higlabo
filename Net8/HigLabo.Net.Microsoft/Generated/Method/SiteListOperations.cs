using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
/// </summary>
public partial class SiteListOperationsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_Operations: return $"/sites/{SiteId}/operations";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Sites_SiteId_Operations,
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
public partial class SiteListOperationsResponse : RestApiResponse<RichLongRunningOperation>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListOperationsResponse> SiteListOperationsAsync()
    {
        var p = new SiteListOperationsParameter();
        return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListOperationsResponse> SiteListOperationsAsync(CancellationToken cancellationToken)
    {
        var p = new SiteListOperationsParameter();
        return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListOperationsResponse> SiteListOperationsAsync(SiteListOperationsParameter parameter)
    {
        return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListOperationsResponse> SiteListOperationsAsync(SiteListOperationsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<RichLongRunningOperation> SiteListOperationsEnumerateAsync(SiteListOperationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<RichLongRunningOperation>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
