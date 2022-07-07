using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetyammeractivityuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerActivityUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetYammerActivityUserDetail: return $"/reports/getYammerActivityUserDetail";
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
    public partial class ReportrootGetyammeractivityuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivityuserdetailResponse> ReportrootGetyammeractivityuserdetailAsync()
        {
            var p = new ReportrootGetyammeractivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetyammeractivityuserdetailParameter, ReportrootGetyammeractivityuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivityuserdetailResponse> ReportrootGetyammeractivityuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetyammeractivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetyammeractivityuserdetailParameter, ReportrootGetyammeractivityuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivityuserdetailResponse> ReportrootGetyammeractivityuserdetailAsync(ReportrootGetyammeractivityuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetyammeractivityuserdetailParameter, ReportrootGetyammeractivityuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivityuserdetailResponse> ReportrootGetyammeractivityuserdetailAsync(ReportrootGetyammeractivityuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetyammeractivityuserdetailParameter, ReportrootGetyammeractivityuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
