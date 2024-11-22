using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalListClaimsmappingpoliciesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Id_ClaimsMappingPolicies: return $"/servicePrincipals/{Id}/claimsMappingPolicies";
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
        ServicePrincipals_Id_ClaimsMappingPolicies,
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
public partial class ServicePrincipalListClaimsmappingpoliciesResponse : RestApiResponse<ClaimsMappingPolicy>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListClaimsmappingpoliciesResponse> ServicePrincipalListClaimsmappingpoliciesAsync()
    {
        var p = new ServicePrincipalListClaimsmappingpoliciesParameter();
        return await this.SendAsync<ServicePrincipalListClaimsmappingpoliciesParameter, ServicePrincipalListClaimsmappingpoliciesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListClaimsmappingpoliciesResponse> ServicePrincipalListClaimsmappingpoliciesAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalListClaimsmappingpoliciesParameter();
        return await this.SendAsync<ServicePrincipalListClaimsmappingpoliciesParameter, ServicePrincipalListClaimsmappingpoliciesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListClaimsmappingpoliciesResponse> ServicePrincipalListClaimsmappingpoliciesAsync(ServicePrincipalListClaimsmappingpoliciesParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalListClaimsmappingpoliciesParameter, ServicePrincipalListClaimsmappingpoliciesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListClaimsmappingpoliciesResponse> ServicePrincipalListClaimsmappingpoliciesAsync(ServicePrincipalListClaimsmappingpoliciesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalListClaimsmappingpoliciesParameter, ServicePrincipalListClaimsmappingpoliciesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ClaimsMappingPolicy> ServicePrincipalListClaimsmappingpoliciesEnumerateAsync(ServicePrincipalListClaimsmappingpoliciesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServicePrincipalListClaimsmappingpoliciesParameter, ServicePrincipalListClaimsmappingpoliciesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ClaimsMappingPolicy>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
