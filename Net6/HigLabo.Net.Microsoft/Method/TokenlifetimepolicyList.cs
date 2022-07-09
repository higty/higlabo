using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenlifetimePolicyListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class TokenlifetimePolicyListResponse : RestApiResponse
    {
        public TokenLifetimePolicy[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyListResponse> TokenlifetimePolicyListAsync()
        {
            var p = new TokenlifetimePolicyListParameter();
            return await this.SendAsync<TokenlifetimePolicyListParameter, TokenlifetimePolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyListResponse> TokenlifetimePolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimePolicyListParameter();
            return await this.SendAsync<TokenlifetimePolicyListParameter, TokenlifetimePolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyListResponse> TokenlifetimePolicyListAsync(TokenlifetimePolicyListParameter parameter)
        {
            return await this.SendAsync<TokenlifetimePolicyListParameter, TokenlifetimePolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyListResponse> TokenlifetimePolicyListAsync(TokenlifetimePolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimePolicyListParameter, TokenlifetimePolicyListResponse>(parameter, cancellationToken);
        }
    }
}
