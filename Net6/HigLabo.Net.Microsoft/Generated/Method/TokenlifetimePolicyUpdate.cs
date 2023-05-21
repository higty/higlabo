using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class TokenlifetimePolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_TokenLifetimePolicies_Id: return $"/policies/tokenLifetimePolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_TokenLifetimePolicies_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
    }
    public partial class TokenlifetimePolicyUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyUpdateResponse> TokenlifetimePolicyUpdateAsync()
        {
            var p = new TokenlifetimePolicyUpdateParameter();
            return await this.SendAsync<TokenlifetimePolicyUpdateParameter, TokenlifetimePolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyUpdateResponse> TokenlifetimePolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimePolicyUpdateParameter();
            return await this.SendAsync<TokenlifetimePolicyUpdateParameter, TokenlifetimePolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyUpdateResponse> TokenlifetimePolicyUpdateAsync(TokenlifetimePolicyUpdateParameter parameter)
        {
            return await this.SendAsync<TokenlifetimePolicyUpdateParameter, TokenlifetimePolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyUpdateResponse> TokenlifetimePolicyUpdateAsync(TokenlifetimePolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimePolicyUpdateParameter, TokenlifetimePolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
