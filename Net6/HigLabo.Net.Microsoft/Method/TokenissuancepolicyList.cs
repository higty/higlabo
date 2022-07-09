using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenissuancePolicyListParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            Id,
            Definition,
            Description,
            DisplayName,
            IsOrganizationDefault,
            AppliesTo,
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class TokenissuancePolicyListResponse : RestApiResponse
    {
        public TokenIssuancePolicy[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyListResponse> TokenissuancePolicyListAsync()
        {
            var p = new TokenissuancePolicyListParameter();
            return await this.SendAsync<TokenissuancePolicyListParameter, TokenissuancePolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyListResponse> TokenissuancePolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new TokenissuancePolicyListParameter();
            return await this.SendAsync<TokenissuancePolicyListParameter, TokenissuancePolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyListResponse> TokenissuancePolicyListAsync(TokenissuancePolicyListParameter parameter)
        {
            return await this.SendAsync<TokenissuancePolicyListParameter, TokenissuancePolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancePolicyListResponse> TokenissuancePolicyListAsync(TokenissuancePolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenissuancePolicyListParameter, TokenissuancePolicyListResponse>(parameter, cancellationToken);
        }
    }
}
