using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/drive-sharedwithme?view=graph-rest-1.0
    /// </summary>
    public partial class DriveSharedwithmeParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_SharedWithMe: return $"/me/drive/sharedWithMe";
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
            Me_Drive_SharedWithMe,
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
    public partial class DriveSharedwithmeResponse : RestApiResponse
    {
        public DriveItem[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/drive-sharedwithme?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-sharedwithme?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveSharedwithmeResponse> DriveSharedwithmeAsync()
        {
            var p = new DriveSharedwithmeParameter();
            return await this.SendAsync<DriveSharedwithmeParameter, DriveSharedwithmeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-sharedwithme?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveSharedwithmeResponse> DriveSharedwithmeAsync(CancellationToken cancellationToken)
        {
            var p = new DriveSharedwithmeParameter();
            return await this.SendAsync<DriveSharedwithmeParameter, DriveSharedwithmeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-sharedwithme?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveSharedwithmeResponse> DriveSharedwithmeAsync(DriveSharedwithmeParameter parameter)
        {
            return await this.SendAsync<DriveSharedwithmeParameter, DriveSharedwithmeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-sharedwithme?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveSharedwithmeResponse> DriveSharedwithmeAsync(DriveSharedwithmeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveSharedwithmeParameter, DriveSharedwithmeResponse>(parameter, cancellationToken);
        }
    }
}
