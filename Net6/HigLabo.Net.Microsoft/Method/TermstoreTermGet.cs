using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreTermGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Groups_GroupId_Sets_SetId_Terms_TermId,
            Ites_SiteId_TermStore_Sets_SetId_Terms_TermId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Groups_GroupId_Sets_SetId_Terms_TermId: return $"/ites/{SiteId}/termStore/groups/{GroupId}/sets/{SetId}/terms/{TermId}";
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Terms_TermId: return $"/ites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}";
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
        public string SetId { get; set; }
        public string TermId { get; set; }
    }
    public partial class TermstoreTermGetResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TermStoreLocalizedDescription[]? Descriptions { get; set; }
        public string? Id { get; set; }
        public TermStoreLocalizedLabel[]? Labels { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public KeyValue[]? Properties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermGetResponse> TermstoreTermGetAsync()
        {
            var p = new TermstoreTermGetParameter();
            return await this.SendAsync<TermstoreTermGetParameter, TermstoreTermGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermGetResponse> TermstoreTermGetAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreTermGetParameter();
            return await this.SendAsync<TermstoreTermGetParameter, TermstoreTermGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermGetResponse> TermstoreTermGetAsync(TermstoreTermGetParameter parameter)
        {
            return await this.SendAsync<TermstoreTermGetParameter, TermstoreTermGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermGetResponse> TermstoreTermGetAsync(TermstoreTermGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreTermGetParameter, TermstoreTermGetResponse>(parameter, cancellationToken);
        }
    }
}
