using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListitemListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists/{ListId}/items";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string SiteId { get; set; }
        public string ListId { get; set; }
    }
    public partial class ListitemListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/listitem?view=graph-rest-1.0
        /// </summary>
        public partial class ListItem
        {
            public ContentTypeInfo? ContentType { get; set; }
        }

        public ListItem[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListResponse> ListitemListAsync()
        {
            var p = new ListitemListParameter();
            return await this.SendAsync<ListitemListParameter, ListitemListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListResponse> ListitemListAsync(CancellationToken cancellationToken)
        {
            var p = new ListitemListParameter();
            return await this.SendAsync<ListitemListParameter, ListitemListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListResponse> ListitemListAsync(ListitemListParameter parameter)
        {
            return await this.SendAsync<ListitemListParameter, ListitemListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListResponse> ListitemListAsync(ListitemListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListitemListParameter, ListitemListResponse>(parameter, cancellationToken);
        }
    }
}
