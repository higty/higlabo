using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class HomerealmdiscoverypolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_HomeRealmDiscoveryPolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_HomeRealmDiscoveryPolicies_Id: return $"/policies/homeRealmDiscoveryPolicies/{Id}";
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
    public partial class HomerealmdiscoverypolicyGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyGetResponse> HomerealmdiscoverypolicyGetAsync()
        {
            var p = new HomerealmdiscoverypolicyGetParameter();
            return await this.SendAsync<HomerealmdiscoverypolicyGetParameter, HomerealmdiscoverypolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyGetResponse> HomerealmdiscoverypolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoverypolicyGetParameter();
            return await this.SendAsync<HomerealmdiscoverypolicyGetParameter, HomerealmdiscoverypolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyGetResponse> HomerealmdiscoverypolicyGetAsync(HomerealmdiscoverypolicyGetParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoverypolicyGetParameter, HomerealmdiscoverypolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyGetResponse> HomerealmdiscoverypolicyGetAsync(HomerealmdiscoverypolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoverypolicyGetParameter, HomerealmdiscoverypolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
