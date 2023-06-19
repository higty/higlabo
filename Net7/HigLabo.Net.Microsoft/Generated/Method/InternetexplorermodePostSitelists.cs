using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-post-sitelists?view=graph-rest-1.0
    /// </summary>
    public partial class InternetexplorermodePostSitelistsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists: return $"/admin/edge/internetExplorerMode/siteLists";
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
            Admin_Edge_InternetExplorerMode_SiteLists,
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
    public partial class InternetexplorermodePostSitelistsResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-post-sitelists?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-post-sitelists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternetexplorermodePostSitelistsResponse> InternetexplorermodePostSitelistsAsync()
        {
            var p = new InternetexplorermodePostSitelistsParameter();
            return await this.SendAsync<InternetexplorermodePostSitelistsParameter, InternetexplorermodePostSitelistsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-post-sitelists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternetexplorermodePostSitelistsResponse> InternetexplorermodePostSitelistsAsync(CancellationToken cancellationToken)
        {
            var p = new InternetexplorermodePostSitelistsParameter();
            return await this.SendAsync<InternetexplorermodePostSitelistsParameter, InternetexplorermodePostSitelistsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-post-sitelists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternetexplorermodePostSitelistsResponse> InternetexplorermodePostSitelistsAsync(InternetexplorermodePostSitelistsParameter parameter)
        {
            return await this.SendAsync<InternetexplorermodePostSitelistsParameter, InternetexplorermodePostSitelistsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-post-sitelists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternetexplorermodePostSitelistsResponse> InternetexplorermodePostSitelistsAsync(InternetexplorermodePostSitelistsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InternetexplorermodePostSitelistsParameter, InternetexplorermodePostSitelistsResponse>(parameter, cancellationToken);
        }
    }
}
