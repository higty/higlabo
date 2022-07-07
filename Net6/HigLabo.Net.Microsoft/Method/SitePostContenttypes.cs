using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SitePostContenttypesParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string SiteId { get; set; }
    }
    public partial class SitePostContenttypesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/site-post-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostContenttypesResponse> SitePostContenttypesAsync()
        {
            var p = new SitePostContenttypesParameter();
            return await this.SendAsync<SitePostContenttypesParameter, SitePostContenttypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostContenttypesResponse> SitePostContenttypesAsync(CancellationToken cancellationToken)
        {
            var p = new SitePostContenttypesParameter();
            return await this.SendAsync<SitePostContenttypesParameter, SitePostContenttypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostContenttypesResponse> SitePostContenttypesAsync(SitePostContenttypesParameter parameter)
        {
            return await this.SendAsync<SitePostContenttypesParameter, SitePostContenttypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostContenttypesResponse> SitePostContenttypesAsync(SitePostContenttypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SitePostContenttypesParameter, SitePostContenttypesResponse>(parameter, cancellationToken);
        }
    }
}
