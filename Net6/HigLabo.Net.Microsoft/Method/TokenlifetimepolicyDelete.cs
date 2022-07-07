using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenlifetimepolicyDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class TokenlifetimepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyDeleteResponse> TokenlifetimepolicyDeleteAsync()
        {
            var p = new TokenlifetimepolicyDeleteParameter();
            return await this.SendAsync<TokenlifetimepolicyDeleteParameter, TokenlifetimepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyDeleteResponse> TokenlifetimepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimepolicyDeleteParameter();
            return await this.SendAsync<TokenlifetimepolicyDeleteParameter, TokenlifetimepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyDeleteResponse> TokenlifetimepolicyDeleteAsync(TokenlifetimepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<TokenlifetimepolicyDeleteParameter, TokenlifetimepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyDeleteResponse> TokenlifetimepolicyDeleteAsync(TokenlifetimepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimepolicyDeleteParameter, TokenlifetimepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
