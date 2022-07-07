using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemInviteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Invite,
            Groups_GroupId_Drive_Items_ItemId_Invite,
            Me_Drive_Items_ItemId_Invite,
            Sites_SiteId_Drive_Items_ItemId_Invite,
            Users_UserId_Drive_Items_ItemId_Invite,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_Invite: return $"/drives/{DriveId}/items/{ItemId}/invite";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Invite: return $"/groups/{GroupId}/drive/items/{ItemId}/invite";
                    case ApiPath.Me_Drive_Items_ItemId_Invite: return $"/me/drive/items/{ItemId}/invite";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Invite: return $"/sites/{SiteId}/drive/items/{ItemId}/invite";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Invite: return $"/users/{UserId}/drive/items/{ItemId}/invite";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string DriveId { get; set; }
        public string ItemId { get; set; }
        public string GroupId { get; set; }
        public string SiteId { get; set; }
        public string UserId { get; set; }
    }
    public partial class DriveitemInviteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-invite?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemInviteResponse> DriveitemInviteAsync()
        {
            var p = new DriveitemInviteParameter();
            return await this.SendAsync<DriveitemInviteParameter, DriveitemInviteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-invite?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemInviteResponse> DriveitemInviteAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemInviteParameter();
            return await this.SendAsync<DriveitemInviteParameter, DriveitemInviteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-invite?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemInviteResponse> DriveitemInviteAsync(DriveitemInviteParameter parameter)
        {
            return await this.SendAsync<DriveitemInviteParameter, DriveitemInviteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-invite?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemInviteResponse> DriveitemInviteAsync(DriveitemInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemInviteParameter, DriveitemInviteResponse>(parameter, cancellationToken);
        }
    }
}
