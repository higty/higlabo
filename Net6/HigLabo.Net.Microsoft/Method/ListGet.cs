using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId,
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListTitle,
            Sites_SiteId_Lists_ListId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists/{ListId}";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListTitle: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists/{ListTitle}";
                    case ApiPath.Sites_SiteId_Lists_ListId: return $"/sites/{SiteId}/lists/{ListId}";
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
        public string ListTitle { get; set; }
    }
    public partial class ListGetResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ListGetResponse> ListGetAsync()
        {
            var p = new ListGetParameter();
            return await this.SendAsync<ListGetParameter, ListGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ListGetResponse> ListGetAsync(CancellationToken cancellationToken)
        {
            var p = new ListGetParameter();
            return await this.SendAsync<ListGetParameter, ListGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ListGetResponse> ListGetAsync(ListGetParameter parameter)
        {
            return await this.SendAsync<ListGetParameter, ListGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ListGetResponse> ListGetAsync(ListGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListGetParameter, ListGetResponse>(parameter, cancellationToken);
        }
    }
}
