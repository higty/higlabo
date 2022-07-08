using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootListMonthlyprintusagebyUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_MonthlyPrintUsageByUser: return $"/reports/monthlyPrintUsageByUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_MonthlyPrintUsageByUser,
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
    public partial class ReportRootListMonthlyprintusagebyUserResponse : RestApiResponse
    {
        public PrintUsageByUser[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootListMonthlyprintusagebyUserResponse> ReportRootListMonthlyprintusagebyUserAsync()
        {
            var p = new ReportRootListMonthlyprintusagebyUserParameter();
            return await this.SendAsync<ReportRootListMonthlyprintusagebyUserParameter, ReportRootListMonthlyprintusagebyUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootListMonthlyprintusagebyUserResponse> ReportRootListMonthlyprintusagebyUserAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootListMonthlyprintusagebyUserParameter();
            return await this.SendAsync<ReportRootListMonthlyprintusagebyUserParameter, ReportRootListMonthlyprintusagebyUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootListMonthlyprintusagebyUserResponse> ReportRootListMonthlyprintusagebyUserAsync(ReportRootListMonthlyprintusagebyUserParameter parameter)
        {
            return await this.SendAsync<ReportRootListMonthlyprintusagebyUserParameter, ReportRootListMonthlyprintusagebyUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootListMonthlyprintusagebyUserResponse> ReportRootListMonthlyprintusagebyUserAsync(ReportRootListMonthlyprintusagebyUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootListMonthlyprintusagebyUserParameter, ReportRootListMonthlyprintusagebyUserResponse>(parameter, cancellationToken);
        }
    }
}
