using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContentTypeAssociatewithhubsitesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SiteId { get; set; }
            public string ContentTypeId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_AssociateWithHubSites: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/associateWithHubSites";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_AssociateWithHubSites,
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
        public String[]? HubSiteUrls { get; set; }
        public bool? PropagateToExistingLists { get; set; }
    }
    public partial class ContentTypeAssociatewithhubsitesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-associatewithhubsites?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAssociatewithhubsitesResponse> ContentTypeAssociatewithhubsitesAsync()
        {
            var p = new ContentTypeAssociatewithhubsitesParameter();
            return await this.SendAsync<ContentTypeAssociatewithhubsitesParameter, ContentTypeAssociatewithhubsitesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-associatewithhubsites?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAssociatewithhubsitesResponse> ContentTypeAssociatewithhubsitesAsync(CancellationToken cancellationToken)
        {
            var p = new ContentTypeAssociatewithhubsitesParameter();
            return await this.SendAsync<ContentTypeAssociatewithhubsitesParameter, ContentTypeAssociatewithhubsitesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-associatewithhubsites?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAssociatewithhubsitesResponse> ContentTypeAssociatewithhubsitesAsync(ContentTypeAssociatewithhubsitesParameter parameter)
        {
            return await this.SendAsync<ContentTypeAssociatewithhubsitesParameter, ContentTypeAssociatewithhubsitesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-associatewithhubsites?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeAssociatewithhubsitesResponse> ContentTypeAssociatewithhubsitesAsync(ContentTypeAssociatewithhubsitesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContentTypeAssociatewithhubsitesParameter, ContentTypeAssociatewithhubsitesResponse>(parameter, cancellationToken);
        }
    }
}
