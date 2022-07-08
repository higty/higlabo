using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveListFollowingParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Following: return $"/me/drive/following";
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
            Me_Drive_Following,
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
    public partial class DriveListFollowingResponse : RestApiResponse
    {
        public DriveItem[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveListFollowingResponse> DriveListFollowingAsync()
        {
            var p = new DriveListFollowingParameter();
            return await this.SendAsync<DriveListFollowingParameter, DriveListFollowingResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveListFollowingResponse> DriveListFollowingAsync(CancellationToken cancellationToken)
        {
            var p = new DriveListFollowingParameter();
            return await this.SendAsync<DriveListFollowingParameter, DriveListFollowingResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveListFollowingResponse> DriveListFollowingAsync(DriveListFollowingParameter parameter)
        {
            return await this.SendAsync<DriveListFollowingParameter, DriveListFollowingResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveListFollowingResponse> DriveListFollowingAsync(DriveListFollowingParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveListFollowingParameter, DriveListFollowingResponse>(parameter, cancellationToken);
        }
    }
}
