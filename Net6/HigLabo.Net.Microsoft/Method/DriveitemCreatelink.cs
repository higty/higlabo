using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemCreatelinkParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_CreateLink,
            Groups_GroupId_Drive_Items_ItemId_CreateLink,
            Me_Drive_Items_ItemId_CreateLink,
            Sites_SiteId_Drive_Items_ItemId_CreateLink,
            Users_UserId_Drive_Items_ItemId_CreateLink,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_CreateLink: return $"/drives/{DriveId}/items/{ItemId}/createLink";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_CreateLink: return $"/groups/{GroupId}/drive/items/{ItemId}/createLink";
                    case ApiPath.Me_Drive_Items_ItemId_CreateLink: return $"/me/drive/items/{ItemId}/createLink";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_CreateLink: return $"/sites/{SiteId}/drive/items/{ItemId}/createLink";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_CreateLink: return $"/users/{UserId}/drive/items/{ItemId}/createLink";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Type { get; set; }
        public string? Password { get; set; }
        public string? ExpirationDateTime { get; set; }
        public string? Scope { get; set; }
        public string DriveId { get; set; }
        public string ItemId { get; set; }
        public string GroupId { get; set; }
        public string SiteId { get; set; }
        public string UserId { get; set; }
    }
    public partial class DriveitemCreatelinkResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public SharePointIdentitySet? GrantedToV2 { get; set; }
        public SharePointIdentitySet[]? GrantedToIdentitiesV2 { get; set; }
        public SharingInvitation? Invitation { get; set; }
        public ItemReference? InheritedFrom { get; set; }
        public SharingLink? Link { get; set; }
        public string[]? Roles { get; set; }
        public string? ShareId { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public bool? HasPassword { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-createlink?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCreatelinkResponse> DriveitemCreatelinkAsync()
        {
            var p = new DriveitemCreatelinkParameter();
            return await this.SendAsync<DriveitemCreatelinkParameter, DriveitemCreatelinkResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-createlink?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCreatelinkResponse> DriveitemCreatelinkAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemCreatelinkParameter();
            return await this.SendAsync<DriveitemCreatelinkParameter, DriveitemCreatelinkResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-createlink?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCreatelinkResponse> DriveitemCreatelinkAsync(DriveitemCreatelinkParameter parameter)
        {
            return await this.SendAsync<DriveitemCreatelinkParameter, DriveitemCreatelinkResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-createlink?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCreatelinkResponse> DriveitemCreatelinkAsync(DriveitemCreatelinkParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemCreatelinkParameter, DriveitemCreatelinkResponse>(parameter, cancellationToken);
        }
    }
}
