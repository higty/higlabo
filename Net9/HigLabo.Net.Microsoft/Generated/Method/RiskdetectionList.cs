using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
/// </summary>
public partial class RiskdetectionListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityProtection_RiskDetections: return $"/identityProtection/riskDetections";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityProtection_RiskDetections,
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
public partial class RiskdetectionListResponse : RestApiResponse<RiskDetection>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RiskdetectionListResponse> RiskdetectionListAsync()
    {
        var p = new RiskdetectionListParameter();
        return await this.SendAsync<RiskdetectionListParameter, RiskdetectionListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RiskdetectionListResponse> RiskdetectionListAsync(CancellationToken cancellationToken)
    {
        var p = new RiskdetectionListParameter();
        return await this.SendAsync<RiskdetectionListParameter, RiskdetectionListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RiskdetectionListResponse> RiskdetectionListAsync(RiskdetectionListParameter parameter)
    {
        return await this.SendAsync<RiskdetectionListParameter, RiskdetectionListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RiskdetectionListResponse> RiskdetectionListAsync(RiskdetectionListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<RiskdetectionListParameter, RiskdetectionListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskdetection-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<RiskDetection> RiskdetectionListEnumerateAsync(RiskdetectionListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<RiskdetectionListParameter, RiskdetectionListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<RiskDetection>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
