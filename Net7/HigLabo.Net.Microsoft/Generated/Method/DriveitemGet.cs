using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-get?view=graph-rest-1.0
    /// </summary>
    public partial class DriveitemGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DriveId { get; set; }
            public string? ItemId { get; set; }
            public string? ItemPath { get; set; }
            public string? GroupId { get; set; }
            public string? SiteId { get; set; }
            public string? ListId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId: return $"/drives/{DriveId}/items/{ItemId}";
                    case ApiPath.Drives_DriveId_Root_ItemPath: return $"/drives/{DriveId}/root:/{ItemPath}";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId: return $"/groups/{GroupId}/drive/items/{ItemId}";
                    case ApiPath.Groups_GroupId_Drive_Root_ItemPath: return $"/groups/{GroupId}/drive/root:/{ItemPath}";
                    case ApiPath.Me_Drive_Items_ItemId: return $"/me/drive/items/{ItemId}";
                    case ApiPath.Me_Drive_Root_ItemPath: return $"/me/drive/root:/{ItemPath}";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId: return $"/sites/{SiteId}/drive/items/{ItemId}";
                    case ApiPath.Sites_SiteId_Drive_Root_ItemPath: return $"/sites/{SiteId}/drive/root:/{ItemPath}";
                    case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId_DriveItem: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}/driveItem";
                    case ApiPath.Users_UserId_Drive_Items_ItemId: return $"/users/{UserId}/drive/items/{ItemId}";
                    case ApiPath.Users_UserId_Drive_Root_ItemPath: return $"/users/{UserId}/drive/root:/{ItemPath}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId,
            Drives_DriveId_Root_ItemPath,
            Groups_GroupId_Drive_Items_ItemId,
            Groups_GroupId_Drive_Root_ItemPath,
            Me_Drive_Items_ItemId,
            Me_Drive_Root_ItemPath,
            Sites_SiteId_Drive_Items_ItemId,
            Sites_SiteId_Drive_Root_ItemPath,
            Sites_SiteId_Lists_ListId_Items_ItemId_DriveItem,
            Users_UserId_Drive_Items_ItemId,
            Users_UserId_Drive_Root_ItemPath,
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
    public partial class DriveitemGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveitemGetResponse> DriveitemGetAsync()
        {
            var p = new DriveitemGetParameter();
            return await this.SendAsync<DriveitemGetParameter, DriveitemGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveitemGetResponse> DriveitemGetAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemGetParameter();
            return await this.SendAsync<DriveitemGetParameter, DriveitemGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveitemGetResponse> DriveitemGetAsync(DriveitemGetParameter parameter)
        {
            return await this.SendAsync<DriveitemGetParameter, DriveitemGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveitemGetResponse> DriveitemGetAsync(DriveitemGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemGetParameter, DriveitemGetResponse>(parameter, cancellationToken);
        }
    }
}
