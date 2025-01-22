using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-unfollow?view=graph-rest-1.0
/// </summary>
public partial class DriveItemUnfollowParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ItemId { get; set; }
        public string? UserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Drive_Following_ItemId: return $"/me/drive/following/{ItemId}";
                case ApiPath.Users_UserId_Drive_Following_ItemId: return $"/users/{UserId}/drive/following/{ItemId}";
                case ApiPath.Me_Drive_Items_ItemId_Unfollow: return $"/me/drive/items/{ItemId}/unfollow";
                case ApiPath.Users_UserId_Drive_Items_ItemId_Unfollow: return $"/users/{UserId}/drive/items/{ItemId}/unfollow";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Drive_Following_ItemId,
        Users_UserId_Drive_Following_ItemId,
        Me_Drive_Items_ItemId_Unfollow,
        Users_UserId_Drive_Items_ItemId_Unfollow,
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
public partial class DriveItemUnfollowResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-unfollow?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-unfollow?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemUnfollowResponse> DriveItemUnfollowAsync()
    {
        var p = new DriveItemUnfollowParameter();
        return await this.SendAsync<DriveItemUnfollowParameter, DriveItemUnfollowResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-unfollow?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemUnfollowResponse> DriveItemUnfollowAsync(CancellationToken cancellationToken)
    {
        var p = new DriveItemUnfollowParameter();
        return await this.SendAsync<DriveItemUnfollowParameter, DriveItemUnfollowResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-unfollow?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemUnfollowResponse> DriveItemUnfollowAsync(DriveItemUnfollowParameter parameter)
    {
        return await this.SendAsync<DriveItemUnfollowParameter, DriveItemUnfollowResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-unfollow?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemUnfollowResponse> DriveItemUnfollowAsync(DriveItemUnfollowParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DriveItemUnfollowParameter, DriveItemUnfollowResponse>(parameter, cancellationToken);
    }
}
