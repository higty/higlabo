using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class HomerealmdiscoverypolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_HomeRealmDiscoveryPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_HomeRealmDiscoveryPolicies: return $"/policies/homeRealmDiscoveryPolicies";
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
    }
    public partial class HomerealmdiscoverypolicyListResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyListResponse> HomerealmdiscoverypolicyListAsync()
        {
            var p = new HomerealmdiscoverypolicyListParameter();
            return await this.SendAsync<HomerealmdiscoverypolicyListParameter, HomerealmdiscoverypolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyListResponse> HomerealmdiscoverypolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoverypolicyListParameter();
            return await this.SendAsync<HomerealmdiscoverypolicyListParameter, HomerealmdiscoverypolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyListResponse> HomerealmdiscoverypolicyListAsync(HomerealmdiscoverypolicyListParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoverypolicyListParameter, HomerealmdiscoverypolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyListResponse> HomerealmdiscoverypolicyListAsync(HomerealmdiscoverypolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoverypolicyListParameter, HomerealmdiscoverypolicyListResponse>(parameter, cancellationToken);
        }
    }
}
