using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class HomerealmdiscoverypolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_HomeRealmDiscoveryPolicies_Id_AppliesTo,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_HomeRealmDiscoveryPolicies_Id_AppliesTo: return $"/policies/homeRealmDiscoveryPolicies/{Id}/appliesTo";
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
    public partial class HomerealmdiscoverypolicyListAppliestoResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyListAppliestoResponse> HomerealmdiscoverypolicyListAppliestoAsync()
        {
            var p = new HomerealmdiscoverypolicyListAppliestoParameter();
            return await this.SendAsync<HomerealmdiscoverypolicyListAppliestoParameter, HomerealmdiscoverypolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyListAppliestoResponse> HomerealmdiscoverypolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoverypolicyListAppliestoParameter();
            return await this.SendAsync<HomerealmdiscoverypolicyListAppliestoParameter, HomerealmdiscoverypolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyListAppliestoResponse> HomerealmdiscoverypolicyListAppliestoAsync(HomerealmdiscoverypolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoverypolicyListAppliestoParameter, HomerealmdiscoverypolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyListAppliestoResponse> HomerealmdiscoverypolicyListAppliestoAsync(HomerealmdiscoverypolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoverypolicyListAppliestoParameter, HomerealmdiscoverypolicyListAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
