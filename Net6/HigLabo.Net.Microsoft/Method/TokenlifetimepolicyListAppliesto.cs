using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenlifetimepolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_TokenLifetimePolicies_Id_AppliesTo,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_TokenLifetimePolicies_Id_AppliesTo: return $"/policies/tokenLifetimePolicies/{Id}/appliesTo";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
    }
    public partial class TokenlifetimepolicyListAppliestoResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryobject?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryObject
        {
            public DateTimeOffset? DeletedDateTime { get; set; }
            public string? Id { get; set; }
        }

        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyListAppliestoResponse> TokenlifetimepolicyListAppliestoAsync()
        {
            var p = new TokenlifetimepolicyListAppliestoParameter();
            return await this.SendAsync<TokenlifetimepolicyListAppliestoParameter, TokenlifetimepolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyListAppliestoResponse> TokenlifetimepolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimepolicyListAppliestoParameter();
            return await this.SendAsync<TokenlifetimepolicyListAppliestoParameter, TokenlifetimepolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyListAppliestoResponse> TokenlifetimepolicyListAppliestoAsync(TokenlifetimepolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<TokenlifetimepolicyListAppliestoParameter, TokenlifetimepolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenlifetimepolicyListAppliestoResponse> TokenlifetimepolicyListAppliestoAsync(TokenlifetimepolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimepolicyListAppliestoParameter, TokenlifetimepolicyListAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
