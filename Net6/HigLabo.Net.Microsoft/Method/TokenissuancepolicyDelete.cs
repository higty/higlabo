using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenissuancePolicyDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class TokenissuancePolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyDeleteResponse> TokenissuancePolicyDeleteAsync()
        {
            var p = new TokenissuancePolicyDeleteParameter();
            return await this.SendAsync<TokenissuancePolicyDeleteParameter, TokenissuancePolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyDeleteResponse> TokenissuancePolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TokenissuancePolicyDeleteParameter();
            return await this.SendAsync<TokenissuancePolicyDeleteParameter, TokenissuancePolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyDeleteResponse> TokenissuancePolicyDeleteAsync(TokenissuancePolicyDeleteParameter parameter)
        {
            return await this.SendAsync<TokenissuancePolicyDeleteParameter, TokenissuancePolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyDeleteResponse> TokenissuancePolicyDeleteAsync(TokenissuancePolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenissuancePolicyDeleteParameter, TokenissuancePolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
