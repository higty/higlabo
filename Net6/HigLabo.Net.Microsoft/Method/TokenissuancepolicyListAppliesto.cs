using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TokenissuancepolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_TokenIssuancePolicies_Id_AppliesTo,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_TokenIssuancePolicies_Id_AppliesTo: return $"/policies/tokenIssuancePolicies/{Id}/appliesTo";
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
    public partial class TokenissuancepolicyListAppliestoResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyListAppliestoResponse> TokenissuancepolicyListAppliestoAsync()
        {
            var p = new TokenissuancepolicyListAppliestoParameter();
            return await this.SendAsync<TokenissuancepolicyListAppliestoParameter, TokenissuancepolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyListAppliestoResponse> TokenissuancepolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new TokenissuancepolicyListAppliestoParameter();
            return await this.SendAsync<TokenissuancepolicyListAppliestoParameter, TokenissuancepolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyListAppliestoResponse> TokenissuancepolicyListAppliestoAsync(TokenissuancepolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<TokenissuancepolicyListAppliestoParameter, TokenissuancepolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<TokenissuancepolicyListAppliestoResponse> TokenissuancepolicyListAppliestoAsync(TokenissuancepolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenissuancepolicyListAppliestoParameter, TokenissuancepolicyListAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
