using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list-operations?view=graph-rest-1.0
    /// </summary>
    public partial class ListListOperationsParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Sites_SiteId_Lists_ListId_Operations: return $"/sites/{SiteId}/lists/{ListId}/operations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Error,
            Id,
            LastActionDateTime,
            PercentageComplete,
            ResourceId,
            ResourceLocation,
            Status,
            StatusDetail,
            Type,
        }
        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_Operations,
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
    public partial class ListListOperationsResponse : RestApiResponse
    {
        public RichLongRunningOperation[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list-operations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list-operations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListListOperationsResponse> ListListOperationsAsync()
        {
            var p = new ListListOperationsParameter();
            return await this.SendAsync<ListListOperationsParameter, ListListOperationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list-operations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListListOperationsResponse> ListListOperationsAsync(CancellationToken cancellationToken)
        {
            var p = new ListListOperationsParameter();
            return await this.SendAsync<ListListOperationsParameter, ListListOperationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list-operations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListListOperationsResponse> ListListOperationsAsync(ListListOperationsParameter parameter)
        {
            return await this.SendAsync<ListListOperationsParameter, ListListOperationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list-operations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListListOperationsResponse> ListListOperationsAsync(ListListOperationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListListOperationsParameter, ListListOperationsResponse>(parameter, cancellationToken);
        }
    }
}
