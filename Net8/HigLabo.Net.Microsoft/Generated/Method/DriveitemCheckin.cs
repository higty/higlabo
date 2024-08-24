using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-checkin?view=graph-rest-1.0
    /// </summary>
    public partial class DriveItemCheckinParameter : IRestApiParameter
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
                    case ApiPath.Drives_DriveId_Items_ItemId_Checkin: return $"/drives/{DriveId}/items/{ItemId}/checkin";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Checkin: return $"/groups/{GroupId}/drive/items/{ItemId}/checkin";
                    case ApiPath.Me_Drive_Items_ItemId_Checkin: return $"/me/drive/items/{ItemId}/checkin";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Checkin: return $"/sites/{SiteId}/drive/items/{ItemId}/checkin";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Checkin: return $"/users/{UserId}/drive/items/{ItemId}/checkin";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Checkin,
            Groups_GroupId_Drive_Items_ItemId_Checkin,
            Me_Drive_Items_ItemId_Checkin,
            Sites_SiteId_Drive_Items_ItemId_Checkin,
            Users_UserId_Drive_Items_ItemId_Checkin,
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
        public string? CheckInAs { get; set; }
        public string? Comment { get; set; }
    }
    public partial class DriveItemCheckinResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-checkin?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-checkin?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemCheckinResponse> DriveItemCheckinAsync()
        {
            var p = new DriveItemCheckinParameter();
            return await this.SendAsync<DriveItemCheckinParameter, DriveItemCheckinResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-checkin?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemCheckinResponse> DriveItemCheckinAsync(CancellationToken cancellationToken)
        {
            var p = new DriveItemCheckinParameter();
            return await this.SendAsync<DriveItemCheckinParameter, DriveItemCheckinResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-checkin?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemCheckinResponse> DriveItemCheckinAsync(DriveItemCheckinParameter parameter)
        {
            return await this.SendAsync<DriveItemCheckinParameter, DriveItemCheckinResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-checkin?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemCheckinResponse> DriveItemCheckinAsync(DriveItemCheckinParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveItemCheckinParameter, DriveItemCheckinResponse>(parameter, cancellationToken);
        }
    }
}
