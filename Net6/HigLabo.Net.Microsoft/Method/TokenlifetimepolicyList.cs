using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenlifetimepolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Olicies_TokenLifetimePolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Olicies_TokenLifetimePolicies: return $"/olicies/tokenLifetimePolicies";
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
    public partial class TokenlifetimepolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/tokenlifetimepolicy?view=graph-rest-1.0
        /// </summary>
        public partial class TokenLifetimePolicy
        {
            public string? Id { get; set; }
            public String[]? Definition { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public bool? IsOrganizationDefault { get; set; }
        }

        public TokenLifetimePolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyListResponse> TokenlifetimepolicyListAsync()
        {
            var p = new TokenlifetimepolicyListParameter();
            return await this.SendAsync<TokenlifetimepolicyListParameter, TokenlifetimepolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyListResponse> TokenlifetimepolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimepolicyListParameter();
            return await this.SendAsync<TokenlifetimepolicyListParameter, TokenlifetimepolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyListResponse> TokenlifetimepolicyListAsync(TokenlifetimepolicyListParameter parameter)
        {
            return await this.SendAsync<TokenlifetimepolicyListParameter, TokenlifetimepolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyListResponse> TokenlifetimepolicyListAsync(TokenlifetimepolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimepolicyListParameter, TokenlifetimepolicyListResponse>(parameter, cancellationToken);
        }
    }
}
