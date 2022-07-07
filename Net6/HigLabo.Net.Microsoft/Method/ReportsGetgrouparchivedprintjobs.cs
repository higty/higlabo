using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportsGetgrouparchivedprintjobsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetGroupArchivedPrintJobs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetGroupArchivedPrintJobs: return $"/reports/getGroupArchivedPrintJobs";
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
    public partial class ReportsGetgrouparchivedprintjobsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetgrouparchivedprintjobsResponse> ReportsGetgrouparchivedprintjobsAsync()
        {
            var p = new ReportsGetgrouparchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetgrouparchivedprintjobsParameter, ReportsGetgrouparchivedprintjobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetgrouparchivedprintjobsResponse> ReportsGetgrouparchivedprintjobsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportsGetgrouparchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetgrouparchivedprintjobsParameter, ReportsGetgrouparchivedprintjobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetgrouparchivedprintjobsResponse> ReportsGetgrouparchivedprintjobsAsync(ReportsGetgrouparchivedprintjobsParameter parameter)
        {
            return await this.SendAsync<ReportsGetgrouparchivedprintjobsParameter, ReportsGetgrouparchivedprintjobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetgrouparchivedprintjobsResponse> ReportsGetgrouparchivedprintjobsAsync(ReportsGetgrouparchivedprintjobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportsGetgrouparchivedprintjobsParameter, ReportsGetgrouparchivedprintjobsResponse>(parameter, cancellationToken);
        }
    }
}
