using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list-versions?view=graph-rest-1.0
    /// </summary>
    public partial class ListitemListVersionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ItemId { get; set; }
            public string? ListId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Items_ItemId_Versions: return $"/sites/{SiteId}/items/{ItemId}/versions";
                    case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId_Versions: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}/versions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_Items_ItemId_Versions,
            Sites_SiteId_Lists_ListId_Items_ItemId_Versions,
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
    public partial class ListitemListVersionsResponse : RestApiResponse
    {
        public ListItemVersion[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list-versions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListVersionsResponse> ListitemListVersionsAsync()
        {
            var p = new ListitemListVersionsParameter();
            return await this.SendAsync<ListitemListVersionsParameter, ListitemListVersionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListVersionsResponse> ListitemListVersionsAsync(CancellationToken cancellationToken)
        {
            var p = new ListitemListVersionsParameter();
            return await this.SendAsync<ListitemListVersionsParameter, ListitemListVersionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListVersionsResponse> ListitemListVersionsAsync(ListitemListVersionsParameter parameter)
        {
            return await this.SendAsync<ListitemListVersionsParameter, ListitemListVersionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list-versions?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListVersionsResponse> ListitemListVersionsAsync(ListitemListVersionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListitemListVersionsParameter, ListitemListVersionsResponse>(parameter, cancellationToken);
        }
    }
}
