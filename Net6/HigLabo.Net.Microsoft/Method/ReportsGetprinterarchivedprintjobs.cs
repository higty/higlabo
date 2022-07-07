using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportsGetprinterarchivedprintjobsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetPrinterArchivedPrintJobs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetPrinterArchivedPrintJobs: return $"/reports/getPrinterArchivedPrintJobs";
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
    }
    public partial class ReportsGetprinterarchivedprintjobsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/archivedprintjob?view=graph-rest-1.0
        /// </summary>
        public partial class ArchivedPrintJob
        {
            public string? Id { get; set; }
            public string? PrinterId { get; set; }
            public PrintJobProcessingState? ProcessingState { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? AcquiredDateTime { get; set; }
            public DateTimeOffset? CompletionDateTime { get; set; }
            public bool? AcquiredByPrinter { get; set; }
            public Int32? CopiesPrinted { get; set; }
            public UserIdentity? CreatedBy { get; set; }
        }

        public ArchivedPrintJob[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetprinterarchivedprintjobsResponse> ReportsGetprinterarchivedprintjobsAsync()
        {
            var p = new ReportsGetprinterarchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetprinterarchivedprintjobsParameter, ReportsGetprinterarchivedprintjobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetprinterarchivedprintjobsResponse> ReportsGetprinterarchivedprintjobsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportsGetprinterarchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetprinterarchivedprintjobsParameter, ReportsGetprinterarchivedprintjobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetprinterarchivedprintjobsResponse> ReportsGetprinterarchivedprintjobsAsync(ReportsGetprinterarchivedprintjobsParameter parameter)
        {
            return await this.SendAsync<ReportsGetprinterarchivedprintjobsParameter, ReportsGetprinterarchivedprintjobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetprinterarchivedprintjobsResponse> ReportsGetprinterarchivedprintjobsAsync(ReportsGetprinterarchivedprintjobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportsGetprinterarchivedprintjobsParameter, ReportsGetprinterarchivedprintjobsResponse>(parameter, cancellationToken);
        }
    }
}
