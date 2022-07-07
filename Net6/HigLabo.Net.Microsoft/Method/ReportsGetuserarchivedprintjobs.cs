using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportsGetuserarchivedprintjobsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetUserArchivedPrintJobs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetUserArchivedPrintJobs: return $"/reports/getUserArchivedPrintJobs";
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
    public partial class ReportsGetuserarchivedprintjobsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetuserarchivedprintjobsResponse> ReportsGetuserarchivedprintjobsAsync()
        {
            var p = new ReportsGetuserarchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetuserarchivedprintjobsParameter, ReportsGetuserarchivedprintjobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetuserarchivedprintjobsResponse> ReportsGetuserarchivedprintjobsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportsGetuserarchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetuserarchivedprintjobsParameter, ReportsGetuserarchivedprintjobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetuserarchivedprintjobsResponse> ReportsGetuserarchivedprintjobsAsync(ReportsGetuserarchivedprintjobsParameter parameter)
        {
            return await this.SendAsync<ReportsGetuserarchivedprintjobsParameter, ReportsGetuserarchivedprintjobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetuserarchivedprintjobsResponse> ReportsGetuserarchivedprintjobsAsync(ReportsGetuserarchivedprintjobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportsGetuserarchivedprintjobsParameter, ReportsGetuserarchivedprintjobsResponse>(parameter, cancellationToken);
        }
    }
}
