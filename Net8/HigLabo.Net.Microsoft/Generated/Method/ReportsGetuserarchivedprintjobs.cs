using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public partial class ReportsGetUserArchivedprintJobsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetUserArchivedPrintJobs: return $"/reports/getUserArchivedPrintJobs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetUserArchivedPrintJobs,
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
    public partial class ReportsGetUserArchivedprintJobsResponse : RestApiResponse<ArchivedPrintJob>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportsGetUserArchivedprintJobsResponse> ReportsGetUserArchivedprintJobsAsync()
        {
            var p = new ReportsGetUserArchivedprintJobsParameter();
            return await this.SendAsync<ReportsGetUserArchivedprintJobsParameter, ReportsGetUserArchivedprintJobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportsGetUserArchivedprintJobsResponse> ReportsGetUserArchivedprintJobsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportsGetUserArchivedprintJobsParameter();
            return await this.SendAsync<ReportsGetUserArchivedprintJobsParameter, ReportsGetUserArchivedprintJobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportsGetUserArchivedprintJobsResponse> ReportsGetUserArchivedprintJobsAsync(ReportsGetUserArchivedprintJobsParameter parameter)
        {
            return await this.SendAsync<ReportsGetUserArchivedprintJobsParameter, ReportsGetUserArchivedprintJobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportsGetUserArchivedprintJobsResponse> ReportsGetUserArchivedprintJobsAsync(ReportsGetUserArchivedprintJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportsGetUserArchivedprintJobsParameter, ReportsGetUserArchivedprintJobsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ArchivedPrintJob> ReportsGetUserArchivedprintJobsEnumerateAsync(ReportsGetUserArchivedprintJobsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ReportsGetUserArchivedprintJobsParameter, ReportsGetUserArchivedprintJobsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ArchivedPrintJob>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
