using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenlifetimepolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_TokenLifetimePolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_TokenLifetimePolicies_Id: return $"/policies/tokenLifetimePolicies/{Id}";
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
    public partial class TokenlifetimepolicyGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyGetResponse> TokenlifetimepolicyGetAsync()
        {
            var p = new TokenlifetimepolicyGetParameter();
            return await this.SendAsync<TokenlifetimepolicyGetParameter, TokenlifetimepolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyGetResponse> TokenlifetimepolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimepolicyGetParameter();
            return await this.SendAsync<TokenlifetimepolicyGetParameter, TokenlifetimepolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyGetResponse> TokenlifetimepolicyGetAsync(TokenlifetimepolicyGetParameter parameter)
        {
            return await this.SendAsync<TokenlifetimepolicyGetParameter, TokenlifetimepolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyGetResponse> TokenlifetimepolicyGetAsync(TokenlifetimepolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimepolicyGetParameter, TokenlifetimepolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
