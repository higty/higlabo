using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-create?view=graph-rest-1.0
    /// </summary>
    public partial class ListCreateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public ListInfo? List { get; set; }
        public System? System { get; set; }
        public ColumnDefinition[]? Columns { get; set; }
        public ContentType[]? ContentTypes { get; set; }
        public Drive? Drive { get; set; }
        public ListItem[]? Items { get; set; }
        public RichLongRunningOperation[]? Operations { get; set; }
        public Subscription[]? Subscriptions { get; set; }
    }
    public partial class ListCreateResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public ListInfo? List { get; set; }
        public System? System { get; set; }
        public ColumnDefinition[]? Columns { get; set; }
        public ContentType[]? ContentTypes { get; set; }
        public Drive? Drive { get; set; }
        public ListItem[]? Items { get; set; }
        public RichLongRunningOperation[]? Operations { get; set; }
        public Subscription[]? Subscriptions { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-create?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListCreateResponse> ListCreateAsync()
        {
            var p = new ListCreateParameter();
            return await this.SendAsync<ListCreateParameter, ListCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListCreateResponse> ListCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ListCreateParameter();
            return await this.SendAsync<ListCreateParameter, ListCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListCreateResponse> ListCreateAsync(ListCreateParameter parameter)
        {
            return await this.SendAsync<ListCreateParameter, ListCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListCreateResponse> ListCreateAsync(ListCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListCreateParameter, ListCreateResponse>(parameter, cancellationToken);
        }
    }
}
