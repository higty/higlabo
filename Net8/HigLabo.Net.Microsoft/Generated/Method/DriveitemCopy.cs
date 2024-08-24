using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-copy?view=graph-rest-1.0
    /// </summary>
    public partial class DriveItemCopyParameter : IRestApiParameter
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
                    case ApiPath.Drives_DriveId_Items_ItemId_Copy: return $"/drives/{DriveId}/items/{ItemId}/copy";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Copy: return $"/groups/{GroupId}/drive/items/{ItemId}/copy";
                    case ApiPath.Me_Drive_Items_ItemId_Copy: return $"/me/drive/items/{ItemId}/copy";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Copy: return $"/sites/{SiteId}/drive/items/{ItemId}/copy";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Copy: return $"/users/{UserId}/drive/items/{ItemId}/copy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Copy,
            Groups_GroupId_Drive_Items_ItemId_Copy,
            Me_Drive_Items_ItemId_Copy,
            Sites_SiteId_Drive_Items_ItemId_Copy,
            Users_UserId_Drive_Items_ItemId_Copy,
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
        public ItemReference? ParentReference { get; set; }
        public string? Name { get; set; }
    }
    public partial class DriveItemCopyResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-copy?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-copy?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemCopyResponse> DriveItemCopyAsync()
        {
            var p = new DriveItemCopyParameter();
            return await this.SendAsync<DriveItemCopyParameter, DriveItemCopyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-copy?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemCopyResponse> DriveItemCopyAsync(CancellationToken cancellationToken)
        {
            var p = new DriveItemCopyParameter();
            return await this.SendAsync<DriveItemCopyParameter, DriveItemCopyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-copy?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemCopyResponse> DriveItemCopyAsync(DriveItemCopyParameter parameter)
        {
            return await this.SendAsync<DriveItemCopyParameter, DriveItemCopyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-copy?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemCopyResponse> DriveItemCopyAsync(DriveItemCopyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveItemCopyParameter, DriveItemCopyResponse>(parameter, cancellationToken);
        }
    }
}
