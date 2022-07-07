using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreGroupListSetsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Groups_GroupId_Sets,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Groups_GroupId_Sets: return $"/ites/{SiteId}/termStore/groups/{GroupId}/sets";
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
        public string SiteId { get; set; }
        public string GroupId { get; set; }
    }
    public partial class TermstoreGroupListSetsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/termstore-set?view=graph-rest-1.0
        /// </summary>
        public partial class TermStoreSet
        {
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? Id { get; set; }
            public TermStoreLocalizedName[]? LocalizedNames { get; set; }
            public KeyValue[]? Properties { get; set; }
        }

        public TermStoreSet[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupListSetsResponse> TermstoreGroupListSetsAsync()
        {
            var p = new TermstoreGroupListSetsParameter();
            return await this.SendAsync<TermstoreGroupListSetsParameter, TermstoreGroupListSetsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupListSetsResponse> TermstoreGroupListSetsAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreGroupListSetsParameter();
            return await this.SendAsync<TermstoreGroupListSetsParameter, TermstoreGroupListSetsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupListSetsResponse> TermstoreGroupListSetsAsync(TermstoreGroupListSetsParameter parameter)
        {
            return await this.SendAsync<TermstoreGroupListSetsParameter, TermstoreGroupListSetsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupListSetsResponse> TermstoreGroupListSetsAsync(TermstoreGroupListSetsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreGroupListSetsParameter, TermstoreGroupListSetsResponse>(parameter, cancellationToken);
        }
    }
}
