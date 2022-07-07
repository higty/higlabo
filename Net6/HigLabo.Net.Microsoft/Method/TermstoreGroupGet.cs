using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreGroupGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Groups_GroupId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Groups_GroupId: return $"/ites/{SiteId}/termStore/groups/{GroupId}";
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
    public partial class TermstoreGroupGetResponse : RestApiResponse
    {
        public enum Groupstring
        {
            Global,
            System,
            SiteCollection,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public Groupstring Scope { get; set; }
        public string? ParentSiteId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupGetResponse> TermstoreGroupGetAsync()
        {
            var p = new TermstoreGroupGetParameter();
            return await this.SendAsync<TermstoreGroupGetParameter, TermstoreGroupGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupGetResponse> TermstoreGroupGetAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreGroupGetParameter();
            return await this.SendAsync<TermstoreGroupGetParameter, TermstoreGroupGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupGetResponse> TermstoreGroupGetAsync(TermstoreGroupGetParameter parameter)
        {
            return await this.SendAsync<TermstoreGroupGetParameter, TermstoreGroupGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupGetResponse> TermstoreGroupGetAsync(TermstoreGroupGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreGroupGetParameter, TermstoreGroupGetResponse>(parameter, cancellationToken);
        }
    }
}
