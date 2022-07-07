using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteListOperationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_Operations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_Operations: return $"/sites/{SiteId}/operations";
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
    public partial class SiteListOperationsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/richlongrunningoperation?view=graph-rest-1.0
        /// </summary>
        public partial class RichLongRunningOperation
        {
            public enum RichLongRunningOperationLongRunningOperationStatus
            {
                NotStarted,
                Running,
                Succeeded,
                Failed,
                UnknownFutureValue,
            }

            public DateTimeOffset? CreatedDateTime { get; set; }
            public PublicError? Error { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? LastActionDateTime { get; set; }
            public Int32? PercentageComplete { get; set; }
            public string? ResourceId { get; set; }
            public string? ResourceLocation { get; set; }
            public RichLongRunningOperationLongRunningOperationStatus Status { get; set; }
            public string? StatusDetail { get; set; }
            public string? Type { get; set; }
        }

        public RichLongRunningOperation[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListOperationsResponse> SiteListOperationsAsync()
        {
            var p = new SiteListOperationsParameter();
            return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListOperationsResponse> SiteListOperationsAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListOperationsParameter();
            return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListOperationsResponse> SiteListOperationsAsync(SiteListOperationsParameter parameter)
        {
            return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListOperationsResponse> SiteListOperationsAsync(SiteListOperationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(parameter, cancellationToken);
        }
    }
}
