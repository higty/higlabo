using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalDeleteHomeRealmDiscoverypoliciesParameter : IRestApiParameter
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
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_HomeRealmDiscoveryPolicies_Id_ref,
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
    public partial class ServicePrincipalDeleteHomeRealmDiscoverypoliciesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalDeleteHomeRealmDiscoverypoliciesResponse> ServicePrincipalDeleteHomeRealmDiscoverypoliciesAsync()
        {
            var p = new ServicePrincipalDeleteHomeRealmDiscoverypoliciesParameter();
            return await this.SendAsync<ServicePrincipalDeleteHomeRealmDiscoverypoliciesParameter, ServicePrincipalDeleteHomeRealmDiscoverypoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalDeleteHomeRealmDiscoverypoliciesResponse> ServicePrincipalDeleteHomeRealmDiscoverypoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalDeleteHomeRealmDiscoverypoliciesParameter();
            return await this.SendAsync<ServicePrincipalDeleteHomeRealmDiscoverypoliciesParameter, ServicePrincipalDeleteHomeRealmDiscoverypoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalDeleteHomeRealmDiscoverypoliciesResponse> ServicePrincipalDeleteHomeRealmDiscoverypoliciesAsync(ServicePrincipalDeleteHomeRealmDiscoverypoliciesParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalDeleteHomeRealmDiscoverypoliciesParameter, ServicePrincipalDeleteHomeRealmDiscoverypoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalDeleteHomeRealmDiscoverypoliciesResponse> ServicePrincipalDeleteHomeRealmDiscoverypoliciesAsync(ServicePrincipalDeleteHomeRealmDiscoverypoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalDeleteHomeRealmDiscoverypoliciesParameter, ServicePrincipalDeleteHomeRealmDiscoverypoliciesResponse>(parameter, cancellationToken);
        }
    }
}
