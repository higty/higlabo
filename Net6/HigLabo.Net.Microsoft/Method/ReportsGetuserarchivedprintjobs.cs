using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportsGetUserarchivedprintjobsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportsGetUserarchivedprintjobsResponse : RestApiResponse
    {
        public ArchivedPrintJob[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetUserarchivedprintjobsResponse> ReportsGetUserarchivedprintjobsAsync()
        {
            var p = new ReportsGetUserarchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetUserarchivedprintjobsParameter, ReportsGetUserarchivedprintjobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetUserarchivedprintjobsResponse> ReportsGetUserarchivedprintjobsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportsGetUserarchivedprintjobsParameter();
            return await this.SendAsync<ReportsGetUserarchivedprintjobsParameter, ReportsGetUserarchivedprintjobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetUserarchivedprintjobsResponse> ReportsGetUserarchivedprintjobsAsync(ReportsGetUserarchivedprintjobsParameter parameter)
        {
            return await this.SendAsync<ReportsGetUserarchivedprintjobsParameter, ReportsGetUserarchivedprintjobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reports-getuserarchivedprintjobs?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportsGetUserarchivedprintjobsResponse> ReportsGetUserarchivedprintjobsAsync(ReportsGetUserarchivedprintjobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportsGetUserarchivedprintjobsParameter, ReportsGetUserarchivedprintjobsResponse>(parameter, cancellationToken);
        }
    }
}
