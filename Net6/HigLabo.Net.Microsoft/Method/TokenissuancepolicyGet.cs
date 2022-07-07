using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenissuancepolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_TokenIssuancePolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_TokenIssuancePolicies_Id: return $"/policies/tokenIssuancePolicies/{Id}";
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
    public partial class TokenissuancepolicyGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyGetResponse> TokenissuancepolicyGetAsync()
        {
            var p = new TokenissuancepolicyGetParameter();
            return await this.SendAsync<TokenissuancepolicyGetParameter, TokenissuancepolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyGetResponse> TokenissuancepolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new TokenissuancepolicyGetParameter();
            return await this.SendAsync<TokenissuancepolicyGetParameter, TokenissuancepolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyGetResponse> TokenissuancepolicyGetAsync(TokenissuancepolicyGetParameter parameter)
        {
            return await this.SendAsync<TokenissuancepolicyGetParameter, TokenissuancepolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyGetResponse> TokenissuancepolicyGetAsync(TokenissuancepolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenissuancepolicyGetParameter, TokenissuancepolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
