using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists";
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
    }
    public partial class ListListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/list?view=graph-rest-1.0
        /// </summary>
        public partial class SiteList
        {
            public string? DisplayName { get; set; }
            public ListInfo? List { get; set; }
            public System? System { get; set; }
        }

        public SiteList[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListResponse> ListListAsync()
        {
            var p = new ListListParameter();
            return await this.SendAsync<ListListParameter, ListListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListResponse> ListListAsync(CancellationToken cancellationToken)
        {
            var p = new ListListParameter();
            return await this.SendAsync<ListListParameter, ListListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListResponse> ListListAsync(ListListParameter parameter)
        {
            return await this.SendAsync<ListListParameter, ListListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListResponse> ListListAsync(ListListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListListParameter, ListListResponse>(parameter, cancellationToken);
        }
    }
}
