using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
/// </summary>
public partial class DriveItemDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DriveId { get; set; }
        public string? ItemId { get; set; }
        public string? GroupId { get; set; }
        public string? SiteId { get; set; }
        public string? UserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Drives_DriveId_Items_ItemId: return $"/drives/{DriveId}/items/{ItemId}";
                case ApiPath.Groups_GroupId_Drive_Items_ItemId: return $"/groups/{GroupId}/drive/items/{ItemId}";
                case ApiPath.Me_Drive_Items_ItemId: return $"/me/drive/items/{ItemId}";
                case ApiPath.Sites_SiteId_Drive_Items_ItemId: return $"/sites/{SiteId}/drive/items/{ItemId}";
                case ApiPath.Users_UserId_Drive_Items_ItemId: return $"/users/{UserId}/drive/items/{ItemId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Drives_DriveId_Items_ItemId,
        Groups_GroupId_Drive_Items_ItemId,
        Me_Drive_Items_ItemId,
        Sites_SiteId_Drive_Items_ItemId,
        Users_UserId_Drive_Items_ItemId,
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
public partial class DriveItemDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemDeleteResponse> DriveItemDeleteAsync()
    {
        var p = new DriveItemDeleteParameter();
        return await this.SendAsync<DriveItemDeleteParameter, DriveItemDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemDeleteResponse> DriveItemDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new DriveItemDeleteParameter();
        return await this.SendAsync<DriveItemDeleteParameter, DriveItemDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemDeleteResponse> DriveItemDeleteAsync(DriveItemDeleteParameter parameter)
    {
        return await this.SendAsync<DriveItemDeleteParameter, DriveItemDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemDeleteResponse> DriveItemDeleteAsync(DriveItemDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DriveItemDeleteParameter, DriveItemDeleteResponse>(parameter, cancellationToken);
    }
}
