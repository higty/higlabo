using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetyammeractivityUserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetYammerActivityUserDetail: return $"/reports/getYammerActivityUserDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerActivityUserDetail,
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
    public partial class ReportRootGetyammeractivityUserdetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammeractivityUserdetailResponse> ReportRootGetyammeractivityUserdetailAsync()
        {
            var p = new ReportRootGetyammeractivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetyammeractivityUserdetailParameter, ReportRootGetyammeractivityUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammeractivityUserdetailResponse> ReportRootGetyammeractivityUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetyammeractivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetyammeractivityUserdetailParameter, ReportRootGetyammeractivityUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammeractivityUserdetailResponse> ReportRootGetyammeractivityUserdetailAsync(ReportRootGetyammeractivityUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetyammeractivityUserdetailParameter, ReportRootGetyammeractivityUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammeractivityUserdetailResponse> ReportRootGetyammeractivityUserdetailAsync(ReportRootGetyammeractivityUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetyammeractivityUserdetailParameter, ReportRootGetyammeractivityUserdetailResponse>(parameter, cancellationToken);
        }
    }
}
