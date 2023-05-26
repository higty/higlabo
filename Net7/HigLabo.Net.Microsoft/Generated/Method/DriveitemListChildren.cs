using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
    /// </summary>
    public partial class DriveitemListChildrenParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DriveId { get; set; }
            public string? ItemId { get; set; }
            public string? GroupId { get; set; }
            public string? SiteId { get; set; }
            public string? UserId { get; set; }
            public string? PathRelativeToRoot { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_Children: return $"/drives/{DriveId}/items/{ItemId}/children";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Children: return $"/groups/{GroupId}/drive/items/{ItemId}/children";
                    case ApiPath.Me_Drive_Items_ItemId_Children: return $"/me/drive/items/{ItemId}/children";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Children: return $"/sites/{SiteId}/drive/items/{ItemId}/children";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Children: return $"/users/{UserId}/drive/items/{ItemId}/children";
                    case ApiPath.Me_Drive_Root_Children: return $"/me/drive/root/children";
                    case ApiPath.Drives_DriveId_Root_PathRelativeToRoot_Children: return $"/drives/{DriveId}/root:/{PathRelativeToRoot}:/children";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Audio,
            Bundle,
            Content,
            CreatedBy,
            CreatedDateTime,
            CTag,
            Deleted,
            Description,
            ETag,
            File,
            FileSystemInfo,
            Folder,
            Id,
            Image,
            LastModifiedBy,
            LastModifiedDateTime,
            Location,
            Malware,
            Name,
            Package,
            ParentReference,
            PendingOperations,
            Photo,
            Publication,
            RemoteItem,
            Root,
            SearchResult,
            Shared,
            SharepointIds,
            Size,
            SpecialFolder,
            Video,
            WebDavUrl,
            WebUrl,
            Activities,
            Analytics,
            Children,
            CreatedByUser,
            LastModifiedByUser,
            ListItem,
            Permissions,
            Subscriptions,
            Thumbnails,
            Versions,
            Workbook,
        }
        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Children,
            Groups_GroupId_Drive_Items_ItemId_Children,
            Me_Drive_Items_ItemId_Children,
            Sites_SiteId_Drive_Items_ItemId_Children,
            Users_UserId_Drive_Items_ItemId_Children,
            Me_Drive_Root_Children,
            Drives_DriveId_Root_PathRelativeToRoot_Children,
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
    public partial class DriveitemListChildrenResponse : RestApiResponse
    {
        public DriveItem[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListChildrenResponse> DriveitemListChildrenAsync()
        {
            var p = new DriveitemListChildrenParameter();
            return await this.SendAsync<DriveitemListChildrenParameter, DriveitemListChildrenResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListChildrenResponse> DriveitemListChildrenAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemListChildrenParameter();
            return await this.SendAsync<DriveitemListChildrenParameter, DriveitemListChildrenResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListChildrenResponse> DriveitemListChildrenAsync(DriveitemListChildrenParameter parameter)
        {
            return await this.SendAsync<DriveitemListChildrenParameter, DriveitemListChildrenResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListChildrenResponse> DriveitemListChildrenAsync(DriveitemListChildrenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemListChildrenParameter, DriveitemListChildrenResponse>(parameter, cancellationToken);
        }
    }
}
