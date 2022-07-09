using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
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
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            Definition,
            Description,
            DisplayName,
            IsOrganizationDefault,
            AppliesTo,
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_HomeRealmDiscoveryPolicies,
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
