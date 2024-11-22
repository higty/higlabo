using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-update-permission?view=graph-rest-1.0
/// </summary>
public partial class SiteUpdatePermissionParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SitesId { get; set; }
        public string? PermissionId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SitesId_Permissions_PermissionId: return $"/sites/{SitesId}/permissions/{PermissionId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Sites_SitesId_Permissions_PermissionId,
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
}
public partial class SiteUpdatePermissionResponse : RestApiResponse
{
    public DateTimeOffset? ExpirationDateTime { get; set; }
    public string? Id { get; set; }
    public bool? HasPassword { get; set; }
    public SharePointIdentitySet[]? GrantedToIdentitiesV2 { get; set; }
    public SharePointIdentitySet? GrantedToV2 { get; set; }
    public ItemReference? InheritedFrom { get; set; }
    public SharingInvitation? Invitation { get; set; }
    public SharingLink? Link { get; set; }
    public string[]? Roles { get; set; }
    public string? ShareId { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-update-permission?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-update-permission?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteUpdatePermissionResponse> SiteUpdatePermissionAsync()
    {
        var p = new SiteUpdatePermissionParameter();
        return await this.SendAsync<SiteUpdatePermissionParameter, SiteUpdatePermissionResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-update-permission?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteUpdatePermissionResponse> SiteUpdatePermissionAsync(CancellationToken cancellationToken)
    {
        var p = new SiteUpdatePermissionParameter();
        return await this.SendAsync<SiteUpdatePermissionParameter, SiteUpdatePermissionResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-update-permission?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteUpdatePermissionResponse> SiteUpdatePermissionAsync(SiteUpdatePermissionParameter parameter)
    {
        return await this.SendAsync<SiteUpdatePermissionParameter, SiteUpdatePermissionResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-update-permission?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteUpdatePermissionResponse> SiteUpdatePermissionAsync(SiteUpdatePermissionParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SiteUpdatePermissionParameter, SiteUpdatePermissionResponse>(parameter, cancellationToken);
    }
}
