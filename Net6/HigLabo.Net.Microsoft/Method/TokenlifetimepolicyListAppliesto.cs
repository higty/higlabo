using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenlifetimePolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_TokenLifetimePolicies_Id_AppliesTo: return $"/policies/tokenLifetimePolicies/{Id}/appliesTo";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DeletedDateTime,
            Id,
        }
        public enum ApiPath
        {
            Policies_TokenLifetimePolicies_Id_AppliesTo,
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
    public partial class TokenlifetimePolicyListAppliestoResponse : RestApiResponse
    {
        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyListAppliestoResponse> TokenlifetimePolicyListAppliestoAsync()
        {
            var p = new TokenlifetimePolicyListAppliestoParameter();
            return await this.SendAsync<TokenlifetimePolicyListAppliestoParameter, TokenlifetimePolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyListAppliestoResponse> TokenlifetimePolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimePolicyListAppliestoParameter();
            return await this.SendAsync<TokenlifetimePolicyListAppliestoParameter, TokenlifetimePolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyListAppliestoResponse> TokenlifetimePolicyListAppliestoAsync(TokenlifetimePolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<TokenlifetimePolicyListAppliestoParameter, TokenlifetimePolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimePolicyListAppliestoResponse> TokenlifetimePolicyListAppliestoAsync(TokenlifetimePolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimePolicyListAppliestoParameter, TokenlifetimePolicyListAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
