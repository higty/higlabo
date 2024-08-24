using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalPostClaimsmappingpoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_ClaimsMappingPolicies_ref: return $"/servicePrincipals/{Id}/claimsMappingPolicies/$ref";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_ClaimsMappingPolicies_ref,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class ServicePrincipalPostClaimsmappingpoliciesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostClaimsmappingpoliciesResponse> ServicePrincipalPostClaimsmappingpoliciesAsync()
        {
            var p = new ServicePrincipalPostClaimsmappingpoliciesParameter();
            return await this.SendAsync<ServicePrincipalPostClaimsmappingpoliciesParameter, ServicePrincipalPostClaimsmappingpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostClaimsmappingpoliciesResponse> ServicePrincipalPostClaimsmappingpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalPostClaimsmappingpoliciesParameter();
            return await this.SendAsync<ServicePrincipalPostClaimsmappingpoliciesParameter, ServicePrincipalPostClaimsmappingpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostClaimsmappingpoliciesResponse> ServicePrincipalPostClaimsmappingpoliciesAsync(ServicePrincipalPostClaimsmappingpoliciesParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalPostClaimsmappingpoliciesParameter, ServicePrincipalPostClaimsmappingpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostClaimsmappingpoliciesResponse> ServicePrincipalPostClaimsmappingpoliciesAsync(ServicePrincipalPostClaimsmappingpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalPostClaimsmappingpoliciesParameter, ServicePrincipalPostClaimsmappingpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
