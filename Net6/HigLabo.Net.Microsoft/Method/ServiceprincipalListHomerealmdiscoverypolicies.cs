using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalListHomerealmdiscoverypoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_HomeRealmDiscoveryPolicies: return $"/servicePrincipals/{Id}/homeRealmDiscoveryPolicies";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Definition,
            Description,
            DisplayName,
            Id,
            IsOrganizationDefault,
            AppliesTo,
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_HomeRealmDiscoveryPolicies,
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
    public partial class ServiceprincipalListHomerealmdiscoverypoliciesResponse : RestApiResponse
    {
        public HomeRealmDiscoveryPolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListHomerealmdiscoverypoliciesResponse> ServiceprincipalListHomerealmdiscoverypoliciesAsync()
        {
            var p = new ServiceprincipalListHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<ServiceprincipalListHomerealmdiscoverypoliciesParameter, ServiceprincipalListHomerealmdiscoverypoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListHomerealmdiscoverypoliciesResponse> ServiceprincipalListHomerealmdiscoverypoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<ServiceprincipalListHomerealmdiscoverypoliciesParameter, ServiceprincipalListHomerealmdiscoverypoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListHomerealmdiscoverypoliciesResponse> ServiceprincipalListHomerealmdiscoverypoliciesAsync(ServiceprincipalListHomerealmdiscoverypoliciesParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListHomerealmdiscoverypoliciesParameter, ServiceprincipalListHomerealmdiscoverypoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListHomerealmdiscoverypoliciesResponse> ServiceprincipalListHomerealmdiscoverypoliciesAsync(ServiceprincipalListHomerealmdiscoverypoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListHomerealmdiscoverypoliciesParameter, ServiceprincipalListHomerealmdiscoverypoliciesResponse>(parameter, cancellationToken);
        }
    }
}
