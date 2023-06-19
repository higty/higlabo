using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-publish?view=graph-rest-1.0
    /// </summary>
    public partial class BrowsersitelistPublishParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BrowserSiteListId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_Publish: return $"/admin/edge/internetExplorerMode/siteLists/{BrowserSiteListId}/publish";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum BrowserSiteListBrowserSiteListStatus
        {
            Draft,
            Published,
            Pending,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_Publish,
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
        public string? Revision { get; set; }
        public BrowserSharedCookie[]? SharedCookies { get; set; }
        public BrowserSite[]? Sites { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IdentitySet? PublishedBy { get; set; }
        public DateTimeOffset? PublishedDateTime { get; set; }
        public BrowserSiteListBrowserSiteListStatus Status { get; set; }
    }
    public partial class BrowsersitelistPublishResponse : RestApiResponse
    {
        public enum BrowserSiteListBrowserSiteListStatus
        {
            Draft,
            Published,
            Pending,
            UnknownFutureValue,
        }

        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IdentitySet? PublishedBy { get; set; }
        public DateTimeOffset? PublishedDateTime { get; set; }
        public string? Revision { get; set; }
        public BrowserSiteListBrowserSiteListStatus Status { get; set; }
        public BrowserSharedCookie[]? SharedCookies { get; set; }
        public BrowserSite[]? Sites { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-publish?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistPublishResponse> BrowsersitelistPublishAsync()
        {
            var p = new BrowsersitelistPublishParameter();
            return await this.SendAsync<BrowsersitelistPublishParameter, BrowsersitelistPublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistPublishResponse> BrowsersitelistPublishAsync(CancellationToken cancellationToken)
        {
            var p = new BrowsersitelistPublishParameter();
            return await this.SendAsync<BrowsersitelistPublishParameter, BrowsersitelistPublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistPublishResponse> BrowsersitelistPublishAsync(BrowsersitelistPublishParameter parameter)
        {
            return await this.SendAsync<BrowsersitelistPublishParameter, BrowsersitelistPublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistPublishResponse> BrowsersitelistPublishAsync(BrowsersitelistPublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BrowsersitelistPublishParameter, BrowsersitelistPublishResponse>(parameter, cancellationToken);
        }
    }
}
