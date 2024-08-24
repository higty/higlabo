using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
    /// </summary>
    public partial class DriveItemDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DriveId { get; set; }
            public string? GroupId { get; set; }
            public string? SiteId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drives_DriveId_Root_Delta: return $"/drives/{DriveId}/root/delta";
                    case ApiPath.Groups_GroupId_Drive_Root_Delta: return $"/groups/{GroupId}/drive/root/delta";
                    case ApiPath.Me_Drive_Root_Delta: return $"/me/drive/root/delta";
                    case ApiPath.Sites_SiteId_Drive_Root_Delta: return $"/sites/{SiteId}/drive/root/delta";
                    case ApiPath.Users_UserId_Drive_Root_Delta: return $"/users/{UserId}/drive/root/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Drives_DriveId_Root_Delta,
            Groups_GroupId_Drive_Root_Delta,
            Me_Drive_Root_Delta,
            Sites_SiteId_Drive_Root_Delta,
            Users_UserId_Drive_Root_Delta,
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
    public partial class DriveItemDeltaResponse : RestApiResponse<DriveItem>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemDeltaResponse> DriveItemDeltaAsync()
        {
            var p = new DriveItemDeltaParameter();
            return await this.SendAsync<DriveItemDeltaParameter, DriveItemDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemDeltaResponse> DriveItemDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new DriveItemDeltaParameter();
            return await this.SendAsync<DriveItemDeltaParameter, DriveItemDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemDeltaResponse> DriveItemDeltaAsync(DriveItemDeltaParameter parameter)
        {
            return await this.SendAsync<DriveItemDeltaParameter, DriveItemDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemDeltaResponse> DriveItemDeltaAsync(DriveItemDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveItemDeltaParameter, DriveItemDeltaResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-delta?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DriveItem> DriveItemDeltaEnumerateAsync(DriveItemDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<DriveItemDeltaParameter, DriveItemDeltaResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DriveItem>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
