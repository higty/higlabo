using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContentTypeAddcopyfromContentTypehubParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SiteId { get; set; }
            public string ListId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_AddCopyFromContentTypeHub: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/addCopyFromContentTypeHub";
                    case ApiPath.Sites_SiteId_ContentTypes_AddCopyFromContentTypeHub: return $"/sites/{SiteId}/contentTypes/addCopyFromContentTypeHub";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_ContentTypes_AddCopyFromContentTypeHub,
            Sites_SiteId_ContentTypes_AddCopyFromContentTypeHub,
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
        public string? ContentTypeId { get; set; }
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
    public partial class ContentTypeAddcopyfromContentTypehubResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopyfromcontenttypehub?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAddcopyfromContentTypehubResponse> ContentTypeAddcopyfromContentTypehubAsync()
        {
            var p = new ContentTypeAddcopyfromContentTypehubParameter();
            return await this.SendAsync<ContentTypeAddcopyfromContentTypehubParameter, ContentTypeAddcopyfromContentTypehubResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopyfromcontenttypehub?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAddcopyfromContentTypehubResponse> ContentTypeAddcopyfromContentTypehubAsync(CancellationToken cancellationToken)
        {
            var p = new ContentTypeAddcopyfromContentTypehubParameter();
            return await this.SendAsync<ContentTypeAddcopyfromContentTypehubParameter, ContentTypeAddcopyfromContentTypehubResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopyfromcontenttypehub?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAddcopyfromContentTypehubResponse> ContentTypeAddcopyfromContentTypehubAsync(ContentTypeAddcopyfromContentTypehubParameter parameter)
        {
            return await this.SendAsync<ContentTypeAddcopyfromContentTypehubParameter, ContentTypeAddcopyfromContentTypehubResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopyfromcontenttypehub?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAddcopyfromContentTypehubResponse> ContentTypeAddcopyfromContentTypehubAsync(ContentTypeAddcopyfromContentTypehubParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContentTypeAddcopyfromContentTypehubParameter, ContentTypeAddcopyfromContentTypehubResponse>(parameter, cancellationToken);
        }
    }
}
