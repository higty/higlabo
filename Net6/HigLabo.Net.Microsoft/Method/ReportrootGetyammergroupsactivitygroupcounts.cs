using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetyammergroupsactivitygroupcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerGroupsActivityGroupCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetYammerGroupsActivityGroupCounts: return $"/reports/getYammerGroupsActivityGroupCounts";
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
    public partial class ReportrootGetyammergroupsactivitygroupcountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitygroupcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitygroupcountsResponse> ReportrootGetyammergroupsactivitygroupcountsAsync()
        {
            var p = new ReportrootGetyammergroupsactivitygroupcountsParameter();
            return await this.SendAsync<ReportrootGetyammergroupsactivitygroupcountsParameter, ReportrootGetyammergroupsactivitygroupcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitygroupcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitygroupcountsResponse> ReportrootGetyammergroupsactivitygroupcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetyammergroupsactivitygroupcountsParameter();
            return await this.SendAsync<ReportrootGetyammergroupsactivitygroupcountsParameter, ReportrootGetyammergroupsactivitygroupcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitygroupcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitygroupcountsResponse> ReportrootGetyammergroupsactivitygroupcountsAsync(ReportrootGetyammergroupsactivitygroupcountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetyammergroupsactivitygroupcountsParameter, ReportrootGetyammergroupsactivitygroupcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitygroupcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitygroupcountsResponse> ReportrootGetyammergroupsactivitygroupcountsAsync(ReportrootGetyammergroupsactivitygroupcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetyammergroupsactivitygroupcountsParameter, ReportrootGetyammergroupsactivitygroupcountsResponse>(parameter, cancellationToken);
        }
    }
}
