using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public partial class ReportsGetGroupArchivedprintJobsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetGroupArchivedPrintJobs: return $"/reports/getGroupArchivedPrintJobs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetGroupArchivedPrintJobs,
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
    public partial class ReportsGetGroupArchivedprintJobsResponse : RestApiResponse<ArchivedPrintJob>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportsGetGroupArchivedprintJobsResponse> ReportsGetGroupArchivedprintJobsAsync()
        {
            var p = new ReportsGetGroupArchivedprintJobsParameter();
            return await this.SendAsync<ReportsGetGroupArchivedprintJobsParameter, ReportsGetGroupArchivedprintJobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportsGetGroupArchivedprintJobsResponse> ReportsGetGroupArchivedprintJobsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportsGetGroupArchivedprintJobsParameter();
            return await this.SendAsync<ReportsGetGroupArchivedprintJobsParameter, ReportsGetGroupArchivedprintJobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportsGetGroupArchivedprintJobsResponse> ReportsGetGroupArchivedprintJobsAsync(ReportsGetGroupArchivedprintJobsParameter parameter)
        {
            return await this.SendAsync<ReportsGetGroupArchivedprintJobsParameter, ReportsGetGroupArchivedprintJobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportsGetGroupArchivedprintJobsResponse> ReportsGetGroupArchivedprintJobsAsync(ReportsGetGroupArchivedprintJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportsGetGroupArchivedprintJobsParameter, ReportsGetGroupArchivedprintJobsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ArchivedPrintJob> ReportsGetGroupArchivedprintJobsEnumerateAsync(ReportsGetGroupArchivedprintJobsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ReportsGetGroupArchivedprintJobsParameter, ReportsGetGroupArchivedprintJobsResponse>(parameter, cancellationToken);
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
