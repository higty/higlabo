using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
    /// </summary>
    public partial class BrowsersharedcookieUpdateParameter : IRestApiParameter
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

        public enum BrowsersharedcookieUpdateParameterBrowserSharedCookieSourceEnvironment
        {
            MicrosoftEdge,
            InternetExplorer11,
            Both,
            UnknownFutureValue,
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Comment { get; set; }
        public string? DisplayName { get; set; }
        public bool? HostOnly { get; set; }
        public string? HostOrDomain { get; set; }
        public string? Path { get; set; }
        public BrowsersharedcookieUpdateParameterBrowserSharedCookieSourceEnvironment SourceEnvironment { get; set; }
    }
    public partial class BrowsersharedcookieUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersharedcookieUpdateResponse> BrowsersharedcookieUpdateAsync()
        {
            var p = new BrowsersharedcookieUpdateParameter();
            return await this.SendAsync<BrowsersharedcookieUpdateParameter, BrowsersharedcookieUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersharedcookieUpdateResponse> BrowsersharedcookieUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new BrowsersharedcookieUpdateParameter();
            return await this.SendAsync<BrowsersharedcookieUpdateParameter, BrowsersharedcookieUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersharedcookieUpdateResponse> BrowsersharedcookieUpdateAsync(BrowsersharedcookieUpdateParameter parameter)
        {
            return await this.SendAsync<BrowsersharedcookieUpdateParameter, BrowsersharedcookieUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersharedcookieUpdateResponse> BrowsersharedcookieUpdateAsync(BrowsersharedcookieUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BrowsersharedcookieUpdateParameter, BrowsersharedcookieUpdateResponse>(parameter, cancellationToken);
        }
    }
}
