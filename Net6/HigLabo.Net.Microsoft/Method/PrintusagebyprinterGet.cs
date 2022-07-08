using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintusagebyprinterGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_DailyPrintUsageByPrinter_Id: return $"/reports/dailyPrintUsageByPrinter/{Id}";
                    case ApiPath.Reports_MonthlyPrintUsageByPrinter_Id: return $"/reports/monthlyPrintUsageByPrinter/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_DailyPrintUsageByPrinter_Id,
            Reports_MonthlyPrintUsageByPrinter_Id,
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
    public partial class PrintusagebyprinterGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? PrinterID { get; set; }
        public DateOnly? UsageDate { get; set; }
        public Int64? CompletedBlackAndWhiteJobCount { get; set; }
        public Int64? CompletedColorJobCount { get; set; }
        public Int64? IncompleteJobCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printusagebyprinter-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyprinterGetResponse> PrintusagebyprinterGetAsync()
        {
            var p = new PrintusagebyprinterGetParameter();
            return await this.SendAsync<PrintusagebyprinterGetParameter, PrintusagebyprinterGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printusagebyprinter-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyprinterGetResponse> PrintusagebyprinterGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintusagebyprinterGetParameter();
            return await this.SendAsync<PrintusagebyprinterGetParameter, PrintusagebyprinterGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printusagebyprinter-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyprinterGetResponse> PrintusagebyprinterGetAsync(PrintusagebyprinterGetParameter parameter)
        {
            return await this.SendAsync<PrintusagebyprinterGetParameter, PrintusagebyprinterGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printusagebyprinter-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyprinterGetResponse> PrintusagebyprinterGetAsync(PrintusagebyprinterGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintusagebyprinterGetParameter, PrintusagebyprinterGetResponse>(parameter, cancellationToken);
        }
    }
}
