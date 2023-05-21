using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-createuploadsession?view=graph-rest-1.0
    /// </summary>
    public partial class DriveitemCreateuploadsessionParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DriveId { get; set; }
            public string? ItemId { get; set; }
            public string? GroupId { get; set; }
            public string? FileName { get; set; }
            public string? SiteId { get; set; }
            public string? UserId { get; set; }
            public string? ItemPath { get; set; }
            public string? Path_to_parent { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_CreateUploadSession: return $"/drives/{DriveId}/items/{ItemId}/createUploadSession";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_CreateUploadSession: return $"/groups/{GroupId}/drive/items/{ItemId}/createUploadSession";
                    case ApiPath.Me_Drive_Items_ItemId_CreateUploadSession: return $"/me/drive/items/{ItemId}/createUploadSession";
                    case ApiPath.Me_Drive_Items_ItemId_FileName_CreateUploadSession: return $"/me/drive/items/{ItemId}:/{FileName}:/createUploadSession";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_CreateUploadSession: return $"/sites/{SiteId}/drive/items/{ItemId}/createUploadSession";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_CreateUploadSession: return $"/users/{UserId}/drive/items/{ItemId}/createUploadSession";
                    case ApiPath.Me_Drive_Root_ItemPath_CreateUploadSession: return $"/me/drive/root:/{ItemPath}:/createUploadSession";
                    case ApiPath.Ttps__Sn3302up1drvcom_Up_Fe6987415ace7X4e1eF866337: return $"/ttps://sn3302.up.1drv.com/up/fe6987415ace7X4e1eF866337";
                    case ApiPath.Ttps__Sn3302up1drvcom_Up_Fe6987415ace7X4e1eF86633784148bb98a1zjcUhf7b0mpUadahs: return $"/ttps://sn3302.up.1drv.com/up/fe6987415ace7X4e1eF86633784148bb98a1zjcUhf7b0mpUadahs";
                    case ApiPath.Me_Drive_Root_Path_to_parent: return $"/me/drive/root:/{Path_to_parent}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_CreateUploadSession,
            Groups_GroupId_Drive_Items_ItemId_CreateUploadSession,
            Me_Drive_Items_ItemId_CreateUploadSession,
            Me_Drive_Items_ItemId_FileName_CreateUploadSession,
            Sites_SiteId_Drive_Items_ItemId_CreateUploadSession,
            Users_UserId_Drive_Items_ItemId_CreateUploadSession,
            Me_Drive_Root_ItemPath_CreateUploadSession,
            Ttps__Sn3302up1drvcom_Up_Fe6987415ace7X4e1eF866337,
            Ttps__Sn3302up1drvcom_Up_Fe6987415ace7X4e1eF86633784148bb98a1zjcUhf7b0mpUadahs,
            Me_Drive_Root_Path_to_parent,
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
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public String[]? NextExpectedRanges { get; set; }
        public string? UploadUrl { get; set; }
    }
    public partial class DriveitemCreateuploadsessionResponse : RestApiResponse
    {
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public String[]? NextExpectedRanges { get; set; }
        public string? UploadUrl { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-createuploadsession?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCreateuploadsessionResponse> DriveitemCreateuploadsessionAsync()
        {
            var p = new DriveitemCreateuploadsessionParameter();
            return await this.SendAsync<DriveitemCreateuploadsessionParameter, DriveitemCreateuploadsessionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCreateuploadsessionResponse> DriveitemCreateuploadsessionAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemCreateuploadsessionParameter();
            return await this.SendAsync<DriveitemCreateuploadsessionParameter, DriveitemCreateuploadsessionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCreateuploadsessionResponse> DriveitemCreateuploadsessionAsync(DriveitemCreateuploadsessionParameter parameter)
        {
            return await this.SendAsync<DriveitemCreateuploadsessionParameter, DriveitemCreateuploadsessionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCreateuploadsessionResponse> DriveitemCreateuploadsessionAsync(DriveitemCreateuploadsessionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemCreateuploadsessionParameter, DriveitemCreateuploadsessionResponse>(parameter, cancellationToken);
        }
    }
}
