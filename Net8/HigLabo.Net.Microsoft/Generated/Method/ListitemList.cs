using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
    /// </summary>
    public partial class ListItemListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ListItemListResponse : RestApiResponse<ListItem>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemListResponse> ListItemListAsync()
        {
            var p = new ListItemListParameter();
            return await this.SendAsync<ListItemListParameter, ListItemListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemListResponse> ListItemListAsync(CancellationToken cancellationToken)
        {
            var p = new ListItemListParameter();
            return await this.SendAsync<ListItemListParameter, ListItemListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemListResponse> ListItemListAsync(ListItemListParameter parameter)
        {
            return await this.SendAsync<ListItemListParameter, ListItemListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemListResponse> ListItemListAsync(ListItemListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListItemListParameter, ListItemListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ListItem> ListItemListEnumerateAsync(ListItemListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ListItemListParameter, ListItemListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ListItem>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
