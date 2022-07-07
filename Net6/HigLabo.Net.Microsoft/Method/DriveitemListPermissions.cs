using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemListPermissionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Permissions,
            Groups_GroupId_Drive_Items_ItemId_Permissions,
            Me_Drive_Items_ItemId_Permissions,
            Me_Drive_Root_Path_Permissions,
            Sites_SiteId_Drive_Items_ItemId_Permissions,
            Users_UserId_Drive_Items_ItemId_Permissions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_Permissions: return $"/drives/{DriveId}/items/{ItemId}/permissions";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Permissions: return $"/groups/{GroupId}/drive/items/{ItemId}/permissions";
                    case ApiPath.Me_Drive_Items_ItemId_Permissions: return $"/me/drive/items/{ItemId}/permissions";
                    case ApiPath.Me_Drive_Root_Path_Permissions: return $"/me/drive/root:/{Path}:/permissions";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Permissions: return $"/sites/{SiteId}/drive/items/{ItemId}/permissions";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Permissions: return $"/users/{UserId}/drive/items/{ItemId}/permissions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string DriveId { get; set; }
        public string ItemId { get; set; }
        public string GroupId { get; set; }
        public string SiteId { get; set; }
        public string UserId { get; set; }
    }
    public partial class DriveitemListPermissionsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/permission?view=graph-rest-1.0
        /// </summary>
        public partial class Permission
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

        public Permission[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListPermissionsResponse> DriveitemListPermissionsAsync()
        {
            var p = new DriveitemListPermissionsParameter();
            return await this.SendAsync<DriveitemListPermissionsParameter, DriveitemListPermissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListPermissionsResponse> DriveitemListPermissionsAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemListPermissionsParameter();
            return await this.SendAsync<DriveitemListPermissionsParameter, DriveitemListPermissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListPermissionsResponse> DriveitemListPermissionsAsync(DriveitemListPermissionsParameter parameter)
        {
            return await this.SendAsync<DriveitemListPermissionsParameter, DriveitemListPermissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListPermissionsResponse> DriveitemListPermissionsAsync(DriveitemListPermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemListPermissionsParameter, DriveitemListPermissionsResponse>(parameter, cancellationToken);
        }
    }
}
