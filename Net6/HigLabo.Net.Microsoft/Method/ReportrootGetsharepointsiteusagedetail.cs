using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetsharepointsiteusagedetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSharePointSiteUsageDetail: return $"/reports/getSharePointSiteUsageDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointSiteUsageDetail,
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
    public partial class ReportRootGetsharepointsiteusagedetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetsharepointsiteusagedetailResponse> ReportRootGetsharepointsiteusagedetailAsync()
        {
            var p = new ReportRootGetsharepointsiteusagedetailParameter();
            return await this.SendAsync<ReportRootGetsharepointsiteusagedetailParameter, ReportRootGetsharepointsiteusagedetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetsharepointsiteusagedetailResponse> ReportRootGetsharepointsiteusagedetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetsharepointsiteusagedetailParameter();
            return await this.SendAsync<ReportRootGetsharepointsiteusagedetailParameter, ReportRootGetsharepointsiteusagedetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetsharepointsiteusagedetailResponse> ReportRootGetsharepointsiteusagedetailAsync(ReportRootGetsharepointsiteusagedetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetsharepointsiteusagedetailParameter, ReportRootGetsharepointsiteusagedetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetsharepointsiteusagedetailResponse> ReportRootGetsharepointsiteusagedetailAsync(ReportRootGetsharepointsiteusagedetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetsharepointsiteusagedetailParameter, ReportRootGetsharepointsiteusagedetailResponse>(parameter, cancellationToken);
        }
    }
}
