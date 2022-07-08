using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string GroupId { get; set; }
            public string SiteId { get; set; }
            public string UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_GroupId_Drives: return $"/groups/{GroupId}/drives";
                    case ApiPath.Sites_SiteId_Drives: return $"/sites/{SiteId}/drives";
                    case ApiPath.Users_UserId_Drives: return $"/users/{UserId}/drives";
                    case ApiPath.Me_Drives: return $"/me/drives";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedBy,
            CreatedDateTime,
            Description,
            DriveType,
            Id,
            LastModifiedBy,
            LastModifiedDateTime,
            Name,
            Owner,
            Quota,
            SharepointIds,
            System,
            WebUrl,
            Bundles,
            Following,
            Items,
            Root,
            Special,
            List,
        }
        public enum ApiPath
        {
            Groups_GroupId_Drives,
            Sites_SiteId_Drives,
            Users_UserId_Drives,
            Me_Drives,
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
    public partial class DriveListResponse : RestApiResponse
    {
        public Drive[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveListResponse> DriveListAsync()
        {
            var p = new DriveListParameter();
            return await this.SendAsync<DriveListParameter, DriveListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveListResponse> DriveListAsync(CancellationToken cancellationToken)
        {
            var p = new DriveListParameter();
            return await this.SendAsync<DriveListParameter, DriveListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveListResponse> DriveListAsync(DriveListParameter parameter)
        {
            return await this.SendAsync<DriveListParameter, DriveListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveListResponse> DriveListAsync(DriveListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveListParameter, DriveListResponse>(parameter, cancellationToken);
        }
    }
}
