using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContenttypeAddcopyParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_ContentTypes_AddCopy,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_AddCopy: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/addCopy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ContentType { get; set; }
        public string SiteId { get; set; }
        public string ListId { get; set; }
    }
    public partial class ContenttypeAddcopyResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopy?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeAddcopyResponse> ContenttypeAddcopyAsync()
        {
            var p = new ContenttypeAddcopyParameter();
            return await this.SendAsync<ContenttypeAddcopyParameter, ContenttypeAddcopyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopy?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeAddcopyResponse> ContenttypeAddcopyAsync(CancellationToken cancellationToken)
        {
            var p = new ContenttypeAddcopyParameter();
            return await this.SendAsync<ContenttypeAddcopyParameter, ContenttypeAddcopyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopy?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeAddcopyResponse> ContenttypeAddcopyAsync(ContenttypeAddcopyParameter parameter)
        {
            return await this.SendAsync<ContenttypeAddcopyParameter, ContenttypeAddcopyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-addcopy?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeAddcopyResponse> ContenttypeAddcopyAsync(ContenttypeAddcopyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContenttypeAddcopyParameter, ContenttypeAddcopyResponse>(parameter, cancellationToken);
        }
    }
}
