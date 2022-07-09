using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemDeltaParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Drives_DriveId_Root_Delta: return $"/drives/{DriveId}/root/delta";
                    case ApiPath.Groups_GroupId_Drive_Root_Delta: return $"/groups/{GroupId}/drive/root/delta";
                    case ApiPath.Me_Drive_Root_Delta: return $"/me/drive/root/delta";
                    case ApiPath.Sites_SiteId_Drive_Root_Delta: return $"/sites/{SiteId}/drive/root/delta";
                    case ApiPath.Users_UserId_Drive_Root_Delta: return $"/users/{UserId}/drive/root/delta";
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
            Drives_DriveId_Root_Delta,
            Groups_GroupId_Drive_Root_Delta,
            Me_Drive_Root_Delta,
            Sites_SiteId_Drive_Root_Delta,
            Users_UserId_Drive_Root_Delta,
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
    public partial class DriveitemDeltaResponse : RestApiResponse
    {
        public DriveItem[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemDeltaResponse> DriveitemDeltaAsync()
        {
            var p = new DriveitemDeltaParameter();
            return await this.SendAsync<DriveitemDeltaParameter, DriveitemDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemDeltaResponse> DriveitemDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemDeltaParameter();
            return await this.SendAsync<DriveitemDeltaParameter, DriveitemDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemDeltaResponse> DriveitemDeltaAsync(DriveitemDeltaParameter parameter)
        {
            return await this.SendAsync<DriveitemDeltaParameter, DriveitemDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemDeltaResponse> DriveitemDeltaAsync(DriveitemDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemDeltaParameter, DriveitemDeltaResponse>(parameter, cancellationToken);
        }
    }
}
