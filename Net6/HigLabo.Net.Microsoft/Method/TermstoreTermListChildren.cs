using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreTermListChildrenParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Sets_SetId_Children,
            Ites_SiteId_TermStore_Sets_SetId_Terms_TermId_Children,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Children: return $"/ites/{SiteId}/termStore/sets/{SetId}/children";
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Terms_TermId_Children: return $"/ites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}/children";
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
        public string SetId { get; set; }
        public string TermId { get; set; }
    }
    public partial class TermstoreTermListChildrenResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/termstore-term?view=graph-rest-1.0
        /// </summary>
        public partial class TermStoreTerm
        {
            public DateTimeOffset? CreatedDateTime { get; set; }
            public TermStoreLocalizedDescription[]? Descriptions { get; set; }
            public string? Id { get; set; }
            public TermStoreLocalizedLabel[]? Labels { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public KeyValue[]? Properties { get; set; }
        }

        public TermStoreTerm[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermListChildrenResponse> TermstoreTermListChildrenAsync()
        {
            var p = new TermstoreTermListChildrenParameter();
            return await this.SendAsync<TermstoreTermListChildrenParameter, TermstoreTermListChildrenResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermListChildrenResponse> TermstoreTermListChildrenAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreTermListChildrenParameter();
            return await this.SendAsync<TermstoreTermListChildrenParameter, TermstoreTermListChildrenResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermListChildrenResponse> TermstoreTermListChildrenAsync(TermstoreTermListChildrenParameter parameter)
        {
            return await this.SendAsync<TermstoreTermListChildrenParameter, TermstoreTermListChildrenResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermListChildrenResponse> TermstoreTermListChildrenAsync(TermstoreTermListChildrenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreTermListChildrenParameter, TermstoreTermListChildrenResponse>(parameter, cancellationToken);
        }
    }
}
