using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetsharepointactivityuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointActivityUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSharePointActivityUserDetail: return $"/reports/getSharePointActivityUserDetail";
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
    public partial class ReportrootGetsharepointactivityuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityuserdetailResponse> ReportrootGetsharepointactivityuserdetailAsync()
        {
            var p = new ReportrootGetsharepointactivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetsharepointactivityuserdetailParameter, ReportrootGetsharepointactivityuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityuserdetailResponse> ReportrootGetsharepointactivityuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetsharepointactivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetsharepointactivityuserdetailParameter, ReportrootGetsharepointactivityuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityuserdetailResponse> ReportrootGetsharepointactivityuserdetailAsync(ReportrootGetsharepointactivityuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetsharepointactivityuserdetailParameter, ReportrootGetsharepointactivityuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityuserdetailResponse> ReportrootGetsharepointactivityuserdetailAsync(ReportrootGetsharepointactivityuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetsharepointactivityuserdetailParameter, ReportrootGetsharepointactivityuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
