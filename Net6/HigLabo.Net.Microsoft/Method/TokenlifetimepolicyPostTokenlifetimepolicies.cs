using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenlifetimepolicyPostTokenlifetimepoliciesParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class TokenlifetimepolicyPostTokenlifetimepoliciesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyPostTokenlifetimepoliciesResponse> TokenlifetimepolicyPostTokenlifetimepoliciesAsync()
        {
            var p = new TokenlifetimepolicyPostTokenlifetimepoliciesParameter();
            return await this.SendAsync<TokenlifetimepolicyPostTokenlifetimepoliciesParameter, TokenlifetimepolicyPostTokenlifetimepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyPostTokenlifetimepoliciesResponse> TokenlifetimepolicyPostTokenlifetimepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimepolicyPostTokenlifetimepoliciesParameter();
            return await this.SendAsync<TokenlifetimepolicyPostTokenlifetimepoliciesParameter, TokenlifetimepolicyPostTokenlifetimepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyPostTokenlifetimepoliciesResponse> TokenlifetimepolicyPostTokenlifetimepoliciesAsync(TokenlifetimepolicyPostTokenlifetimepoliciesParameter parameter)
        {
            return await this.SendAsync<TokenlifetimepolicyPostTokenlifetimepoliciesParameter, TokenlifetimepolicyPostTokenlifetimepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyPostTokenlifetimepoliciesResponse> TokenlifetimepolicyPostTokenlifetimepoliciesAsync(TokenlifetimepolicyPostTokenlifetimepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimepolicyPostTokenlifetimepoliciesParameter, TokenlifetimepolicyPostTokenlifetimepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
