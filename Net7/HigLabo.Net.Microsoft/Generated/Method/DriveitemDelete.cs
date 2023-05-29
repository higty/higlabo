using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
    /// </summary>
    public partial class DriveitemDeleteParameter : IRestApiParameter
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
                    case ApiPath.Drives_DriveId_Items_ItemId: return $"/drives/{DriveId}/items/{ItemId}";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId: return $"/groups/{GroupId}/drive/items/{ItemId}";
                    case ApiPath.Me_Drive_Items_ItemId: return $"/me/drive/items/{ItemId}";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId: return $"/sites/{SiteId}/drive/items/{ItemId}";
                    case ApiPath.Users_UserId_Drive_Items_ItemId: return $"/users/{UserId}/drive/items/{ItemId}";
                    case ApiPath.RaphClient: return $"/raphClient ";
                    case ApiPath.Ptions: return $"/ptions ";
                    case ApiPath.Lient: return $"/lient ";
                    case ApiPath.Lientapi: return $"/lient.api";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId,
            Groups_GroupId_Drive_Items_ItemId,
            Me_Drive_Items_ItemId,
            Sites_SiteId_Drive_Items_ItemId,
            Users_UserId_Drive_Items_ItemId,
            RaphClient,
            Ptions,
            Lient,
            Lientapi,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class DriveitemDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemDeleteResponse> DriveitemDeleteAsync()
        {
            var p = new DriveitemDeleteParameter();
            return await this.SendAsync<DriveitemDeleteParameter, DriveitemDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemDeleteResponse> DriveitemDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemDeleteParameter();
            return await this.SendAsync<DriveitemDeleteParameter, DriveitemDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemDeleteResponse> DriveitemDeleteAsync(DriveitemDeleteParameter parameter)
        {
            return await this.SendAsync<DriveitemDeleteParameter, DriveitemDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemDeleteResponse> DriveitemDeleteAsync(DriveitemDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemDeleteParameter, DriveitemDeleteResponse>(parameter, cancellationToken);
        }
    }
}
