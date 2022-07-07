using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListClaimsmappingpoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_ClaimsMappingPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_ClaimsMappingPolicies: return $"/servicePrincipals/{Id}/claimsMappingPolicies";
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
    public partial class ServiceprincipalListClaimsmappingpoliciesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/claimsmappingpolicy?view=graph-rest-1.0
        /// </summary>
        public partial class ClaimsMappingPolicy
        {
            public string? Id { get; set; }
            public String[]? Definition { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public bool? IsOrganizationDefault { get; set; }
        }

        public ClaimsMappingPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListClaimsmappingpoliciesResponse> ServiceprincipalListClaimsmappingpoliciesAsync()
        {
            var p = new ServiceprincipalListClaimsmappingpoliciesParameter();
            return await this.SendAsync<ServiceprincipalListClaimsmappingpoliciesParameter, ServiceprincipalListClaimsmappingpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListClaimsmappingpoliciesResponse> ServiceprincipalListClaimsmappingpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListClaimsmappingpoliciesParameter();
            return await this.SendAsync<ServiceprincipalListClaimsmappingpoliciesParameter, ServiceprincipalListClaimsmappingpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListClaimsmappingpoliciesResponse> ServiceprincipalListClaimsmappingpoliciesAsync(ServiceprincipalListClaimsmappingpoliciesParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListClaimsmappingpoliciesParameter, ServiceprincipalListClaimsmappingpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListClaimsmappingpoliciesResponse> ServiceprincipalListClaimsmappingpoliciesAsync(ServiceprincipalListClaimsmappingpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListClaimsmappingpoliciesParameter, ServiceprincipalListClaimsmappingpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
