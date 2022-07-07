using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalPostClaimsmappingpoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id_ClaimsMappingPolicies_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_ClaimsMappingPolicies_ref: return $"/servicePrincipals/{Id}/claimsMappingPolicies/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class ServiceprincipalPostClaimsmappingpoliciesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostClaimsmappingpoliciesResponse> ServiceprincipalPostClaimsmappingpoliciesAsync()
        {
            var p = new ServiceprincipalPostClaimsmappingpoliciesParameter();
            return await this.SendAsync<ServiceprincipalPostClaimsmappingpoliciesParameter, ServiceprincipalPostClaimsmappingpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostClaimsmappingpoliciesResponse> ServiceprincipalPostClaimsmappingpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalPostClaimsmappingpoliciesParameter();
            return await this.SendAsync<ServiceprincipalPostClaimsmappingpoliciesParameter, ServiceprincipalPostClaimsmappingpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostClaimsmappingpoliciesResponse> ServiceprincipalPostClaimsmappingpoliciesAsync(ServiceprincipalPostClaimsmappingpoliciesParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalPostClaimsmappingpoliciesParameter, ServiceprincipalPostClaimsmappingpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostClaimsmappingpoliciesResponse> ServiceprincipalPostClaimsmappingpoliciesAsync(ServiceprincipalPostClaimsmappingpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalPostClaimsmappingpoliciesParameter, ServiceprincipalPostClaimsmappingpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
