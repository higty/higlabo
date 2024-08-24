using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-invite?view=graph-rest-1.0
    /// </summary>
    public partial class DriveItemInviteParameter : IRestApiParameter
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
                    case ApiPath.Drives_DriveId_Items_ItemId_Invite: return $"/drives/{DriveId}/items/{ItemId}/invite";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Invite: return $"/groups/{GroupId}/drive/items/{ItemId}/invite";
                    case ApiPath.Me_Drive_Items_ItemId_Invite: return $"/me/drive/items/{ItemId}/invite";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Invite: return $"/sites/{SiteId}/drive/items/{ItemId}/invite";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Invite: return $"/users/{UserId}/drive/items/{ItemId}/invite";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Invite,
            Groups_GroupId_Drive_Items_ItemId_Invite,
            Me_Drive_Items_ItemId_Invite,
            Sites_SiteId_Drive_Items_ItemId_Invite,
            Users_UserId_Drive_Items_ItemId_Invite,
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
        public DriveRecipient[]? Recipients { get; set; }
        public string? Message { get; set; }
        public bool? RequireSignIn { get; set; }
        public bool? SendInvitation { get; set; }
        public String[]? Roles { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public string? Password { get; set; }
        public bool? RetainInheritedPermissions { get; set; }
    }
    public partial class DriveItemInviteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-invite?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-invite?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemInviteResponse> DriveItemInviteAsync()
        {
            var p = new DriveItemInviteParameter();
            return await this.SendAsync<DriveItemInviteParameter, DriveItemInviteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-invite?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemInviteResponse> DriveItemInviteAsync(CancellationToken cancellationToken)
        {
            var p = new DriveItemInviteParameter();
            return await this.SendAsync<DriveItemInviteParameter, DriveItemInviteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-invite?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemInviteResponse> DriveItemInviteAsync(DriveItemInviteParameter parameter)
        {
            return await this.SendAsync<DriveItemInviteParameter, DriveItemInviteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-invite?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemInviteResponse> DriveItemInviteAsync(DriveItemInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveItemInviteParameter, DriveItemInviteResponse>(parameter, cancellationToken);
        }
    }
}
