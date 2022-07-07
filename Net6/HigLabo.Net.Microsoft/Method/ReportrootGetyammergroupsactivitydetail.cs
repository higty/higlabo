using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetyammergroupsactivitydetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerGroupsActivityDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetYammerGroupsActivityDetail: return $"/reports/getYammerGroupsActivityDetail";
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
    public partial class ReportrootGetyammergroupsactivitydetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitydetailResponse> ReportrootGetyammergroupsactivitydetailAsync()
        {
            var p = new ReportrootGetyammergroupsactivitydetailParameter();
            return await this.SendAsync<ReportrootGetyammergroupsactivitydetailParameter, ReportrootGetyammergroupsactivitydetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitydetailResponse> ReportrootGetyammergroupsactivitydetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetyammergroupsactivitydetailParameter();
            return await this.SendAsync<ReportrootGetyammergroupsactivitydetailParameter, ReportrootGetyammergroupsactivitydetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitydetailResponse> ReportrootGetyammergroupsactivitydetailAsync(ReportrootGetyammergroupsactivitydetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetyammergroupsactivitydetailParameter, ReportrootGetyammergroupsactivitydetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammergroupsactivitydetailResponse> ReportrootGetyammergroupsactivitydetailAsync(ReportrootGetyammergroupsactivitydetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetyammergroupsactivitydetailParameter, ReportrootGetyammergroupsactivitydetailResponse>(parameter, cancellationToken);
        }
    }
}
