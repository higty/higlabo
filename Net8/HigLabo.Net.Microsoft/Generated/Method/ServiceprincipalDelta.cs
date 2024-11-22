using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Delta: return $"/servicePrincipals/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        ServicePrincipals_Delta,
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
public partial class ServicePrincipalDeltaResponse : RestApiResponse<ServicePrincipal>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeltaResponse> ServicePrincipalDeltaAsync()
    {
        var p = new ServicePrincipalDeltaParameter();
        return await this.SendAsync<ServicePrincipalDeltaParameter, ServicePrincipalDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeltaResponse> ServicePrincipalDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalDeltaParameter();
        return await this.SendAsync<ServicePrincipalDeltaParameter, ServicePrincipalDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeltaResponse> ServicePrincipalDeltaAsync(ServicePrincipalDeltaParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalDeltaParameter, ServicePrincipalDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeltaResponse> ServicePrincipalDeltaAsync(ServicePrincipalDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalDeltaParameter, ServicePrincipalDeltaResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ServicePrincipal> ServicePrincipalDeltaEnumerateAsync(ServicePrincipalDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServicePrincipalDeltaParameter, ServicePrincipalDeltaResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ServicePrincipal>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
