using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemPreviewParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string DriveId { get; set; }
            public string ItemId { get; set; }
            public string GroupId { get; set; }
            public string SiteId { get; set; }
            public string UserId { get; set; }
            public string ShareId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_Preview: return $"/drives/{DriveId}/items/{ItemId}/preview";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Preview: return $"/groups/{GroupId}/drive/items/{ItemId}/preview";
                    case ApiPath.Me_Drive_Items_ItemId_Preview: return $"/me/drive/items/{ItemId}/preview";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Preview: return $"/sites/{SiteId}/drive/items/{ItemId}/preview";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Preview: return $"/users/{UserId}/drive/items/{ItemId}/preview";
                    case ApiPath.Shares_ShareId_DriveItem_Preview: return $"/shares/{ShareId}/driveItem/preview";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Preview,
            Groups_GroupId_Drive_Items_ItemId_Preview,
            Me_Drive_Items_ItemId_Preview,
            Sites_SiteId_Drive_Items_ItemId_Preview,
            Users_UserId_Drive_Items_ItemId_Preview,
            Shares_ShareId_DriveItem_Preview,
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
        public string? Page { get; set; }
        public double? Zoom { get; set; }
    }
    public partial class DriveitemPreviewResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-preview?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemPreviewResponse> DriveitemPreviewAsync()
        {
            var p = new DriveitemPreviewParameter();
            return await this.SendAsync<DriveitemPreviewParameter, DriveitemPreviewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-preview?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemPreviewResponse> DriveitemPreviewAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemPreviewParameter();
            return await this.SendAsync<DriveitemPreviewParameter, DriveitemPreviewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-preview?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemPreviewResponse> DriveitemPreviewAsync(DriveitemPreviewParameter parameter)
        {
            return await this.SendAsync<DriveitemPreviewParameter, DriveitemPreviewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-preview?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemPreviewResponse> DriveitemPreviewAsync(DriveitemPreviewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemPreviewParameter, DriveitemPreviewResponse>(parameter, cancellationToken);
        }
    }
}
