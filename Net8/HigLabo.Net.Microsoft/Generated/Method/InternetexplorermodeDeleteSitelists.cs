using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-delete-sitelists?view=graph-rest-1.0
/// </summary>
public partial class InternetexplorermodeDeleteSitelistsParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class InternetexplorermodeDeleteSitelistsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-delete-sitelists?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-delete-sitelists?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InternetexplorermodeDeleteSitelistsResponse> InternetexplorermodeDeleteSitelistsAsync()
    {
        var p = new InternetexplorermodeDeleteSitelistsParameter();
        return await this.SendAsync<InternetexplorermodeDeleteSitelistsParameter, InternetexplorermodeDeleteSitelistsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-delete-sitelists?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InternetexplorermodeDeleteSitelistsResponse> InternetexplorermodeDeleteSitelistsAsync(CancellationToken cancellationToken)
    {
        var p = new InternetexplorermodeDeleteSitelistsParameter();
        return await this.SendAsync<InternetexplorermodeDeleteSitelistsParameter, InternetexplorermodeDeleteSitelistsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-delete-sitelists?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InternetexplorermodeDeleteSitelistsResponse> InternetexplorermodeDeleteSitelistsAsync(InternetexplorermodeDeleteSitelistsParameter parameter)
    {
        return await this.SendAsync<InternetexplorermodeDeleteSitelistsParameter, InternetexplorermodeDeleteSitelistsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/internetexplorermode-delete-sitelists?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InternetexplorermodeDeleteSitelistsResponse> InternetexplorermodeDeleteSitelistsAsync(InternetexplorermodeDeleteSitelistsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<InternetexplorermodeDeleteSitelistsParameter, InternetexplorermodeDeleteSitelistsResponse>(parameter, cancellationToken);
    }
}
