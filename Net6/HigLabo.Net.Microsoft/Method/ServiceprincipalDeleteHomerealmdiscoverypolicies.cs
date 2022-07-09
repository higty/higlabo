using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalDeleteHomerealmdiscoverypoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ServicePrincipalsId { get; set; }
            public string? HomeRealmDiscoveryPoliciesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_HomeRealmDiscoveryPolicies_Id_ref: return $"/servicePrincipals/{ServicePrincipalsId}/homeRealmDiscoveryPolicies/{HomeRealmDiscoveryPoliciesId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_HomeRealmDiscoveryPolicies_Id_ref,
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
