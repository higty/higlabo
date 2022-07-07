using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContenttypeGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId,
            Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}";
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/{ContentTypeId}";
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
        public string ContentTypeId { get; set; }
        public string ListId { get; set; }
    }
    public partial class ContenttypeGetResponse : RestApiResponse
    {
        public String[]? AssociatedHubsUrls { get; set; }
        public string? Description { get; set; }
        public DocumentSet? DocumentSet { get; set; }
        public DocumentSetContent? DocumentTemplate { get; set; }
        public string? Group { get; set; }
        public bool? Hidden { get; set; }
        public string? Id { get; set; }
        public ItemReference? InheritedFrom { get; set; }
        public bool? IsBuiltIn { get; set; }
        public string? Name { get; set; }
        public ContentTypeOrder? Order { get; set; }
        public string? ParentId { get; set; }
        public bool? PropagateChanges { get; set; }
        public bool? ReadOnly { get; set; }
        public bool? Sealed { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeGetResponse> ContenttypeGetAsync()
        {
            var p = new ContenttypeGetParameter();
            return await this.SendAsync<ContenttypeGetParameter, ContenttypeGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeGetResponse> ContenttypeGetAsync(CancellationToken cancellationToken)
        {
            var p = new ContenttypeGetParameter();
            return await this.SendAsync<ContenttypeGetParameter, ContenttypeGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeGetResponse> ContenttypeGetAsync(ContenttypeGetParameter parameter)
        {
            return await this.SendAsync<ContenttypeGetParameter, ContenttypeGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeGetResponse> ContenttypeGetAsync(ContenttypeGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContenttypeGetParameter, ContenttypeGetResponse>(parameter, cancellationToken);
        }
    }
}
