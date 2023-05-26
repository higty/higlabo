using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersite-get?view=graph-rest-1.0
    /// </summary>
    public partial class BrowsersiteGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BrowserSiteListId { get; set; }
            public string? BrowserSiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_Sites_BrowserSiteId: return $"/admin/edge/internetExplorerMode/siteLists/{BrowserSiteListId}/sites/{BrowserSiteId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_Sites_BrowserSiteId,
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
    public partial class BrowsersiteGetResponse : RestApiResponse
    {
        public enum BrowserSiteBrowserSiteCompatibilityMode
        {
            Default,
            InternetExplorer8Enterprise,
            InternetExplorer7Enterprise,
            InternetExplorer11,
            InternetExplorer10,
            InternetExplorer9,
            InternetExplorer8,
            InternetExplorer7,
            InternetExplorer5,
            UnknownFutureValue,
        }
        public enum BrowserSiteBrowserSiteMergeType
        {
            NoMerge,
            Default,
            UnknownFutureValue,
        }
        public enum BrowserSiteBrowserSiteStatus
        {
            Published,
            PendingAdd,
            PendingEdit,
            PendingDelete,
            UnknownFutureValue,
        }
        public enum BrowserSiteBrowserSiteTargetEnvironment
        {
            InternetExplorerMode,
            InternetExplorer11,
            MicrosoftEdge,
            Configurable,
            None,
            UnknownFutureValue,
        }

        public bool? AllowRedirect { get; set; }
        public string? Comment { get; set; }
        public BrowserSiteBrowserSiteCompatibilityMode CompatibilityMode { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public BrowserSiteHistory[]? History { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public BrowserSiteBrowserSiteMergeType MergeType { get; set; }
        public BrowserSiteBrowserSiteStatus Status { get; set; }
        public BrowserSiteBrowserSiteTargetEnvironment TargetEnvironment { get; set; }
        public string? WebUrl { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersite-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersite-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BrowsersiteGetResponse> BrowsersiteGetAsync()
        {
            var p = new BrowsersiteGetParameter();
            return await this.SendAsync<BrowsersiteGetParameter, BrowsersiteGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersite-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BrowsersiteGetResponse> BrowsersiteGetAsync(CancellationToken cancellationToken)
        {
            var p = new BrowsersiteGetParameter();
            return await this.SendAsync<BrowsersiteGetParameter, BrowsersiteGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersite-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BrowsersiteGetResponse> BrowsersiteGetAsync(BrowsersiteGetParameter parameter)
        {
            return await this.SendAsync<BrowsersiteGetParameter, BrowsersiteGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersite-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BrowsersiteGetResponse> BrowsersiteGetAsync(BrowsersiteGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BrowsersiteGetParameter, BrowsersiteGetResponse>(parameter, cancellationToken);
        }
    }
}
