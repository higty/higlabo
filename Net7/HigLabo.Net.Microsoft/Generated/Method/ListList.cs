using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list?view=graph-rest-1.0
    /// </summary>
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
                    case ApiPath.Sites_SiteId_Lists: return $"/sites/{SiteId}/lists";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            List,
            System,
            Columns,
            ContentTypes,
            Drive,
            Items,
            Operations,
            Subscriptions,
        }
        public enum ApiPath
        {
            Sites_SiteId_Lists,
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListListResponse> ListListAsync()
        {
            var p = new ListListParameter();
            return await this.SendAsync<ListListParameter, ListListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListListResponse> ListListAsync(CancellationToken cancellationToken)
        {
            var p = new ListListParameter();
            return await this.SendAsync<ListListParameter, ListListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListListResponse> ListListAsync(ListListParameter parameter)
        {
            return await this.SendAsync<ListListParameter, ListListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListListResponse> ListListAsync(ListListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListListParameter, ListListResponse>(parameter, cancellationToken);
        }
    }
}
