using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class TokenissuancePolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_TokenIssuancePolicies_Id: return $"/policies/tokenIssuancePolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_TokenIssuancePolicies_Id,
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
    public partial class TokenissuancePolicyUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyUpdateResponse> TokenissuancePolicyUpdateAsync()
        {
            var p = new TokenissuancePolicyUpdateParameter();
            return await this.SendAsync<TokenissuancePolicyUpdateParameter, TokenissuancePolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyUpdateResponse> TokenissuancePolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TokenissuancePolicyUpdateParameter();
            return await this.SendAsync<TokenissuancePolicyUpdateParameter, TokenissuancePolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyUpdateResponse> TokenissuancePolicyUpdateAsync(TokenissuancePolicyUpdateParameter parameter)
        {
            return await this.SendAsync<TokenissuancePolicyUpdateParameter, TokenissuancePolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyUpdateResponse> TokenissuancePolicyUpdateAsync(TokenissuancePolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenissuancePolicyUpdateParameter, TokenissuancePolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
