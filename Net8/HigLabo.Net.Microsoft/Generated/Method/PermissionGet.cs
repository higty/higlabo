using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permission-get?view=graph-rest-1.0
    /// </summary>
    public partial class PermissionGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class PermissionGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/permission-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permission-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissionGetResponse> PermissionGetAsync()
        {
            var p = new PermissionGetParameter();
            return await this.SendAsync<PermissionGetParameter, PermissionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permission-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissionGetResponse> PermissionGetAsync(CancellationToken cancellationToken)
        {
            var p = new PermissionGetParameter();
            return await this.SendAsync<PermissionGetParameter, PermissionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permission-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissionGetResponse> PermissionGetAsync(PermissionGetParameter parameter)
        {
            return await this.SendAsync<PermissionGetParameter, PermissionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permission-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PermissionGetResponse> PermissionGetAsync(PermissionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissionGetParameter, PermissionGetResponse>(parameter, cancellationToken);
        }
    }
}
