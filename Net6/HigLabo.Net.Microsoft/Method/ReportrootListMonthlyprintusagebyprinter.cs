using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootListMonthlyprintusagebyprinterParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_MonthlyPrintUsageByPrinter: return $"/reports/monthlyPrintUsageByPrinter";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_MonthlyPrintUsageByPrinter,
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
    public partial class ReportRootListMonthlyprintusagebyprinterResponse : RestApiResponse
    {
        public PrintUsageByPrinter[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootListMonthlyprintusagebyprinterResponse> ReportRootListMonthlyprintusagebyprinterAsync()
        {
            var p = new ReportRootListMonthlyprintusagebyprinterParameter();
            return await this.SendAsync<ReportRootListMonthlyprintusagebyprinterParameter, ReportRootListMonthlyprintusagebyprinterResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootListMonthlyprintusagebyprinterResponse> ReportRootListMonthlyprintusagebyprinterAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootListMonthlyprintusagebyprinterParameter();
            return await this.SendAsync<ReportRootListMonthlyprintusagebyprinterParameter, ReportRootListMonthlyprintusagebyprinterResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootListMonthlyprintusagebyprinterResponse> ReportRootListMonthlyprintusagebyprinterAsync(ReportRootListMonthlyprintusagebyprinterParameter parameter)
        {
            return await this.SendAsync<ReportRootListMonthlyprintusagebyprinterParameter, ReportRootListMonthlyprintusagebyprinterResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyprinter?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootListMonthlyprintusagebyprinterResponse> ReportRootListMonthlyprintusagebyprinterAsync(ReportRootListMonthlyprintusagebyprinterParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootListMonthlyprintusagebyprinterParameter, ReportRootListMonthlyprintusagebyprinterResponse>(parameter, cancellationToken);
        }
    }
}
