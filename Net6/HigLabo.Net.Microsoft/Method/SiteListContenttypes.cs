using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteListContenttypesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_ContentTypes: return $"/sites/{SiteId}/contentTypes";
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
    public partial class SiteListContenttypesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListContenttypesResponse> SiteListContenttypesAsync()
        {
            var p = new SiteListContenttypesParameter();
            return await this.SendAsync<SiteListContenttypesParameter, SiteListContenttypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListContenttypesResponse> SiteListContenttypesAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListContenttypesParameter();
            return await this.SendAsync<SiteListContenttypesParameter, SiteListContenttypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListContenttypesResponse> SiteListContenttypesAsync(SiteListContenttypesParameter parameter)
        {
            return await this.SendAsync<SiteListContenttypesParameter, SiteListContenttypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListContenttypesResponse> SiteListContenttypesAsync(SiteListContenttypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListContenttypesParameter, SiteListContenttypesResponse>(parameter, cancellationToken);
        }
    }
}
