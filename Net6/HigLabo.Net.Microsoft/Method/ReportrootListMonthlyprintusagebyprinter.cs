using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootListMonthlyprintusagebyprinterParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_MonthlyPrintUsageByPrinter,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_MonthlyPrintUsageByPrinter: return $"/reports/monthlyPrintUsageByPrinter";
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
    public partial class ReportrootListMonthlyprintusagebyprinterResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListMonthlyprintusagebyprinterResponse> ReportrootListMonthlyprintusagebyprinterAsync()
        {
            var p = new ReportrootListMonthlyprintusagebyprinterParameter();
            return await this.SendAsync<ReportrootListMonthlyprintusagebyprinterParameter, ReportrootListMonthlyprintusagebyprinterResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListMonthlyprintusagebyprinterResponse> ReportrootListMonthlyprintusagebyprinterAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootListMonthlyprintusagebyprinterParameter();
            return await this.SendAsync<ReportrootListMonthlyprintusagebyprinterParameter, ReportrootListMonthlyprintusagebyprinterResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListMonthlyprintusagebyprinterResponse> ReportrootListMonthlyprintusagebyprinterAsync(ReportrootListMonthlyprintusagebyprinterParameter parameter)
        {
            return await this.SendAsync<ReportrootListMonthlyprintusagebyprinterParameter, ReportrootListMonthlyprintusagebyprinterResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListMonthlyprintusagebyprinterResponse> ReportrootListMonthlyprintusagebyprinterAsync(ReportrootListMonthlyprintusagebyprinterParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootListMonthlyprintusagebyprinterParameter, ReportrootListMonthlyprintusagebyprinterResponse>(parameter, cancellationToken);
        }
    }
}
