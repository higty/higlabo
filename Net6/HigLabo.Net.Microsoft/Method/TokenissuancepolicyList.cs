using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenissuancepolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Olicies_TokenIssuancePolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Olicies_TokenIssuancePolicies: return $"/olicies/tokenIssuancePolicies";
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
    public partial class TokenissuancepolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/tokenissuancepolicy?view=graph-rest-1.0
        /// </summary>
        public partial class TokenIssuancePolicy
        {
            public string? Id { get; set; }
            public String[]? Definition { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public bool? IsOrganizationDefault { get; set; }
        }

        public TokenIssuancePolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyListResponse> TokenissuancepolicyListAsync()
        {
            var p = new TokenissuancepolicyListParameter();
            return await this.SendAsync<TokenissuancepolicyListParameter, TokenissuancepolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyListResponse> TokenissuancepolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new TokenissuancepolicyListParameter();
            return await this.SendAsync<TokenissuancepolicyListParameter, TokenissuancepolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyListResponse> TokenissuancepolicyListAsync(TokenissuancepolicyListParameter parameter)
        {
            return await this.SendAsync<TokenissuancepolicyListParameter, TokenissuancepolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyListResponse> TokenissuancepolicyListAsync(TokenissuancepolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenissuancepolicyListParameter, TokenissuancepolicyListResponse>(parameter, cancellationToken);
        }
    }
}
