using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenlifetimePolicyPostTokenlifetimepoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Olicies_TokenLifetimePolicies: return $"/olicies/tokenLifetimePolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Olicies_TokenLifetimePolicies,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    public partial class TokenlifetimePolicyPostTokenlifetimepoliciesResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyPostTokenlifetimepoliciesResponse> TokenlifetimePolicyPostTokenlifetimepoliciesAsync()
        {
            var p = new TokenlifetimePolicyPostTokenlifetimepoliciesParameter();
            return await this.SendAsync<TokenlifetimePolicyPostTokenlifetimepoliciesParameter, TokenlifetimePolicyPostTokenlifetimepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyPostTokenlifetimepoliciesResponse> TokenlifetimePolicyPostTokenlifetimepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimePolicyPostTokenlifetimepoliciesParameter();
            return await this.SendAsync<TokenlifetimePolicyPostTokenlifetimepoliciesParameter, TokenlifetimePolicyPostTokenlifetimepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyPostTokenlifetimepoliciesResponse> TokenlifetimePolicyPostTokenlifetimepoliciesAsync(TokenlifetimePolicyPostTokenlifetimepoliciesParameter parameter)
        {
            return await this.SendAsync<TokenlifetimePolicyPostTokenlifetimepoliciesParameter, TokenlifetimePolicyPostTokenlifetimepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-post-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyPostTokenlifetimepoliciesResponse> TokenlifetimePolicyPostTokenlifetimepoliciesAsync(TokenlifetimePolicyPostTokenlifetimepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimePolicyPostTokenlifetimepoliciesParameter, TokenlifetimePolicyPostTokenlifetimepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
