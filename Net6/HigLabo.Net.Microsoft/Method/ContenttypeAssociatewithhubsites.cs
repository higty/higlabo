using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContenttypeAssociatewithhubsitesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_AssociateWithHubSites,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_AssociateWithHubSites: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/associateWithHubSites";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? HubSiteUrls { get; set; }
        public bool? PropagateToExistingLists { get; set; }
        public string SiteId { get; set; }
        public string ContentTypeId { get; set; }
    }
    public partial class ContenttypeAssociatewithhubsitesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-associatewithhubsites?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeAssociatewithhubsitesResponse> ContenttypeAssociatewithhubsitesAsync()
        {
            var p = new ContenttypeAssociatewithhubsitesParameter();
            return await this.SendAsync<ContenttypeAssociatewithhubsitesParameter, ContenttypeAssociatewithhubsitesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-associatewithhubsites?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeAssociatewithhubsitesResponse> ContenttypeAssociatewithhubsitesAsync(CancellationToken cancellationToken)
        {
            var p = new ContenttypeAssociatewithhubsitesParameter();
            return await this.SendAsync<ContenttypeAssociatewithhubsitesParameter, ContenttypeAssociatewithhubsitesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-associatewithhubsites?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeAssociatewithhubsitesResponse> ContenttypeAssociatewithhubsitesAsync(ContenttypeAssociatewithhubsitesParameter parameter)
        {
            return await this.SendAsync<ContenttypeAssociatewithhubsitesParameter, ContenttypeAssociatewithhubsitesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-associatewithhubsites?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeAssociatewithhubsitesResponse> ContenttypeAssociatewithhubsitesAsync(ContenttypeAssociatewithhubsitesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContenttypeAssociatewithhubsitesParameter, ContenttypeAssociatewithhubsitesResponse>(parameter, cancellationToken);
        }
    }
}
