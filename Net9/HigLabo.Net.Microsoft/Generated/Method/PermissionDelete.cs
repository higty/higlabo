using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/permission-delete?view=graph-rest-1.0
/// </summary>
public partial class PermissionDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DriveId { get; set; }
        public string? ItemId { get; set; }
        public string? PermId { get; set; }
        public string? GroupId { get; set; }
        public string? SiteId { get; set; }
        public string? UserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Drives_DriveId_Items_ItemId_Permissions_PermId: return $"/drives/{DriveId}/items/{ItemId}/permissions/{PermId}";
                case ApiPath.Groups_GroupId_Drive_Items_ItemId_Permissions_PermId: return $"/groups/{GroupId}/drive/items/{ItemId}/permissions/{PermId}";
                case ApiPath.Me_Drive_Items_ItemId_Permissions_PermId: return $"/me/drive/items/{ItemId}/permissions/{PermId}";
                case ApiPath.Sites_SiteId_Drive_Items_ItemId_Permissions_PermId: return $"/sites/{SiteId}/drive/items/{ItemId}/permissions/{PermId}";
                case ApiPath.Users_UserId_Drive_Items_ItemId_Permissions_PermId: return $"/users/{UserId}/drive/items/{ItemId}/permissions/{PermId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Drives_DriveId_Items_ItemId_Permissions_PermId,
        Groups_GroupId_Drive_Items_ItemId_Permissions_PermId,
        Me_Drive_Items_ItemId_Permissions_PermId,
        Sites_SiteId_Drive_Items_ItemId_Permissions_PermId,
        Users_UserId_Drive_Items_ItemId_Permissions_PermId,
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
public partial class PermissionDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/permission-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permission-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PermissionDeleteResponse> PermissionDeleteAsync()
    {
        var p = new PermissionDeleteParameter();
        return await this.SendAsync<PermissionDeleteParameter, PermissionDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permission-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PermissionDeleteResponse> PermissionDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new PermissionDeleteParameter();
        return await this.SendAsync<PermissionDeleteParameter, PermissionDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permission-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PermissionDeleteResponse> PermissionDeleteAsync(PermissionDeleteParameter parameter)
    {
        return await this.SendAsync<PermissionDeleteParameter, PermissionDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permission-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PermissionDeleteResponse> PermissionDeleteAsync(PermissionDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PermissionDeleteParameter, PermissionDeleteResponse>(parameter, cancellationToken);
    }
}
