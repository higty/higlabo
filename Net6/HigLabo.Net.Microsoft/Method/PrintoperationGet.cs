using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintoperationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Operations_PrintOperationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Operations_PrintOperationId: return $"/print/operations/{PrintOperationId}";
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
        public string PrintOperationId { get; set; }
    }
    public partial class PrintoperationGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public PrintOperationStatus? Status { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintoperationGetResponse> PrintoperationGetAsync()
        {
            var p = new PrintoperationGetParameter();
            return await this.SendAsync<PrintoperationGetParameter, PrintoperationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintoperationGetResponse> PrintoperationGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintoperationGetParameter();
            return await this.SendAsync<PrintoperationGetParameter, PrintoperationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintoperationGetResponse> PrintoperationGetAsync(PrintoperationGetParameter parameter)
        {
            return await this.SendAsync<PrintoperationGetParameter, PrintoperationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintoperationGetResponse> PrintoperationGetAsync(PrintoperationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintoperationGetParameter, PrintoperationGetResponse>(parameter, cancellationToken);
        }
    }
}
