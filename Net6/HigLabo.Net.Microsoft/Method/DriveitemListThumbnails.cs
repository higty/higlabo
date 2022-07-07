using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemListThumbnailsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Thumbnails,
            Groups_GroupId_Drive_Items_ItemId_Thumbnails,
            Me_Drive_Items_ItemId_Thumbnails,
            Sites_SiteId_Drive_Items_ItemId_Thumbnails,
            Users_UserId_Drive_Items_ItemId_Thumbnails,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_Thumbnails: return $"/drives/{DriveId}/items/{ItemId}/thumbnails";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Thumbnails: return $"/groups/{GroupId}/drive/items/{ItemId}/thumbnails";
                    case ApiPath.Me_Drive_Items_ItemId_Thumbnails: return $"/me/drive/items/{ItemId}/thumbnails";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Thumbnails: return $"/sites/{SiteId}/drive/items/{ItemId}/thumbnails";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Thumbnails: return $"/users/{UserId}/drive/items/{ItemId}/thumbnails";
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
        public string ItemId { get; set; }
        public string GroupId { get; set; }
        public string SiteId { get; set; }
        public string UserId { get; set; }
    }
    public partial class DriveitemListThumbnailsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/thumbnailset?view=graph-rest-1.0
        /// </summary>
        public partial class ThumbnailSet
        {
            public string? Id { get; set; }
            public Thumbnail? Large { get; set; }
            public Thumbnail? Medium { get; set; }
            public Thumbnail? Small { get; set; }
            public Thumbnail? Source { get; set; }
        }

        public ThumbnailSet[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListThumbnailsResponse> DriveitemListThumbnailsAsync()
        {
            var p = new DriveitemListThumbnailsParameter();
            return await this.SendAsync<DriveitemListThumbnailsParameter, DriveitemListThumbnailsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListThumbnailsResponse> DriveitemListThumbnailsAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemListThumbnailsParameter();
            return await this.SendAsync<DriveitemListThumbnailsParameter, DriveitemListThumbnailsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListThumbnailsResponse> DriveitemListThumbnailsAsync(DriveitemListThumbnailsParameter parameter)
        {
            return await this.SendAsync<DriveitemListThumbnailsParameter, DriveitemListThumbnailsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListThumbnailsResponse> DriveitemListThumbnailsAsync(DriveitemListThumbnailsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemListThumbnailsParameter, DriveitemListThumbnailsResponse>(parameter, cancellationToken);
        }
    }
}
