using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreSetGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Sets_SetId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId: return $"/ites/{SiteId}/termStore/sets/{SetId}";
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
    }
    public partial class TermstoreSetGetResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public TermStoreLocalizedName[]? LocalizedNames { get; set; }
        public KeyValue[]? Properties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetGetResponse> TermstoreSetGetAsync()
        {
            var p = new TermstoreSetGetParameter();
            return await this.SendAsync<TermstoreSetGetParameter, TermstoreSetGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetGetResponse> TermstoreSetGetAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreSetGetParameter();
            return await this.SendAsync<TermstoreSetGetParameter, TermstoreSetGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetGetResponse> TermstoreSetGetAsync(TermstoreSetGetParameter parameter)
        {
            return await this.SendAsync<TermstoreSetGetParameter, TermstoreSetGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetGetResponse> TermstoreSetGetAsync(TermstoreSetGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreSetGetParameter, TermstoreSetGetResponse>(parameter, cancellationToken);
        }
    }
}
