using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveGetSpecialfolderParameter : IRestApiParameter, IQueryParameterProperty
    {
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
        }
        public enum ApiPath
        {
            Me_Drive_Special_Name,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Special_Name: return $"/me/drive/special/{Name}";
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
        public string Name { get; set; }
    }
    public partial class DriveGetSpecialfolderResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-get-specialfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveGetSpecialfolderResponse> DriveGetSpecialfolderAsync()
        {
            var p = new DriveGetSpecialfolderParameter();
            return await this.SendAsync<DriveGetSpecialfolderParameter, DriveGetSpecialfolderResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-get-specialfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveGetSpecialfolderResponse> DriveGetSpecialfolderAsync(CancellationToken cancellationToken)
        {
            var p = new DriveGetSpecialfolderParameter();
            return await this.SendAsync<DriveGetSpecialfolderParameter, DriveGetSpecialfolderResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-get-specialfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveGetSpecialfolderResponse> DriveGetSpecialfolderAsync(DriveGetSpecialfolderParameter parameter)
        {
            return await this.SendAsync<DriveGetSpecialfolderParameter, DriveGetSpecialfolderResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/drive-get-specialfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveGetSpecialfolderResponse> DriveGetSpecialfolderAsync(DriveGetSpecialfolderParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveGetSpecialfolderParameter, DriveGetSpecialfolderResponse>(parameter, cancellationToken);
        }
    }
}
