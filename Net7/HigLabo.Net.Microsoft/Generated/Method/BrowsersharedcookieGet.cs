using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-get?view=graph-rest-1.0
    /// </summary>
    public partial class BrowsersharedcookieGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class BrowsersharedcookieGetResponse : RestApiResponse
    {
        public enum BrowserSharedCookieBrowserSharedCookieSourceEnvironment
        {
            MicrosoftEdge,
            InternetExplorer11,
            Both,
            UnknownFutureValue,
        }
        public enum BrowserSharedCookieBrowserSharedCookieStatus
        {
            Published,
            PendingAdd,
            PendingEdit,
            PendingDelete,
            UnknownFutureValue,
        }

        public string? Comment { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public BrowserSharedCookieHistory[]? History { get; set; }
        public bool? HostOnly { get; set; }
        public string? HostOrDomain { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Path { get; set; }
        public BrowserSharedCookieBrowserSharedCookieSourceEnvironment SourceEnvironment { get; set; }
        public BrowserSharedCookieBrowserSharedCookieStatus Status { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersharedcookieGetResponse> BrowsersharedcookieGetAsync()
        {
            var p = new BrowsersharedcookieGetParameter();
            return await this.SendAsync<BrowsersharedcookieGetParameter, BrowsersharedcookieGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersharedcookieGetResponse> BrowsersharedcookieGetAsync(CancellationToken cancellationToken)
        {
            var p = new BrowsersharedcookieGetParameter();
            return await this.SendAsync<BrowsersharedcookieGetParameter, BrowsersharedcookieGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersharedcookieGetResponse> BrowsersharedcookieGetAsync(BrowsersharedcookieGetParameter parameter)
        {
            return await this.SendAsync<BrowsersharedcookieGetParameter, BrowsersharedcookieGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersharedcookie-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersharedcookieGetResponse> BrowsersharedcookieGetAsync(BrowsersharedcookieGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BrowsersharedcookieGetParameter, BrowsersharedcookieGetResponse>(parameter, cancellationToken);
        }
    }
}
