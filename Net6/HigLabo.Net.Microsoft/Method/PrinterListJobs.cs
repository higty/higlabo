using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterListJobsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_Jobs: return $"/print/printers/{PrinterId}/jobs";
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
        public string PrinterId { get; set; }
    }
    public partial class PrinterListJobsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printjob?view=graph-rest-1.0
        /// </summary>
        public partial class PrintJob
        {
            public string? Id { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public PrintJobStatus? Status { get; set; }
            public PrintJobConfiguration? Configuration { get; set; }
            public Boolean? IsFetchable { get; set; }
            public String? RedirectedFrom { get; set; }
            public String? RedirectedTo { get; set; }
            public UserIdentity? CreatedBy { get; set; }
        }

        public PrintJob[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListJobsResponse> PrinterListJobsAsync()
        {
            var p = new PrinterListJobsParameter();
            return await this.SendAsync<PrinterListJobsParameter, PrinterListJobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListJobsResponse> PrinterListJobsAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterListJobsParameter();
            return await this.SendAsync<PrinterListJobsParameter, PrinterListJobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListJobsResponse> PrinterListJobsAsync(PrinterListJobsParameter parameter)
        {
            return await this.SendAsync<PrinterListJobsParameter, PrinterListJobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListJobsResponse> PrinterListJobsAsync(PrinterListJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterListJobsParameter, PrinterListJobsResponse>(parameter, cancellationToken);
        }
    }
}
