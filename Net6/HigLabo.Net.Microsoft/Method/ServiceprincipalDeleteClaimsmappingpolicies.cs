using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalDeleteClaimsmappingpoliciesParameter : IRestApiParameter
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
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_ClaimsMappingPolicies_Id_ref,
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
    public partial class ServiceprincipalDeleteClaimsmappingpoliciesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteClaimsmappingpoliciesResponse> ServiceprincipalDeleteClaimsmappingpoliciesAsync()
        {
            var p = new ServiceprincipalDeleteClaimsmappingpoliciesParameter();
            return await this.SendAsync<ServiceprincipalDeleteClaimsmappingpoliciesParameter, ServiceprincipalDeleteClaimsmappingpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteClaimsmappingpoliciesResponse> ServiceprincipalDeleteClaimsmappingpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeleteClaimsmappingpoliciesParameter();
            return await this.SendAsync<ServiceprincipalDeleteClaimsmappingpoliciesParameter, ServiceprincipalDeleteClaimsmappingpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteClaimsmappingpoliciesResponse> ServiceprincipalDeleteClaimsmappingpoliciesAsync(ServiceprincipalDeleteClaimsmappingpoliciesParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeleteClaimsmappingpoliciesParameter, ServiceprincipalDeleteClaimsmappingpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteClaimsmappingpoliciesResponse> ServiceprincipalDeleteClaimsmappingpoliciesAsync(ServiceprincipalDeleteClaimsmappingpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeleteClaimsmappingpoliciesParameter, ServiceprincipalDeleteClaimsmappingpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
