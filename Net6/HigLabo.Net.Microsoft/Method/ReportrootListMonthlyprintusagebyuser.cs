using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootListMonthlyprintusagebyuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_MonthlyPrintUsageByUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_MonthlyPrintUsageByUser: return $"/reports/monthlyPrintUsageByUser";
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
    public partial class ReportrootListMonthlyprintusagebyuserResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListMonthlyprintusagebyuserResponse> ReportrootListMonthlyprintusagebyuserAsync()
        {
            var p = new ReportrootListMonthlyprintusagebyuserParameter();
            return await this.SendAsync<ReportrootListMonthlyprintusagebyuserParameter, ReportrootListMonthlyprintusagebyuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListMonthlyprintusagebyuserResponse> ReportrootListMonthlyprintusagebyuserAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootListMonthlyprintusagebyuserParameter();
            return await this.SendAsync<ReportrootListMonthlyprintusagebyuserParameter, ReportrootListMonthlyprintusagebyuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListMonthlyprintusagebyuserResponse> ReportrootListMonthlyprintusagebyuserAsync(ReportrootListMonthlyprintusagebyuserParameter parameter)
        {
            return await this.SendAsync<ReportrootListMonthlyprintusagebyuserParameter, ReportrootListMonthlyprintusagebyuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootListMonthlyprintusagebyuserResponse> ReportrootListMonthlyprintusagebyuserAsync(ReportrootListMonthlyprintusagebyuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootListMonthlyprintusagebyuserParameter, ReportrootListMonthlyprintusagebyuserResponse>(parameter, cancellationToken);
        }
    }
}
