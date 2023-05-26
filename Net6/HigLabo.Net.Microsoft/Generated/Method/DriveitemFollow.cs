using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-follow?view=graph-rest-1.0
    /// </summary>
    public partial class DriveitemFollowParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DriveId { get; set; }
            public string? ItemId { get; set; }
            public string? GroupId { get; set; }
            public string? SiteId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_Follow: return $"/drives/{DriveId}/items/{ItemId}/follow";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Follow: return $"/groups/{GroupId}/drive/items/{ItemId}/follow";
                    case ApiPath.Me_Drive_Items_ItemId_Follow: return $"/me/drive/items/{ItemId}/follow";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Follow: return $"/sites/{SiteId}/drive/items/{ItemId}/follow";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Follow: return $"/users/{UserId}/drive/items/{ItemId}/follow";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Follow,
            Groups_GroupId_Drive_Items_ItemId_Follow,
            Me_Drive_Items_ItemId_Follow,
            Sites_SiteId_Drive_Items_ItemId_Follow,
            Users_UserId_Drive_Items_ItemId_Follow,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
        public ItemActivity[]? Activities { get; set; }
        public ItemAnalytics? Analytics { get; set; }
        public DriveItem[]? Children { get; set; }
        public User? CreatedByUser { get; set; }
        public User? LastModifiedByUser { get; set; }
        public ListItem? ListItem { get; set; }
        public Permission[]? Permissions { get; set; }
        public Subscription[]? Subscriptions { get; set; }
        public ThumbnailSet[]? Thumbnails { get; set; }
        public DriveItemVersion[]? Versions { get; set; }
        public Workbook? Workbook { get; set; }
    }
    public partial class DriveitemFollowResponse : RestApiResponse
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
        public ItemActivity[]? Activities { get; set; }
        public ItemAnalytics? Analytics { get; set; }
        public DriveItem[]? Children { get; set; }
        public User? CreatedByUser { get; set; }
        public User? LastModifiedByUser { get; set; }
        public ListItem? ListItem { get; set; }
        public Permission[]? Permissions { get; set; }
        public Subscription[]? Subscriptions { get; set; }
        public ThumbnailSet[]? Thumbnails { get; set; }
        public DriveItemVersion[]? Versions { get; set; }
        public Workbook? Workbook { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-follow?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-follow?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemFollowResponse> DriveitemFollowAsync()
        {
            var p = new DriveitemFollowParameter();
            return await this.SendAsync<DriveitemFollowParameter, DriveitemFollowResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-follow?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemFollowResponse> DriveitemFollowAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemFollowParameter();
            return await this.SendAsync<DriveitemFollowParameter, DriveitemFollowResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-follow?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemFollowResponse> DriveitemFollowAsync(DriveitemFollowParameter parameter)
        {
            return await this.SendAsync<DriveitemFollowParameter, DriveitemFollowResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-follow?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemFollowResponse> DriveitemFollowAsync(DriveitemFollowParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemFollowParameter, DriveitemFollowResponse>(parameter, cancellationToken);
        }
    }
}
