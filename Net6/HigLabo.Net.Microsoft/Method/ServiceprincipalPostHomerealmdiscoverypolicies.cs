using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalPostHomerealmdiscoverypoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id_HomeRealmDiscoveryPolicies_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_HomeRealmDiscoveryPolicies_ref: return $"/servicePrincipals/{Id}/homeRealmDiscoveryPolicies/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class ServiceprincipalPostHomerealmdiscoverypoliciesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostHomerealmdiscoverypoliciesResponse> ServiceprincipalPostHomerealmdiscoverypoliciesAsync()
        {
            var p = new ServiceprincipalPostHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<ServiceprincipalPostHomerealmdiscoverypoliciesParameter, ServiceprincipalPostHomerealmdiscoverypoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostHomerealmdiscoverypoliciesResponse> ServiceprincipalPostHomerealmdiscoverypoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalPostHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<ServiceprincipalPostHomerealmdiscoverypoliciesParameter, ServiceprincipalPostHomerealmdiscoverypoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostHomerealmdiscoverypoliciesResponse> ServiceprincipalPostHomerealmdiscoverypoliciesAsync(ServiceprincipalPostHomerealmdiscoverypoliciesParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalPostHomerealmdiscoverypoliciesParameter, ServiceprincipalPostHomerealmdiscoverypoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostHomerealmdiscoverypoliciesResponse> ServiceprincipalPostHomerealmdiscoverypoliciesAsync(ServiceprincipalPostHomerealmdiscoverypoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalPostHomerealmdiscoverypoliciesParameter, ServiceprincipalPostHomerealmdiscoverypoliciesResponse>(parameter, cancellationToken);
        }
    }
}
