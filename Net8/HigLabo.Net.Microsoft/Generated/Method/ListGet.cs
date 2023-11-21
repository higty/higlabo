using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-get?view=graph-rest-1.0
    /// </summary>
    public partial class ListGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ListId { get; set; }
            public string? ListTitle { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId: return $"/sites/{SiteId}/lists/{ListId}";
                    case ApiPath.Sites_SiteId_Lists_ListTitle: return $"/sites/{SiteId}/lists/{ListTitle}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId,
            Sites_SiteId_Lists_ListTitle,
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
    public partial class ListGetResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListGetResponse> ListGetAsync()
        {
            var p = new ListGetParameter();
            return await this.SendAsync<ListGetParameter, ListGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListGetResponse> ListGetAsync(CancellationToken cancellationToken)
        {
            var p = new ListGetParameter();
            return await this.SendAsync<ListGetParameter, ListGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListGetResponse> ListGetAsync(ListGetParameter parameter)
        {
            return await this.SendAsync<ListGetParameter, ListGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListGetResponse> ListGetAsync(ListGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListGetParameter, ListGetResponse>(parameter, cancellationToken);
        }
    }
}
