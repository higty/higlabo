using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetyammergroupsactivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerGroupsActivityCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetYammerGroupsActivityCounts: return $"/reports/getYammerGroupsActivityCounts";
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
    public partial class ReportrootGetyammergroupsactivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitycountsResponse> ReportrootGetyammergroupsactivitycountsAsync()
        {
            var p = new ReportrootGetyammergroupsactivitycountsParameter();
            return await this.SendAsync<ReportrootGetyammergroupsactivitycountsParameter, ReportrootGetyammergroupsactivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitycountsResponse> ReportrootGetyammergroupsactivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetyammergroupsactivitycountsParameter();
            return await this.SendAsync<ReportrootGetyammergroupsactivitycountsParameter, ReportrootGetyammergroupsactivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitycountsResponse> ReportrootGetyammergroupsactivitycountsAsync(ReportrootGetyammergroupsactivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetyammergroupsactivitycountsParameter, ReportrootGetyammergroupsactivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitycountsResponse> ReportrootGetyammergroupsactivitycountsAsync(ReportrootGetyammergroupsactivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetyammergroupsactivitycountsParameter, ReportrootGetyammergroupsactivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
