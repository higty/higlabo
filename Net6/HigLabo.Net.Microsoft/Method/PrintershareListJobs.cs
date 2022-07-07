using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintershareListJobsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Shares_PrinterShareId_Jobs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Shares_PrinterShareId_Jobs: return $"/print/shares/{PrinterShareId}/jobs";
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
        public string PrinterShareId { get; set; }
    }
    public partial class PrintershareListJobsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListJobsResponse> PrintershareListJobsAsync()
        {
            var p = new PrintershareListJobsParameter();
            return await this.SendAsync<PrintershareListJobsParameter, PrintershareListJobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListJobsResponse> PrintershareListJobsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintershareListJobsParameter();
            return await this.SendAsync<PrintershareListJobsParameter, PrintershareListJobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListJobsResponse> PrintershareListJobsAsync(PrintershareListJobsParameter parameter)
        {
            return await this.SendAsync<PrintershareListJobsParameter, PrintershareListJobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListJobsResponse> PrintershareListJobsAsync(PrintershareListJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintershareListJobsParameter, PrintershareListJobsResponse>(parameter, cancellationToken);
        }
    }
}
