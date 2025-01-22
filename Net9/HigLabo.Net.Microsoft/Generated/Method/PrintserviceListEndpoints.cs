using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
/// </summary>
public partial class PrintServiceListEndpointsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrintServiceId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Services_PrintServiceId_Endpoints: return $"/print/services/{PrintServiceId}/endpoints";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Print_Services_PrintServiceId_Endpoints,
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
public partial class PrintServiceListEndpointsResponse : RestApiResponse<PrintServiceEndpoint>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintServiceListEndpointsResponse> PrintServiceListEndpointsAsync()
    {
        var p = new PrintServiceListEndpointsParameter();
        return await this.SendAsync<PrintServiceListEndpointsParameter, PrintServiceListEndpointsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintServiceListEndpointsResponse> PrintServiceListEndpointsAsync(CancellationToken cancellationToken)
    {
        var p = new PrintServiceListEndpointsParameter();
        return await this.SendAsync<PrintServiceListEndpointsParameter, PrintServiceListEndpointsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintServiceListEndpointsResponse> PrintServiceListEndpointsAsync(PrintServiceListEndpointsParameter parameter)
    {
        return await this.SendAsync<PrintServiceListEndpointsParameter, PrintServiceListEndpointsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintServiceListEndpointsResponse> PrintServiceListEndpointsAsync(PrintServiceListEndpointsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrintServiceListEndpointsParameter, PrintServiceListEndpointsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<PrintServiceEndpoint> PrintServiceListEndpointsEnumerateAsync(PrintServiceListEndpointsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<PrintServiceListEndpointsParameter, PrintServiceListEndpointsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<PrintServiceEndpoint>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
