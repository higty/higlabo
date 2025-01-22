using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
/// </summary>
public partial class SecurityListAlertsV2Parameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Alerts_v2: return $"/security/alerts_v2";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_Alerts_v2,
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
public partial class SecurityListAlertsV2Response : RestApiResponse<SecurityAlert>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityListAlertsV2Response> SecurityListAlertsV2Async()
    {
        var p = new SecurityListAlertsV2Parameter();
        return await this.SendAsync<SecurityListAlertsV2Parameter, SecurityListAlertsV2Response>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityListAlertsV2Response> SecurityListAlertsV2Async(CancellationToken cancellationToken)
    {
        var p = new SecurityListAlertsV2Parameter();
        return await this.SendAsync<SecurityListAlertsV2Parameter, SecurityListAlertsV2Response>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityListAlertsV2Response> SecurityListAlertsV2Async(SecurityListAlertsV2Parameter parameter)
    {
        return await this.SendAsync<SecurityListAlertsV2Parameter, SecurityListAlertsV2Response>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityListAlertsV2Response> SecurityListAlertsV2Async(SecurityListAlertsV2Parameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityListAlertsV2Parameter, SecurityListAlertsV2Response>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<SecurityAlert> SecurityListAlertsV2EnumerateAsync(SecurityListAlertsV2Parameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SecurityListAlertsV2Parameter, SecurityListAlertsV2Response>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<SecurityAlert>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
