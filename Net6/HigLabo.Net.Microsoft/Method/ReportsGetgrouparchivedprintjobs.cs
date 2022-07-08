using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportsGetGrouparchivedprintjobsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportsGetGrouparchivedprintjobsResponse : RestApiResponse
    {
        public ArchivedPrintJob[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetGrouparchivedprintjobsResponse> ReportsGetGrouparchivedprintjobsAsync()
        {
            var p = new ReportsGetGrouparchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetGrouparchivedprintjobsParameter, ReportsGetGrouparchivedprintjobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetGrouparchivedprintjobsResponse> ReportsGetGrouparchivedprintjobsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportsGetGrouparchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetGrouparchivedprintjobsParameter, ReportsGetGrouparchivedprintjobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetGrouparchivedprintjobsResponse> ReportsGetGrouparchivedprintjobsAsync(ReportsGetGrouparchivedprintjobsParameter parameter)
        {
            return await this.SendAsync<ReportsGetGrouparchivedprintjobsParameter, ReportsGetGrouparchivedprintjobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getgrouparchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetGrouparchivedprintjobsResponse> ReportsGetGrouparchivedprintjobsAsync(ReportsGetGrouparchivedprintjobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportsGetGrouparchivedprintjobsParameter, ReportsGetGrouparchivedprintjobsResponse>(parameter, cancellationToken);
        }
    }
}
