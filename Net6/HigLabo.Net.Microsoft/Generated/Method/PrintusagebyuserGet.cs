using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printusagebyuser-get?view=graph-rest-1.0
    /// </summary>
    public partial class PrintusagebyUserGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_DailyPrintUsageByUser_Id: return $"/reports/dailyPrintUsageByUser/{Id}";
                    case ApiPath.Reports_MonthlyPrintUsageByUser_Id: return $"/reports/monthlyPrintUsageByUser/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_DailyPrintUsageByUser_Id,
            Reports_MonthlyPrintUsageByUser_Id,
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
    public partial class PrintusagebyUserGetResponse : RestApiResponse
    {
        public Int64? CompletedBlackAndWhiteJobCount { get; set; }
        public Int64? CompletedColorJobCount { get; set; }
        public string? Id { get; set; }
        public Int64? IncompleteJobCount { get; set; }
        public DateOnly? UsageDate { get; set; }
        public string? UserPrincipalName { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printusagebyuser-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printusagebyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyUserGetResponse> PrintusagebyUserGetAsync()
        {
            var p = new PrintusagebyUserGetParameter();
            return await this.SendAsync<PrintusagebyUserGetParameter, PrintusagebyUserGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printusagebyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyUserGetResponse> PrintusagebyUserGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintusagebyUserGetParameter();
            return await this.SendAsync<PrintusagebyUserGetParameter, PrintusagebyUserGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printusagebyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyUserGetResponse> PrintusagebyUserGetAsync(PrintusagebyUserGetParameter parameter)
        {
            return await this.SendAsync<PrintusagebyUserGetParameter, PrintusagebyUserGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printusagebyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyUserGetResponse> PrintusagebyUserGetAsync(PrintusagebyUserGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintusagebyUserGetParameter, PrintusagebyUserGetResponse>(parameter, cancellationToken);
        }
    }
}
