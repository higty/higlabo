using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalDeleteHomerealmdiscoverypoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id_HomeRealmDiscoveryPolicies_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_HomeRealmDiscoveryPolicies_Id_ref: return $"/servicePrincipals/{ServicePrincipalsId}/homeRealmDiscoveryPolicies/{HomeRealmDiscoveryPoliciesId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ServicePrincipalsId { get; set; }
        public string HomeRealmDiscoveryPoliciesId { get; set; }
    }
    public partial class ServiceprincipalDeleteHomerealmdiscoverypoliciesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteHomerealmdiscoverypoliciesResponse> ServiceprincipalDeleteHomerealmdiscoverypoliciesAsync()
        {
            var p = new ServiceprincipalDeleteHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<ServiceprincipalDeleteHomerealmdiscoverypoliciesParameter, ServiceprincipalDeleteHomerealmdiscoverypoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteHomerealmdiscoverypoliciesResponse> ServiceprincipalDeleteHomerealmdiscoverypoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeleteHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<ServiceprincipalDeleteHomerealmdiscoverypoliciesParameter, ServiceprincipalDeleteHomerealmdiscoverypoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteHomerealmdiscoverypoliciesResponse> ServiceprincipalDeleteHomerealmdiscoverypoliciesAsync(ServiceprincipalDeleteHomerealmdiscoverypoliciesParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeleteHomerealmdiscoverypoliciesParameter, ServiceprincipalDeleteHomerealmdiscoverypoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteHomerealmdiscoverypoliciesResponse> ServiceprincipalDeleteHomerealmdiscoverypoliciesAsync(ServiceprincipalDeleteHomerealmdiscoverypoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeleteHomerealmdiscoverypoliciesParameter, ServiceprincipalDeleteHomerealmdiscoverypoliciesResponse>(parameter, cancellationToken);
        }
    }
}
