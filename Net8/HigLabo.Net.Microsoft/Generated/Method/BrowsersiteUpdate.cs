using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersite-update?view=graph-rest-1.0
    /// </summary>
    public partial class BrowsersiteUpdateParameter : IRestApiParameter
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

        public enum BrowsersiteUpdateParameterBrowserSiteCompatibilityMode
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
        public enum BrowsersiteUpdateParameterBrowserSiteMergeType
        {
            NoMerge,
            Default,
            UnknownFutureValue,
        }
        public enum BrowsersiteUpdateParameterBrowserSiteTargetEnvironment
        {
            InternetExplorerMode,
            InternetExplorer11,
            MicrosoftEdge,
            Configurable,
            None,
            UnknownFutureValue,
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public bool? AllowRedirect { get; set; }
        public string? Comment { get; set; }
        public BrowsersiteUpdateParameterBrowserSiteCompatibilityMode CompatibilityMode { get; set; }
        public BrowsersiteUpdateParameterBrowserSiteMergeType MergeType { get; set; }
        public BrowsersiteUpdateParameterBrowserSiteTargetEnvironment TargetEnvironment { get; set; }
        public string? WebUrl { get; set; }
    }
    public partial class BrowsersiteUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersite-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersite-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersiteUpdateResponse> BrowsersiteUpdateAsync()
        {
            var p = new BrowsersiteUpdateParameter();
            return await this.SendAsync<BrowsersiteUpdateParameter, BrowsersiteUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersite-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersiteUpdateResponse> BrowsersiteUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new BrowsersiteUpdateParameter();
            return await this.SendAsync<BrowsersiteUpdateParameter, BrowsersiteUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersite-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersiteUpdateResponse> BrowsersiteUpdateAsync(BrowsersiteUpdateParameter parameter)
        {
            return await this.SendAsync<BrowsersiteUpdateParameter, BrowsersiteUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersite-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersiteUpdateResponse> BrowsersiteUpdateAsync(BrowsersiteUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BrowsersiteUpdateParameter, BrowsersiteUpdateResponse>(parameter, cancellationToken);
        }
    }
}
