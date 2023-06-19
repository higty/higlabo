using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class TokenlifetimePolicyGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class TokenlifetimePolicyGetResponse : RestApiResponse
    {
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenlifetimePolicyGetResponse> TokenlifetimePolicyGetAsync()
        {
            var p = new TokenlifetimePolicyGetParameter();
            return await this.SendAsync<TokenlifetimePolicyGetParameter, TokenlifetimePolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenlifetimePolicyGetResponse> TokenlifetimePolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimePolicyGetParameter();
            return await this.SendAsync<TokenlifetimePolicyGetParameter, TokenlifetimePolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenlifetimePolicyGetResponse> TokenlifetimePolicyGetAsync(TokenlifetimePolicyGetParameter parameter)
        {
            return await this.SendAsync<TokenlifetimePolicyGetParameter, TokenlifetimePolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenlifetimePolicyGetResponse> TokenlifetimePolicyGetAsync(TokenlifetimePolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimePolicyGetParameter, TokenlifetimePolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
