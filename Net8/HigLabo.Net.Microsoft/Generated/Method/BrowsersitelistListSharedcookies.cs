using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sharedcookies?view=graph-rest-1.0
    /// </summary>
    public partial class BrowsersitelistListSharedcookiesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BrowserSiteListId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_SharedCookies: return $"/admin/edge/internetExplorerMode/siteLists/{BrowserSiteListId}/sharedCookies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Comment,
            CreatedDateTime,
            DeletedDateTime,
            DisplayName,
            History,
            HostOnly,
            HostOrDomain,
            Id,
            LastModifiedBy,
            LastModifiedDateTime,
            Path,
            SourceEnvironment,
            Status,
        }
        public enum ApiPath
        {
            Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_SharedCookies,
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
    public partial class BrowsersitelistListSharedcookiesResponse : RestApiResponse
    {
        public BrowserSharedCookie[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sharedcookies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sharedcookies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistListSharedcookiesResponse> BrowsersitelistListSharedcookiesAsync()
        {
            var p = new BrowsersitelistListSharedcookiesParameter();
            return await this.SendAsync<BrowsersitelistListSharedcookiesParameter, BrowsersitelistListSharedcookiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sharedcookies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistListSharedcookiesResponse> BrowsersitelistListSharedcookiesAsync(CancellationToken cancellationToken)
        {
            var p = new BrowsersitelistListSharedcookiesParameter();
            return await this.SendAsync<BrowsersitelistListSharedcookiesParameter, BrowsersitelistListSharedcookiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sharedcookies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistListSharedcookiesResponse> BrowsersitelistListSharedcookiesAsync(BrowsersitelistListSharedcookiesParameter parameter)
        {
            return await this.SendAsync<BrowsersitelistListSharedcookiesParameter, BrowsersitelistListSharedcookiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-list-sharedcookies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistListSharedcookiesResponse> BrowsersitelistListSharedcookiesAsync(BrowsersitelistListSharedcookiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BrowsersitelistListSharedcookiesParameter, BrowsersitelistListSharedcookiesResponse>(parameter, cancellationToken);
        }
    }
}
