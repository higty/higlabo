using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemListVersionsParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Drives_DriveId_Items_ItemId_Versions: return $"/drives/{DriveId}/items/{ItemId}/versions";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Versions: return $"/groups/{GroupId}/drive/items/{ItemId}/versions";
                    case ApiPath.Me_Drive_Items_ItemId_Versions: return $"/me/drive/items/{ItemId}/versions";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Versions: return $"/sites/{SiteId}/drive/items/{ItemId}/versions";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Versions: return $"/users/{UserId}/drive/items/{ItemId}/versions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Versions,
            Groups_GroupId_Drive_Items_ItemId_Versions,
            Me_Drive_Items_ItemId_Versions,
            Sites_SiteId_Drive_Items_ItemId_Versions,
            Users_UserId_Drive_Items_ItemId_Versions,
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
    public partial class DriveitemListVersionsResponse : RestApiResponse
    {
        public DriveItemVersion[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListVersionsResponse> DriveitemListVersionsAsync()
        {
            var p = new DriveitemListVersionsParameter();
            return await this.SendAsync<DriveitemListVersionsParameter, DriveitemListVersionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListVersionsResponse> DriveitemListVersionsAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemListVersionsParameter();
            return await this.SendAsync<DriveitemListVersionsParameter, DriveitemListVersionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListVersionsResponse> DriveitemListVersionsAsync(DriveitemListVersionsParameter parameter)
        {
            return await this.SendAsync<DriveitemListVersionsParameter, DriveitemListVersionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemListVersionsResponse> DriveitemListVersionsAsync(DriveitemListVersionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemListVersionsParameter, DriveitemListVersionsResponse>(parameter, cancellationToken);
        }
    }
}
