using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootListDailyprintusagebyprinterParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_DailyPrintUsageByPrinter,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_DailyPrintUsageByPrinter: return $"/reports/dailyPrintUsageByPrinter";
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
    public partial class ReportrootListDailyprintusagebyprinterResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public partial class PrintUsageByPrinter
        {
            public string? Id { get; set; }
            public string? PrinterID { get; set; }
            public DateOnly? UsageDate { get; set; }
            public Int64? CompletedBlackAndWhiteJobCount { get; set; }
            public Int64? CompletedColorJobCount { get; set; }
            public Int64? IncompleteJobCount { get; set; }
        }

        public PrintUsageByPrinter[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListDailyprintusagebyprinterResponse> ReportrootListDailyprintusagebyprinterAsync()
        {
            var p = new ReportrootListDailyprintusagebyprinterParameter();
            return await this.SendAsync<ReportrootListDailyprintusagebyprinterParameter, ReportrootListDailyprintusagebyprinterResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListDailyprintusagebyprinterResponse> ReportrootListDailyprintusagebyprinterAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootListDailyprintusagebyprinterParameter();
            return await this.SendAsync<ReportrootListDailyprintusagebyprinterParameter, ReportrootListDailyprintusagebyprinterResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListDailyprintusagebyprinterResponse> ReportrootListDailyprintusagebyprinterAsync(ReportrootListDailyprintusagebyprinterParameter parameter)
        {
            return await this.SendAsync<ReportrootListDailyprintusagebyprinterParameter, ReportrootListDailyprintusagebyprinterResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListDailyprintusagebyprinterResponse> ReportrootListDailyprintusagebyprinterAsync(ReportrootListDailyprintusagebyprinterParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootListDailyprintusagebyprinterParameter, ReportrootListDailyprintusagebyprinterResponse>(parameter, cancellationToken);
        }
    }
}
