using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissionDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Permissions_PermId,
            Groups_GroupId_Drive_Items_ItemId_Permissions_PermId,
            Me_Drive_Items_ItemId_Permissions_PermId,
            Sites_SiteId_Drive_Items_ItemId_Permissions_PermId,
            Users_UserId_Drive_Items_ItemId_Permissions_PermId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_Permissions_PermId: return $"/drives/{DriveId}/items/{ItemId}/permissions/{PermId}";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Permissions_PermId: return $"/groups/{GroupId}/drive/items/{ItemId}/permissions/{PermId}";
                    case ApiPath.Me_Drive_Items_ItemId_Permissions_PermId: return $"/me/drive/items/{ItemId}/permissions/{PermId}";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Permissions_PermId: return $"/sites/{SiteId}/drive/items/{ItemId}/permissions/{PermId}";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Permissions_PermId: return $"/users/{UserId}/drive/items/{ItemId}/permissions/{PermId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DriveId { get; set; }
        public string ItemId { get; set; }
        public string PermId { get; set; }
        public string GroupId { get; set; }
        public string SiteId { get; set; }
        public string UserId { get; set; }
    }
    public partial class PermissionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionDeleteResponse> PermissionDeleteAsync()
        {
            var p = new PermissionDeleteParameter();
            return await this.SendAsync<PermissionDeleteParameter, PermissionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionDeleteResponse> PermissionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PermissionDeleteParameter();
            return await this.SendAsync<PermissionDeleteParameter, PermissionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionDeleteResponse> PermissionDeleteAsync(PermissionDeleteParameter parameter)
        {
            return await this.SendAsync<PermissionDeleteParameter, PermissionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionDeleteResponse> PermissionDeleteAsync(PermissionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissionDeleteParameter, PermissionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
