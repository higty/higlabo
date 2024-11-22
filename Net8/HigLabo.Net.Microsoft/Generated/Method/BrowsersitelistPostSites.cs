using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sites?view=graph-rest-1.0
/// </summary>
public partial class BrowsersitelistPostSitesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? BrowserSiteListId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_Sites: return $"/admin/edge/internetExplorerMode/siteLists/{BrowserSiteListId}/sites";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum BrowsersitelistPostSitesParameterBrowserSiteCompatibilityMode
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
    public enum BrowsersitelistPostSitesParameterBrowserSiteMergeType
    {
        NoMerge,
        Default,
        UnknownFutureValue,
    }
    public enum BrowsersitelistPostSitesParameterBrowserSiteTargetEnvironment
    {
        InternetExplorerMode,
        InternetExplorer11,
        MicrosoftEdge,
        Configurable,
        None,
        UnknownFutureValue,
    }
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
    public enum ApiPath
    {
        Admin_Edge_InternetExplorerMode_SiteLists_BrowserSiteListId_Sites,
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
    public bool? AllowRedirect { get; set; }
    public string? Comment { get; set; }
    public BrowsersitelistPostSitesParameterBrowserSiteCompatibilityMode CompatibilityMode { get; set; }
    public BrowsersitelistPostSitesParameterBrowserSiteMergeType MergeType { get; set; }
    public BrowsersitelistPostSitesParameterBrowserSiteTargetEnvironment TargetEnvironment { get; set; }
    public string? WebUrl { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public DateTimeOffset? DeletedDateTime { get; set; }
    public BrowserSiteHistory[]? History { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public BrowserSiteBrowserSiteStatus Status { get; set; }
}
public partial class BrowsersitelistPostSitesResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sites?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistPostSitesResponse> BrowsersitelistPostSitesAsync()
    {
        var p = new BrowsersitelistPostSitesParameter();
        return await this.SendAsync<BrowsersitelistPostSitesParameter, BrowsersitelistPostSitesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistPostSitesResponse> BrowsersitelistPostSitesAsync(CancellationToken cancellationToken)
    {
        var p = new BrowsersitelistPostSitesParameter();
        return await this.SendAsync<BrowsersitelistPostSitesParameter, BrowsersitelistPostSitesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistPostSitesResponse> BrowsersitelistPostSitesAsync(BrowsersitelistPostSitesParameter parameter)
    {
        return await this.SendAsync<BrowsersitelistPostSitesParameter, BrowsersitelistPostSitesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/browsersitelist-post-sites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BrowsersitelistPostSitesResponse> BrowsersitelistPostSitesAsync(BrowsersitelistPostSitesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BrowsersitelistPostSitesParameter, BrowsersitelistPostSitesResponse>(parameter, cancellationToken);
    }
}
