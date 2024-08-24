using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-delete?view=graph-rest-1.0
    /// </summary>
    public partial class ListItemDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ListId { get; set; }
            public string? ItemId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_Items_ItemId,
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
    public partial class ListItemDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemDeleteResponse> ListItemDeleteAsync()
        {
            var p = new ListItemDeleteParameter();
            return await this.SendAsync<ListItemDeleteParameter, ListItemDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemDeleteResponse> ListItemDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ListItemDeleteParameter();
            return await this.SendAsync<ListItemDeleteParameter, ListItemDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemDeleteResponse> ListItemDeleteAsync(ListItemDeleteParameter parameter)
        {
            return await this.SendAsync<ListItemDeleteParameter, ListItemDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemDeleteResponse> ListItemDeleteAsync(ListItemDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListItemDeleteParameter, ListItemDeleteResponse>(parameter, cancellationToken);
        }
    }
}
