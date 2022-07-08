using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalPostClaimsmappingpoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_ClaimsMappingPolicies_ref: return $"/servicePrincipals/{Id}/claimsMappingPolicies/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_ClaimsMappingPolicies_ref,
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
