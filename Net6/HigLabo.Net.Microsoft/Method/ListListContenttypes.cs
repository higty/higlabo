using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListListContenttypesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_ContentTypes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes: return $"/sites/{SiteId}/lists/{ListId}/contentTypes";
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
        public string ListId { get; set; }
    }
    public partial class ListListContenttypesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/contenttype?view=graph-rest-1.0
        /// </summary>
        public partial class ContentType
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

        public ContentType[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListContenttypesResponse> ListListContenttypesAsync()
        {
            var p = new ListListContenttypesParameter();
            return await this.SendAsync<ListListContenttypesParameter, ListListContenttypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListContenttypesResponse> ListListContenttypesAsync(CancellationToken cancellationToken)
        {
            var p = new ListListContenttypesParameter();
            return await this.SendAsync<ListListContenttypesParameter, ListListContenttypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListContenttypesResponse> ListListContenttypesAsync(ListListContenttypesParameter parameter)
        {
            return await this.SendAsync<ListListContenttypesParameter, ListListContenttypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListContenttypesResponse> ListListContenttypesAsync(ListListContenttypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListListContenttypesParameter, ListListContenttypesResponse>(parameter, cancellationToken);
        }
    }
}
