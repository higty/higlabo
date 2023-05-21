using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-get?view=graph-rest-1.0
    /// </summary>
    public partial class BrowsersitelistGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BrowserSiteListId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId: return $"/admin/edge/internetExplorerMode/siteLists/{BrowserSiteListId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId,
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
    public partial class BrowsersitelistGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BrowsersitelistGetResponse> BrowsersitelistGetAsync()
        {
            var p = new BrowsersitelistGetParameter();
            return await this.SendAsync<BrowsersitelistGetParameter, BrowsersitelistGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BrowsersitelistGetResponse> BrowsersitelistGetAsync(CancellationToken cancellationToken)
        {
            var p = new BrowsersitelistGetParameter();
            return await this.SendAsync<BrowsersitelistGetParameter, BrowsersitelistGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BrowsersitelistGetResponse> BrowsersitelistGetAsync(BrowsersitelistGetParameter parameter)
        {
            return await this.SendAsync<BrowsersitelistGetParameter, BrowsersitelistGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BrowsersitelistGetResponse> BrowsersitelistGetAsync(BrowsersitelistGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BrowsersitelistGetParameter, BrowsersitelistGetResponse>(parameter, cancellationToken);
        }
    }
}
