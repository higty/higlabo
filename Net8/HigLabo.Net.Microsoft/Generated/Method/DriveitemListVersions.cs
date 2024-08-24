using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
    /// </summary>
    public partial class DriveItemListVersionsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class DriveItemListVersionsResponse : RestApiResponse<DriveItemVersion>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemListVersionsResponse> DriveItemListVersionsAsync()
        {
            var p = new DriveItemListVersionsParameter();
            return await this.SendAsync<DriveItemListVersionsParameter, DriveItemListVersionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemListVersionsResponse> DriveItemListVersionsAsync(CancellationToken cancellationToken)
        {
            var p = new DriveItemListVersionsParameter();
            return await this.SendAsync<DriveItemListVersionsParameter, DriveItemListVersionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemListVersionsResponse> DriveItemListVersionsAsync(DriveItemListVersionsParameter parameter)
        {
            return await this.SendAsync<DriveItemListVersionsParameter, DriveItemListVersionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemListVersionsResponse> DriveItemListVersionsAsync(DriveItemListVersionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveItemListVersionsParameter, DriveItemListVersionsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DriveItemVersion> DriveItemListVersionsEnumerateAsync(DriveItemListVersionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<DriveItemListVersionsParameter, DriveItemListVersionsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DriveItemVersion>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
