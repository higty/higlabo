using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelGetFilesfolderParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Description,
            DisplayName,
            Id,
            IsFavoriteByDefault,
            Email,
            WebUrl,
            MembershipType,
            CreatedDateTime,
        }
        public enum ApiPath
        {
            Teams_Id_Channels_Id_FilesFolder,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Channels_Id_FilesFolder: return $"/teams/{TeamsId}/channels/{ChannelsId}/filesFolder";
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
        public string TeamsId { get; set; }
        public string ChannelsId { get; set; }
    }
    public partial class ChannelGetFilesfolderResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/channel-get-filesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetFilesfolderResponse> ChannelGetFilesfolderAsync()
        {
            var p = new ChannelGetFilesfolderParameter();
            return await this.SendAsync<ChannelGetFilesfolderParameter, ChannelGetFilesfolderResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-get-filesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetFilesfolderResponse> ChannelGetFilesfolderAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelGetFilesfolderParameter();
            return await this.SendAsync<ChannelGetFilesfolderParameter, ChannelGetFilesfolderResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-get-filesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetFilesfolderResponse> ChannelGetFilesfolderAsync(ChannelGetFilesfolderParameter parameter)
        {
            return await this.SendAsync<ChannelGetFilesfolderParameter, ChannelGetFilesfolderResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-get-filesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetFilesfolderResponse> ChannelGetFilesfolderAsync(ChannelGetFilesfolderParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelGetFilesfolderParameter, ChannelGetFilesfolderResponse>(parameter, cancellationToken);
        }
    }
}
