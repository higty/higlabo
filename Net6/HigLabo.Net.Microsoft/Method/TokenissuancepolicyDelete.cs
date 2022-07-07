using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenissuancepolicyDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class TokenissuancepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyDeleteResponse> TokenissuancepolicyDeleteAsync()
        {
            var p = new TokenissuancepolicyDeleteParameter();
            return await this.SendAsync<TokenissuancepolicyDeleteParameter, TokenissuancepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyDeleteResponse> TokenissuancepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TokenissuancepolicyDeleteParameter();
            return await this.SendAsync<TokenissuancepolicyDeleteParameter, TokenissuancepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyDeleteResponse> TokenissuancepolicyDeleteAsync(TokenissuancepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<TokenissuancepolicyDeleteParameter, TokenissuancepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyDeleteResponse> TokenissuancepolicyDeleteAsync(TokenissuancepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenissuancepolicyDeleteParameter, TokenissuancepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
