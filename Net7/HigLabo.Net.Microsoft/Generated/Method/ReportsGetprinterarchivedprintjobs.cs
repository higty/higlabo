using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public partial class ReportsGetprinterarchivedprintjobsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetPrinterArchivedPrintJobs: return $"/reports/getPrinterArchivedPrintJobs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetPrinterArchivedPrintJobs,
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
    public partial class ReportsGetprinterarchivedprintjobsResponse : RestApiResponse
    {
        public ArchivedPrintJob[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetprinterarchivedprintjobsResponse> ReportsGetprinterarchivedprintjobsAsync()
        {
            var p = new ReportsGetprinterarchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetprinterarchivedprintjobsParameter, ReportsGetprinterarchivedprintjobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetprinterarchivedprintjobsResponse> ReportsGetprinterarchivedprintjobsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportsGetprinterarchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetprinterarchivedprintjobsParameter, ReportsGetprinterarchivedprintjobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetprinterarchivedprintjobsResponse> ReportsGetprinterarchivedprintjobsAsync(ReportsGetprinterarchivedprintjobsParameter parameter)
        {
            return await this.SendAsync<ReportsGetprinterarchivedprintjobsParameter, ReportsGetprinterarchivedprintjobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetprinterarchivedprintjobsResponse> ReportsGetprinterarchivedprintjobsAsync(ReportsGetprinterarchivedprintjobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportsGetprinterarchivedprintjobsParameter, ReportsGetprinterarchivedprintjobsResponse>(parameter, cancellationToken);
        }
    }
}
