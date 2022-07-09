using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContentTypeAddcopyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ListId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_AddCopy: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/addCopy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_ContentTypes_AddCopy,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ContentType { get; set; }
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
        public ContentType? Base { get; set; }
        public ColumnLink[]? ColumnLinks { get; set; }
        public ContentType[]? BaseTypes { get; set; }
        public ColumnDefinition[]? ColumnPositions { get; set; }
        public ColumnDefinition[]? Columns { get; set; }
    }
    public partial class ContentTypeAddcopyResponse : RestApiResponse
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
        public ContentType? Base { get; set; }
        public ColumnLink[]? ColumnLinks { get; set; }
        public ContentType[]? BaseTypes { get; set; }
        public ColumnDefinition[]? ColumnPositions { get; set; }
        public ColumnDefinition[]? Columns { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopy?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAddcopyResponse> ContentTypeAddcopyAsync()
        {
            var p = new ContentTypeAddcopyParameter();
            return await this.SendAsync<ContentTypeAddcopyParameter, ContentTypeAddcopyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopy?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAddcopyResponse> ContentTypeAddcopyAsync(CancellationToken cancellationToken)
        {
            var p = new ContentTypeAddcopyParameter();
            return await this.SendAsync<ContentTypeAddcopyParameter, ContentTypeAddcopyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopy?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAddcopyResponse> ContentTypeAddcopyAsync(ContentTypeAddcopyParameter parameter)
        {
            return await this.SendAsync<ContentTypeAddcopyParameter, ContentTypeAddcopyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopy?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAddcopyResponse> ContentTypeAddcopyAsync(ContentTypeAddcopyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContentTypeAddcopyParameter, ContentTypeAddcopyResponse>(parameter, cancellationToken);
        }
    }
}
