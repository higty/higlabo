using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalListHomeRealmDiscoverypoliciesParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ServicePrincipalListHomeRealmDiscoverypoliciesResponse : RestApiResponse<HomeRealmDiscoveryPolicy>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListHomeRealmDiscoverypoliciesResponse> ServicePrincipalListHomeRealmDiscoverypoliciesAsync()
        {
            var p = new ServicePrincipalListHomeRealmDiscoverypoliciesParameter();
            return await this.SendAsync<ServicePrincipalListHomeRealmDiscoverypoliciesParameter, ServicePrincipalListHomeRealmDiscoverypoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListHomeRealmDiscoverypoliciesResponse> ServicePrincipalListHomeRealmDiscoverypoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalListHomeRealmDiscoverypoliciesParameter();
            return await this.SendAsync<ServicePrincipalListHomeRealmDiscoverypoliciesParameter, ServicePrincipalListHomeRealmDiscoverypoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListHomeRealmDiscoverypoliciesResponse> ServicePrincipalListHomeRealmDiscoverypoliciesAsync(ServicePrincipalListHomeRealmDiscoverypoliciesParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalListHomeRealmDiscoverypoliciesParameter, ServicePrincipalListHomeRealmDiscoverypoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListHomeRealmDiscoverypoliciesResponse> ServicePrincipalListHomeRealmDiscoverypoliciesAsync(ServicePrincipalListHomeRealmDiscoverypoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalListHomeRealmDiscoverypoliciesParameter, ServicePrincipalListHomeRealmDiscoverypoliciesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<HomeRealmDiscoveryPolicy> ServicePrincipalListHomeRealmDiscoverypoliciesEnumerateAsync(ServicePrincipalListHomeRealmDiscoverypoliciesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ServicePrincipalListHomeRealmDiscoverypoliciesParameter, ServicePrincipalListHomeRealmDiscoverypoliciesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<HomeRealmDiscoveryPolicy>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
