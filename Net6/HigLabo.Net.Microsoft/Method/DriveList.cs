using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_GroupId_Drives,
            Sites_SiteId_Drives,
            Users_UserId_Drives,
            Me_Drives,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_GroupId_Drives: return $"/groups/{GroupId}/drives";
                    case ApiPath.Sites_SiteId_Drives: return $"/sites/{SiteId}/drives";
                    case ApiPath.Users_UserId_Drives: return $"/users/{UserId}/drives";
                    case ApiPath.Me_Drives: return $"/me/drives";
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
        public string GroupId { get; set; }
        public string SiteId { get; set; }
        public string UserId { get; set; }
    }
    public partial class DriveListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/drive?view=graph-rest-1.0
        /// </summary>
        public partial class Drive
        {
            public IdentitySet? CreatedBy { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DriveType { get; set; }
            public string? Id { get; set; }
            public IdentitySet? LastModifiedBy { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? Name { get; set; }
            public IdentitySet? Owner { get; set; }
            public Quota? Quota { get; set; }
            public SharePointIds? SharepointIds { get; set; }
            public System? System { get; set; }
            public string? WebUrl { get; set; }
        }

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
