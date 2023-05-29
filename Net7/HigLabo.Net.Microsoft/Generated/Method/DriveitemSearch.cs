using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
    /// </summary>
    public partial class DriveitemSearchParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DriveId { get; set; }
            public string? GroupId { get; set; }
            public string? SiteId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drives_DriveId_Root_Search: return $"/drives/{DriveId}/root/search";
                    case ApiPath.Groups_GroupId_Drive_Root_Search: return $"/groups/{GroupId}/drive/root/search";
                    case ApiPath.Me_Drive_Root_Search: return $"/me/drive/root/search";
                    case ApiPath.Sites_SiteId_Drive_Root_Search: return $"/sites/{SiteId}/drive/root/search";
                    case ApiPath.Users_UserId_Drive_Root_Search: return $"/users/{UserId}/drive/root/search";
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
            Drives_DriveId_Root_Search,
            Groups_GroupId_Drive_Root_Search,
            Me_Drive_Root_Search,
            Sites_SiteId_Drive_Root_Search,
            Users_UserId_Drive_Root_Search,
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
    public partial class DriveitemSearchResponse : RestApiResponse
    {
        public DriveItem[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemSearchResponse> DriveitemSearchAsync()
        {
            var p = new DriveitemSearchParameter();
            return await this.SendAsync<DriveitemSearchParameter, DriveitemSearchResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemSearchResponse> DriveitemSearchAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemSearchParameter();
            return await this.SendAsync<DriveitemSearchParameter, DriveitemSearchResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemSearchResponse> DriveitemSearchAsync(DriveitemSearchParameter parameter)
        {
            return await this.SendAsync<DriveitemSearchParameter, DriveitemSearchResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemSearchResponse> DriveitemSearchAsync(DriveitemSearchParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemSearchParameter, DriveitemSearchResponse>(parameter, cancellationToken);
        }
    }
}
