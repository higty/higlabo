using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootListDailyprintusagebyuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_DailyPrintUsageByUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_DailyPrintUsageByUser: return $"/reports/dailyPrintUsageByUser";
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
    public partial class ReportrootListDailyprintusagebyuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printusagebyuser?view=graph-rest-1.0
        /// </summary>
        public partial class PrintUsageByUser
        {
            public string? Id { get; set; }
            public string? UserPrincipalName { get; set; }
            public DateOnly? UsageDate { get; set; }
            public Int64? CompletedBlackAndWhiteJobCount { get; set; }
            public Int64? CompletedColorJobCount { get; set; }
            public Int64? IncompleteJobCount { get; set; }
        }

        public PrintUsageByUser[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListDailyprintusagebyuserResponse> ReportrootListDailyprintusagebyuserAsync()
        {
            var p = new ReportrootListDailyprintusagebyuserParameter();
            return await this.SendAsync<ReportrootListDailyprintusagebyuserParameter, ReportrootListDailyprintusagebyuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListDailyprintusagebyuserResponse> ReportrootListDailyprintusagebyuserAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootListDailyprintusagebyuserParameter();
            return await this.SendAsync<ReportrootListDailyprintusagebyuserParameter, ReportrootListDailyprintusagebyuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListDailyprintusagebyuserResponse> ReportrootListDailyprintusagebyuserAsync(ReportrootListDailyprintusagebyuserParameter parameter)
        {
            return await this.SendAsync<ReportrootListDailyprintusagebyuserParameter, ReportrootListDailyprintusagebyuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListDailyprintusagebyuserResponse> ReportrootListDailyprintusagebyuserAsync(ReportrootListDailyprintusagebyuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootListDailyprintusagebyuserParameter, ReportrootListDailyprintusagebyuserResponse>(parameter, cancellationToken);
        }
    }
}
