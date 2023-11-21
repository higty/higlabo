using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
    /// </summary>
    public partial class DriveitemListPermissionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DriveId { get; set; }
            public string? ItemId { get; set; }
            public string? GroupId { get; set; }
            public string? Path { get; set; }
            public string? SiteId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_Permissions: return $"/drives/{DriveId}/items/{ItemId}/permissions";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Permissions: return $"/groups/{GroupId}/drive/items/{ItemId}/permissions";
                    case ApiPath.Me_Drive_Items_ItemId_Permissions: return $"/me/drive/items/{ItemId}/permissions";
                    case ApiPath.Me_Drive_Root_Path_Permissions: return $"/me/drive/root:/{Path}:/permissions";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Permissions: return $"/sites/{SiteId}/drive/items/{ItemId}/permissions";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Permissions: return $"/users/{UserId}/drive/items/{ItemId}/permissions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ExpirationDateTime,
            Id,
            HasPassword,
            GrantedToIdentitiesV2,
            GrantedToV2,
            InheritedFrom,
            Invitation,
            Link,
            Roles,
            ShareId,
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
    public partial class DriveitemListPermissionsResponse : RestApiResponse
    {
        public Permission[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveitemListPermissionsResponse> DriveitemListPermissionsAsync()
        {
            var p = new DriveitemListPermissionsParameter();
            return await this.SendAsync<DriveitemListPermissionsParameter, DriveitemListPermissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveitemListPermissionsResponse> DriveitemListPermissionsAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemListPermissionsParameter();
            return await this.SendAsync<DriveitemListPermissionsParameter, DriveitemListPermissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveitemListPermissionsResponse> DriveitemListPermissionsAsync(DriveitemListPermissionsParameter parameter)
        {
            return await this.SendAsync<DriveitemListPermissionsParameter, DriveitemListPermissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveitemListPermissionsResponse> DriveitemListPermissionsAsync(DriveitemListPermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemListPermissionsParameter, DriveitemListPermissionsResponse>(parameter, cancellationToken);
        }
    }
}
