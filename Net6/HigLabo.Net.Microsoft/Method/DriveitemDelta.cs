using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Drives_DriveId_Root_Delta,
            Groups_GroupId_Drive_Root_Delta,
            Me_Drive_Root_Delta,
            Sites_SiteId_Drive_Root_Delta,
            Users_UserId_Drive_Root_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Drives_DriveId_Root_Delta: return $"/drives/{DriveId}/root/delta";
                    case ApiPath.Groups_GroupId_Drive_Root_Delta: return $"/groups/{GroupId}/drive/root/delta";
                    case ApiPath.Me_Drive_Root_Delta: return $"/me/drive/root/delta";
                    case ApiPath.Sites_SiteId_Drive_Root_Delta: return $"/sites/{SiteId}/drive/root/delta";
                    case ApiPath.Users_UserId_Drive_Root_Delta: return $"/users/{UserId}/drive/root/delta";
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
        public string DriveId { get; set; }
        public string GroupId { get; set; }
        public string SiteId { get; set; }
        public string UserId { get; set; }
    }
    public partial class DriveitemDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/driveitem?view=graph-rest-1.0
        /// </summary>
        public partial class DriveItem
        {
            public Audio? Audio { get; set; }
            public Bundle? Bundle { get; set; }
            public Stream? Content { get; set; }
            public IdentitySet? CreatedBy { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? CTag { get; set; }
            public Deleted? Deleted { get; set; }
            public string? Description { get; set; }
            public string? ETag { get; set; }
            public File? File { get; set; }
            public FileSystemInfo? FileSystemInfo { get; set; }
            public Folder? Folder { get; set; }
            public string? Id { get; set; }
            public Image? Image { get; set; }
            public IdentitySet? LastModifiedBy { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public GeoCoordinates? Location { get; set; }
            public Malware? Malware { get; set; }
            public string? Name { get; set; }
            public Package? Package { get; set; }
            public ItemReference? ParentReference { get; set; }
            public PendingOperations? PendingOperations { get; set; }
            public Photo? Photo { get; set; }
            public PublicationFacet? Publication { get; set; }
            public RemoteItem? RemoteItem { get; set; }
            public Root? Root { get; set; }
            public SearchResult? SearchResult { get; set; }
            public Shared? Shared { get; set; }
            public SharePointIds? SharepointIds { get; set; }
            public Int64? Size { get; set; }
            public SpecialFolder? SpecialFolder { get; set; }
            public Video? Video { get; set; }
            public string? WebDavUrl { get; set; }
            public string? WebUrl { get; set; }
        }

        public DriveItem[] Value { get; set; }
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
