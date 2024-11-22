using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        ServicePrincipals,
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
public partial class ServicePrincipalListResponse : RestApiResponse<ServicePrincipal>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListResponse> ServicePrincipalListAsync()
    {
        var p = new ServicePrincipalListParameter();
        return await this.SendAsync<ServicePrincipalListParameter, ServicePrincipalListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListResponse> ServicePrincipalListAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalListParameter();
        return await this.SendAsync<ServicePrincipalListParameter, ServicePrincipalListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListResponse> ServicePrincipalListAsync(ServicePrincipalListParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalListParameter, ServicePrincipalListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListResponse> ServicePrincipalListAsync(ServicePrincipalListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalListParameter, ServicePrincipalListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ServicePrincipal> ServicePrincipalListEnumerateAsync(ServicePrincipalListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServicePrincipalListParameter, ServicePrincipalListResponse>(parameter, cancellationToken);
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
