using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-claimsmappingpolicies?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalDeleteClaimsmappingpoliciesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ServicePrincipalsId { get; set; }
        public string? ClaimsMappingPoliciesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Id_ClaimsMappingPolicies_Id_ref: return $"/servicePrincipals/{ServicePrincipalsId}/claimsMappingPolicies/{ClaimsMappingPoliciesId}/$ref";
                case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        ServicePrincipals_Id_ClaimsMappingPolicies_Id_ref,
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
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class ServicePrincipalDeleteClaimsmappingpoliciesResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-claimsmappingpolicies?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteClaimsmappingpoliciesResponse> ServicePrincipalDeleteClaimsmappingpoliciesAsync()
    {
        var p = new ServicePrincipalDeleteClaimsmappingpoliciesParameter();
        return await this.SendAsync<ServicePrincipalDeleteClaimsmappingpoliciesParameter, ServicePrincipalDeleteClaimsmappingpoliciesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteClaimsmappingpoliciesResponse> ServicePrincipalDeleteClaimsmappingpoliciesAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalDeleteClaimsmappingpoliciesParameter();
        return await this.SendAsync<ServicePrincipalDeleteClaimsmappingpoliciesParameter, ServicePrincipalDeleteClaimsmappingpoliciesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteClaimsmappingpoliciesResponse> ServicePrincipalDeleteClaimsmappingpoliciesAsync(ServicePrincipalDeleteClaimsmappingpoliciesParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalDeleteClaimsmappingpoliciesParameter, ServicePrincipalDeleteClaimsmappingpoliciesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteClaimsmappingpoliciesResponse> ServicePrincipalDeleteClaimsmappingpoliciesAsync(ServicePrincipalDeleteClaimsmappingpoliciesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalDeleteClaimsmappingpoliciesParameter, ServicePrincipalDeleteClaimsmappingpoliciesResponse>(parameter, cancellationToken);
    }
}
