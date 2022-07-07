using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintusagebyuserGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_DailyPrintUsageByUser_Id,
            Reports_MonthlyPrintUsageByUser_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_DailyPrintUsageByUser_Id: return $"/reports/dailyPrintUsageByUser/{Id}";
                    case ApiPath.Reports_MonthlyPrintUsageByUser_Id: return $"/reports/monthlyPrintUsageByUser/{Id}";
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
        public string Id { get; set; }
    }
    public partial class PrintusagebyuserGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? UserPrincipalName { get; set; }
        public DateOnly? UsageDate { get; set; }
        public Int64? CompletedBlackAndWhiteJobCount { get; set; }
        public Int64? CompletedColorJobCount { get; set; }
        public Int64? IncompleteJobCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printusagebyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyuserGetResponse> PrintusagebyuserGetAsync()
        {
            var p = new PrintusagebyuserGetParameter();
            return await this.SendAsync<PrintusagebyuserGetParameter, PrintusagebyuserGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printusagebyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyuserGetResponse> PrintusagebyuserGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintusagebyuserGetParameter();
            return await this.SendAsync<PrintusagebyuserGetParameter, PrintusagebyuserGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printusagebyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyuserGetResponse> PrintusagebyuserGetAsync(PrintusagebyuserGetParameter parameter)
        {
            return await this.SendAsync<PrintusagebyuserGetParameter, PrintusagebyuserGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printusagebyuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintusagebyuserGetResponse> PrintusagebyuserGetAsync(PrintusagebyuserGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintusagebyuserGetParameter, PrintusagebyuserGetResponse>(parameter, cancellationToken);
        }
    }
}
