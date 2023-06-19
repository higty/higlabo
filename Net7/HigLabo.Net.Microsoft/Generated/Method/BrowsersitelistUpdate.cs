using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-update?view=graph-rest-1.0
    /// </summary>
    public partial class BrowsersitelistUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
    }
    public partial class BrowsersitelistUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistUpdateResponse> BrowsersitelistUpdateAsync()
        {
            var p = new BrowsersitelistUpdateParameter();
            return await this.SendAsync<BrowsersitelistUpdateParameter, BrowsersitelistUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistUpdateResponse> BrowsersitelistUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new BrowsersitelistUpdateParameter();
            return await this.SendAsync<BrowsersitelistUpdateParameter, BrowsersitelistUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistUpdateResponse> BrowsersitelistUpdateAsync(BrowsersitelistUpdateParameter parameter)
        {
            return await this.SendAsync<BrowsersitelistUpdateParameter, BrowsersitelistUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BrowsersitelistUpdateResponse> BrowsersitelistUpdateAsync(BrowsersitelistUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BrowsersitelistUpdateParameter, BrowsersitelistUpdateResponse>(parameter, cancellationToken);
        }
    }
}
