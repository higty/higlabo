using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListHomerealmdiscoverypoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_HomeRealmDiscoveryPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_HomeRealmDiscoveryPolicies: return $"/servicePrincipals/{Id}/homeRealmDiscoveryPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
    }
    public partial class ServiceprincipalListHomerealmdiscoverypoliciesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/homerealmdiscoverypolicy?view=graph-rest-1.0
        /// </summary>
        public partial class HomeRealmDiscoveryPolicy
        {
            public string? Id { get; set; }
            public String[]? Definition { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public bool? IsOrganizationDefault { get; set; }
        }

        public HomeRealmDiscoveryPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListHomerealmdiscoverypoliciesResponse> ServiceprincipalListHomerealmdiscoverypoliciesAsync()
        {
            var p = new ServiceprincipalListHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<ServiceprincipalListHomerealmdiscoverypoliciesParameter, ServiceprincipalListHomerealmdiscoverypoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListHomerealmdiscoverypoliciesResponse> ServiceprincipalListHomerealmdiscoverypoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<ServiceprincipalListHomerealmdiscoverypoliciesParameter, ServiceprincipalListHomerealmdiscoverypoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListHomerealmdiscoverypoliciesResponse> ServiceprincipalListHomerealmdiscoverypoliciesAsync(ServiceprincipalListHomerealmdiscoverypoliciesParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListHomerealmdiscoverypoliciesParameter, ServiceprincipalListHomerealmdiscoverypoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListHomerealmdiscoverypoliciesResponse> ServiceprincipalListHomerealmdiscoverypoliciesAsync(ServiceprincipalListHomerealmdiscoverypoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListHomerealmdiscoverypoliciesParameter, ServiceprincipalListHomerealmdiscoverypoliciesResponse>(parameter, cancellationToken);
        }
    }
}
