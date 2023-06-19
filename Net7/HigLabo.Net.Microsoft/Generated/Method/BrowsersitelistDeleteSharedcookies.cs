using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sharedcookies?view=graph-rest-1.0
    /// </summary>
    public partial class BrowsersitelistDeleteSharedcookiesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BrowserSiteListId { get; set; }
            public string? BrowserSharedCookieId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_SharedCookies_BrowserSharedCookieId: return $"/admin/edge/internetExplorerMode/siteLists/{BrowserSiteListId}/sharedCookies/{BrowserSharedCookieId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_SharedCookies_BrowserSharedCookieId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class BrowsersitelistDeleteSharedcookiesResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sharedcookies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sharedcookies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistDeleteSharedcookiesResponse> BrowsersitelistDeleteSharedcookiesAsync()
        {
            var p = new BrowsersitelistDeleteSharedcookiesParameter();
            return await this.SendAsync<BrowsersitelistDeleteSharedcookiesParameter, BrowsersitelistDeleteSharedcookiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sharedcookies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistDeleteSharedcookiesResponse> BrowsersitelistDeleteSharedcookiesAsync(CancellationToken cancellationToken)
        {
            var p = new BrowsersitelistDeleteSharedcookiesParameter();
            return await this.SendAsync<BrowsersitelistDeleteSharedcookiesParameter, BrowsersitelistDeleteSharedcookiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sharedcookies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistDeleteSharedcookiesResponse> BrowsersitelistDeleteSharedcookiesAsync(BrowsersitelistDeleteSharedcookiesParameter parameter)
        {
            return await this.SendAsync<BrowsersitelistDeleteSharedcookiesParameter, BrowsersitelistDeleteSharedcookiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-delete-sharedcookies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistDeleteSharedcookiesResponse> BrowsersitelistDeleteSharedcookiesAsync(BrowsersitelistDeleteSharedcookiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BrowsersitelistDeleteSharedcookiesParameter, BrowsersitelistDeleteSharedcookiesResponse>(parameter, cancellationToken);
        }
    }
}
