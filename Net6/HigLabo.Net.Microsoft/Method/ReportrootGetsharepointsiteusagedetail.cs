using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetsharepointsiteusagedetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointSiteUsageDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSharePointSiteUsageDetail: return $"/reports/getSharePointSiteUsageDetail";
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
    public partial class ReportrootGetsharepointsiteusagedetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagedetailResponse> ReportrootGetsharepointsiteusagedetailAsync()
        {
            var p = new ReportrootGetsharepointsiteusagedetailParameter();
            return await this.SendAsync<ReportrootGetsharepointsiteusagedetailParameter, ReportrootGetsharepointsiteusagedetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagedetailResponse> ReportrootGetsharepointsiteusagedetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetsharepointsiteusagedetailParameter();
            return await this.SendAsync<ReportrootGetsharepointsiteusagedetailParameter, ReportrootGetsharepointsiteusagedetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagedetailResponse> ReportrootGetsharepointsiteusagedetailAsync(ReportrootGetsharepointsiteusagedetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetsharepointsiteusagedetailParameter, ReportrootGetsharepointsiteusagedetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagedetailResponse> ReportrootGetsharepointsiteusagedetailAsync(ReportrootGetsharepointsiteusagedetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetsharepointsiteusagedetailParameter, ReportrootGetsharepointsiteusagedetailResponse>(parameter, cancellationToken);
        }
    }
}
