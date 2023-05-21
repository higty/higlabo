using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/drive-recent?view=graph-rest-1.0
    /// </summary>
    public partial class DriveRecentParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Recent: return $"/me/drive/recent";
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
            Me_Drive_Recent,
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
    public partial class DriveRecentResponse : RestApiResponse
    {
        public DriveItem[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/drive-recent?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-recent?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveRecentResponse> DriveRecentAsync()
        {
            var p = new DriveRecentParameter();
            return await this.SendAsync<DriveRecentParameter, DriveRecentResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-recent?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveRecentResponse> DriveRecentAsync(CancellationToken cancellationToken)
        {
            var p = new DriveRecentParameter();
            return await this.SendAsync<DriveRecentParameter, DriveRecentResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-recent?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveRecentResponse> DriveRecentAsync(DriveRecentParameter parameter)
        {
            return await this.SendAsync<DriveRecentParameter, DriveRecentResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-recent?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveRecentResponse> DriveRecentAsync(DriveRecentParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveRecentParameter, DriveRecentResponse>(parameter, cancellationToken);
        }
    }
}
