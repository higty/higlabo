using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content?view=graph-rest-1.0
    /// </summary>
    public partial class DriveItemGetContentParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DriveId { get; set; }
            public string? ItemId { get; set; }
            public string? GroupId { get; set; }
            public string? ItemPath { get; set; }
            public string? ShareIdOrEncodedSharingUrl { get; set; }
            public string? SiteId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_Content: return $"/drives/{DriveId}/items/{ItemId}/content";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Content: return $"/groups/{GroupId}/drive/items/{ItemId}/content";
                    case ApiPath.Me_Drive_Root_ItemPath_Content: return $"/me/drive/root:/{ItemPath}:/content";
                    case ApiPath.Me_Drive_Items_ItemId_Content: return $"/me/drive/items/{ItemId}/content";
                    case ApiPath.Shares_ShareIdOrEncodedSharingUrl_DriveItem_Content: return $"/shares/{ShareIdOrEncodedSharingUrl}/driveItem/content";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Content: return $"/sites/{SiteId}/drive/items/{ItemId}/content";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Content: return $"/users/{UserId}/drive/items/{ItemId}/content";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Content,
            Groups_GroupId_Drive_Items_ItemId_Content,
            Me_Drive_Root_ItemPath_Content,
            Me_Drive_Items_ItemId_Content,
            Shares_ShareIdOrEncodedSharingUrl_DriveItem_Content,
            Sites_SiteId_Drive_Items_ItemId_Content,
            Users_UserId_Drive_Items_ItemId_Content,
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
    public partial class DriveItemGetContentResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemGetContentResponse> DriveItemGetContentAsync()
        {
            var p = new DriveItemGetContentParameter();
            return await this.SendAsync<DriveItemGetContentParameter, DriveItemGetContentResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemGetContentResponse> DriveItemGetContentAsync(CancellationToken cancellationToken)
        {
            var p = new DriveItemGetContentParameter();
            return await this.SendAsync<DriveItemGetContentParameter, DriveItemGetContentResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemGetContentResponse> DriveItemGetContentAsync(DriveItemGetContentParameter parameter)
        {
            return await this.SendAsync<DriveItemGetContentParameter, DriveItemGetContentResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemGetContentResponse> DriveItemGetContentAsync(DriveItemGetContentParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveItemGetContentParameter, DriveItemGetContentResponse>(parameter, cancellationToken);
        }
    }
}
