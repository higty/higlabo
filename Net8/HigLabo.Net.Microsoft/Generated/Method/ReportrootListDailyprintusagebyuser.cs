using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootListDailyprintusagebyUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_DailyPrintUsageByUser: return $"/reports/dailyPrintUsageByUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_DailyPrintUsageByUser,
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
    public partial class ReportRootListDailyprintusagebyUserResponse : RestApiResponse<PrintUsageByUser>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootListDailyprintusagebyUserResponse> ReportRootListDailyprintusagebyUserAsync()
        {
            var p = new ReportRootListDailyprintusagebyUserParameter();
            return await this.SendAsync<ReportRootListDailyprintusagebyUserParameter, ReportRootListDailyprintusagebyUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootListDailyprintusagebyUserResponse> ReportRootListDailyprintusagebyUserAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootListDailyprintusagebyUserParameter();
            return await this.SendAsync<ReportRootListDailyprintusagebyUserParameter, ReportRootListDailyprintusagebyUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootListDailyprintusagebyUserResponse> ReportRootListDailyprintusagebyUserAsync(ReportRootListDailyprintusagebyUserParameter parameter)
        {
            return await this.SendAsync<ReportRootListDailyprintusagebyUserParameter, ReportRootListDailyprintusagebyUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootListDailyprintusagebyUserResponse> ReportRootListDailyprintusagebyUserAsync(ReportRootListDailyprintusagebyUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootListDailyprintusagebyUserParameter, ReportRootListDailyprintusagebyUserResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyuser?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PrintUsageByUser> ReportRootListDailyprintusagebyUserEnumerateAsync(ReportRootListDailyprintusagebyUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ReportRootListDailyprintusagebyUserParameter, ReportRootListDailyprintusagebyUserResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<PrintUsageByUser>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
