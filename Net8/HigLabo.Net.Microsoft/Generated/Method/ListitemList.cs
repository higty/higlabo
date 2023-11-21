using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
    /// </summary>
    public partial class ListitemListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ListId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_Items: return $"/sites/{SiteId}/lists/{ListId}/items";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ContentType,
            Activities,
            Analytics,
            DocumentSetVersions,
            DriveItem,
            Fields,
            Versions,
        }
        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_Items,
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
    public partial class ListitemListResponse : RestApiResponse
    {
        public ListItem[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListitemListResponse> ListitemListAsync()
        {
            var p = new ListitemListParameter();
            return await this.SendAsync<ListitemListParameter, ListitemListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListitemListResponse> ListitemListAsync(CancellationToken cancellationToken)
        {
            var p = new ListitemListParameter();
            return await this.SendAsync<ListitemListParameter, ListitemListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListitemListResponse> ListitemListAsync(ListitemListParameter parameter)
        {
            return await this.SendAsync<ListitemListParameter, ListitemListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListitemListResponse> ListitemListAsync(ListitemListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListitemListParameter, ListitemListResponse>(parameter, cancellationToken);
        }
    }
}
