using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListitemGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items_ItemId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items_ItemId: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists/{ListId}/items/{ItemId}";
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
        public string ItemId { get; set; }
    }
    public partial class ListitemGetResponse : RestApiResponse
    {
        public ContentTypeInfo? ContentType { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemGetResponse> ListitemGetAsync()
        {
            var p = new ListitemGetParameter();
            return await this.SendAsync<ListitemGetParameter, ListitemGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemGetResponse> ListitemGetAsync(CancellationToken cancellationToken)
        {
            var p = new ListitemGetParameter();
            return await this.SendAsync<ListitemGetParameter, ListitemGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemGetResponse> ListitemGetAsync(ListitemGetParameter parameter)
        {
            return await this.SendAsync<ListitemGetParameter, ListitemGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemGetResponse> ListitemGetAsync(ListitemGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListitemGetParameter, ListitemGetResponse>(parameter, cancellationToken);
        }
    }
}
