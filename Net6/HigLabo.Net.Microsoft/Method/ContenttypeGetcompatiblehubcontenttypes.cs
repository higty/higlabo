using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContenttypeGetcompatiblehubcontenttypesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_ContentTypes_GetCompatibleHubContentTypes,
            Sites_SiteId_ContentTypes_GetCompatibleHubContentTypes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_GetCompatibleHubContentTypes: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/getCompatibleHubContentTypes";
                    case ApiPath.Sites_SiteId_ContentTypes_GetCompatibleHubContentTypes: return $"/sites/{SiteId}/contentTypes/getCompatibleHubContentTypes";
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
    public partial class ContenttypeGetcompatiblehubcontenttypesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-getcompatiblehubcontenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeGetcompatiblehubcontenttypesResponse> ContenttypeGetcompatiblehubcontenttypesAsync()
        {
            var p = new ContenttypeGetcompatiblehubcontenttypesParameter();
            return await this.SendAsync<ContenttypeGetcompatiblehubcontenttypesParameter, ContenttypeGetcompatiblehubcontenttypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-getcompatiblehubcontenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeGetcompatiblehubcontenttypesResponse> ContenttypeGetcompatiblehubcontenttypesAsync(CancellationToken cancellationToken)
        {
            var p = new ContenttypeGetcompatiblehubcontenttypesParameter();
            return await this.SendAsync<ContenttypeGetcompatiblehubcontenttypesParameter, ContenttypeGetcompatiblehubcontenttypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-getcompatiblehubcontenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeGetcompatiblehubcontenttypesResponse> ContenttypeGetcompatiblehubcontenttypesAsync(ContenttypeGetcompatiblehubcontenttypesParameter parameter)
        {
            return await this.SendAsync<ContenttypeGetcompatiblehubcontenttypesParameter, ContenttypeGetcompatiblehubcontenttypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-getcompatiblehubcontenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeGetcompatiblehubcontenttypesResponse> ContenttypeGetcompatiblehubcontenttypesAsync(ContenttypeGetcompatiblehubcontenttypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContenttypeGetcompatiblehubcontenttypesParameter, ContenttypeGetcompatiblehubcontenttypesResponse>(parameter, cancellationToken);
        }
    }
}
