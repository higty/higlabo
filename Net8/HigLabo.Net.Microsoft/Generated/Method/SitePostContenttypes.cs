using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-post-contenttypes?view=graph-rest-1.0
    /// </summary>
    public partial class SitePostContentTypesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_ContentTypes: return $"/sites/{SiteId}/contentTypes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_ContentTypes,
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
    public partial class SitePostContentTypesResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-post-contenttypes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-post-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SitePostContentTypesResponse> SitePostContentTypesAsync()
        {
            var p = new SitePostContentTypesParameter();
            return await this.SendAsync<SitePostContentTypesParameter, SitePostContentTypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-post-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SitePostContentTypesResponse> SitePostContentTypesAsync(CancellationToken cancellationToken)
        {
            var p = new SitePostContentTypesParameter();
            return await this.SendAsync<SitePostContentTypesParameter, SitePostContentTypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-post-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SitePostContentTypesResponse> SitePostContentTypesAsync(SitePostContentTypesParameter parameter)
        {
            return await this.SendAsync<SitePostContentTypesParameter, SitePostContentTypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-post-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SitePostContentTypesResponse> SitePostContentTypesAsync(SitePostContentTypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SitePostContentTypesParameter, SitePostContentTypesResponse>(parameter, cancellationToken);
        }
    }
}
