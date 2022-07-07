using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenissuancepolicyPostTokenissuancepolicyParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class TokenissuancepolicyPostTokenissuancepolicyResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-post-tokenissuancepolicy?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyPostTokenissuancepolicyResponse> TokenissuancepolicyPostTokenissuancepolicyAsync()
        {
            var p = new TokenissuancepolicyPostTokenissuancepolicyParameter();
            return await this.SendAsync<TokenissuancepolicyPostTokenissuancepolicyParameter, TokenissuancepolicyPostTokenissuancepolicyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-post-tokenissuancepolicy?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyPostTokenissuancepolicyResponse> TokenissuancepolicyPostTokenissuancepolicyAsync(CancellationToken cancellationToken)
        {
            var p = new TokenissuancepolicyPostTokenissuancepolicyParameter();
            return await this.SendAsync<TokenissuancepolicyPostTokenissuancepolicyParameter, TokenissuancepolicyPostTokenissuancepolicyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-post-tokenissuancepolicy?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyPostTokenissuancepolicyResponse> TokenissuancepolicyPostTokenissuancepolicyAsync(TokenissuancepolicyPostTokenissuancepolicyParameter parameter)
        {
            return await this.SendAsync<TokenissuancepolicyPostTokenissuancepolicyParameter, TokenissuancepolicyPostTokenissuancepolicyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-post-tokenissuancepolicy?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyPostTokenissuancepolicyResponse> TokenissuancepolicyPostTokenissuancepolicyAsync(TokenissuancepolicyPostTokenissuancepolicyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenissuancepolicyPostTokenissuancepolicyParameter, TokenissuancepolicyPostTokenissuancepolicyResponse>(parameter, cancellationToken);
        }
    }
}
