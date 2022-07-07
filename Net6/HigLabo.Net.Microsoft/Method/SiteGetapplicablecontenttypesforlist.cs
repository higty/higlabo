using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteGetapplicablecontenttypesforlistParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Id,
            CreatedDateTime,
            Description,
            DisplayName,
            ETag,
            LastModifiedDateTime,
            Name,
            Root,
            SharepointIds,
            SiteCollection,
            WebUrl,
        }
        public enum ApiPath
        {
            Sites_SiteId_GetApplicableContentTypesForList,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_GetApplicableContentTypesForList: return $"/sites/{SiteId}/getApplicableContentTypesForList";
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
    }
    public partial class SiteGetapplicablecontenttypesforlistResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/site-getapplicablecontenttypesforlist?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteGetapplicablecontenttypesforlistResponse> SiteGetapplicablecontenttypesforlistAsync()
        {
            var p = new SiteGetapplicablecontenttypesforlistParameter();
            return await this.SendAsync<SiteGetapplicablecontenttypesforlistParameter, SiteGetapplicablecontenttypesforlistResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-getapplicablecontenttypesforlist?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteGetapplicablecontenttypesforlistResponse> SiteGetapplicablecontenttypesforlistAsync(CancellationToken cancellationToken)
        {
            var p = new SiteGetapplicablecontenttypesforlistParameter();
            return await this.SendAsync<SiteGetapplicablecontenttypesforlistParameter, SiteGetapplicablecontenttypesforlistResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-getapplicablecontenttypesforlist?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteGetapplicablecontenttypesforlistResponse> SiteGetapplicablecontenttypesforlistAsync(SiteGetapplicablecontenttypesforlistParameter parameter)
        {
            return await this.SendAsync<SiteGetapplicablecontenttypesforlistParameter, SiteGetapplicablecontenttypesforlistResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-getapplicablecontenttypesforlist?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteGetapplicablecontenttypesforlistResponse> SiteGetapplicablecontenttypesforlistAsync(SiteGetapplicablecontenttypesforlistParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteGetapplicablecontenttypesforlistParameter, SiteGetapplicablecontenttypesforlistResponse>(parameter, cancellationToken);
        }
    }
}
