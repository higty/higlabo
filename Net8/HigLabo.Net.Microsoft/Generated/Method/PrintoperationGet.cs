using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printoperation-get?view=graph-rest-1.0
    /// </summary>
    public partial class PrintOperationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrintOperationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Operations_PrintOperationId: return $"/print/operations/{PrintOperationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Operations_PrintOperationId,
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
    public partial class PrintOperationGetResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public PrintOperationStatus? Status { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printoperation-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printoperation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintOperationGetResponse> PrintOperationGetAsync()
        {
            var p = new PrintOperationGetParameter();
            return await this.SendAsync<PrintOperationGetParameter, PrintOperationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printoperation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintOperationGetResponse> PrintOperationGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintOperationGetParameter();
            return await this.SendAsync<PrintOperationGetParameter, PrintOperationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printoperation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintOperationGetResponse> PrintOperationGetAsync(PrintOperationGetParameter parameter)
        {
            return await this.SendAsync<PrintOperationGetParameter, PrintOperationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printoperation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintOperationGetResponse> PrintOperationGetAsync(PrintOperationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintOperationGetParameter, PrintOperationGetResponse>(parameter, cancellationToken);
        }
    }
}
