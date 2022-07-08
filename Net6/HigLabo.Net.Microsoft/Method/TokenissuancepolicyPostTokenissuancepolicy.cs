using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenissuancePolicyPostTokenissuancePolicyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Olicies_TokenIssuancePolicies: return $"/olicies/tokenIssuancePolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Olicies_TokenIssuancePolicies,
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
    public partial class TokenissuancePolicyPostTokenissuancePolicyResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-post-tokenissuancepolicy?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyPostTokenissuancePolicyResponse> TokenissuancePolicyPostTokenissuancePolicyAsync()
        {
            var p = new TokenissuancePolicyPostTokenissuancePolicyParameter();
            return await this.SendAsync<TokenissuancePolicyPostTokenissuancePolicyParameter, TokenissuancePolicyPostTokenissuancePolicyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-post-tokenissuancepolicy?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyPostTokenissuancePolicyResponse> TokenissuancePolicyPostTokenissuancePolicyAsync(CancellationToken cancellationToken)
        {
            var p = new TokenissuancePolicyPostTokenissuancePolicyParameter();
            return await this.SendAsync<TokenissuancePolicyPostTokenissuancePolicyParameter, TokenissuancePolicyPostTokenissuancePolicyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-post-tokenissuancepolicy?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyPostTokenissuancePolicyResponse> TokenissuancePolicyPostTokenissuancePolicyAsync(TokenissuancePolicyPostTokenissuancePolicyParameter parameter)
        {
            return await this.SendAsync<TokenissuancePolicyPostTokenissuancePolicyParameter, TokenissuancePolicyPostTokenissuancePolicyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-post-tokenissuancepolicy?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyPostTokenissuancePolicyResponse> TokenissuancePolicyPostTokenissuancePolicyAsync(TokenissuancePolicyPostTokenissuancePolicyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenissuancePolicyPostTokenissuancePolicyParameter, TokenissuancePolicyPostTokenissuancePolicyResponse>(parameter, cancellationToken);
        }
    }
}
