using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemCopyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string DriveId { get; set; }
            public string ItemId { get; set; }
            public string GroupId { get; set; }
            public string SiteId { get; set; }
            public string UserId { get; set; }

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
    public partial class DriveitemCopyResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCopyResponse> DriveitemCopyAsync()
        {
            var p = new DriveitemCopyParameter();
            return await this.SendAsync<DriveitemCopyParameter, DriveitemCopyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCopyResponse> DriveitemCopyAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemCopyParameter();
            return await this.SendAsync<DriveitemCopyParameter, DriveitemCopyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCopyResponse> DriveitemCopyAsync(DriveitemCopyParameter parameter)
        {
            return await this.SendAsync<DriveitemCopyParameter, DriveitemCopyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCopyResponse> DriveitemCopyAsync(DriveitemCopyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemCopyParameter, DriveitemCopyResponse>(parameter, cancellationToken);
        }
    }
}
