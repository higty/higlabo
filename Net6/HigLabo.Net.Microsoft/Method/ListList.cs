using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            List,
            System,
            Drive,
            Items,
            Columns,
            ContentTypes,
            Operations,
            Subscriptions,
        }
        public enum ApiPath
        {
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists,
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
    public partial class ListListResponse : RestApiResponse
    {
        public SiteList[]? Value { get; set; }
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
