using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetyammerActivityUserdetailParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetyammerActivityUserdetailResponse : RestApiResponse
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
        public async ValueTask<ReportRootGetyammerActivityUserdetailResponse> ReportRootGetyammerActivityUserdetailAsync()
        {
            var p = new ReportRootGetyammerActivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetyammerActivityUserdetailParameter, ReportRootGetyammerActivityUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerActivityUserdetailResponse> ReportRootGetyammerActivityUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetyammerActivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetyammerActivityUserdetailParameter, ReportRootGetyammerActivityUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerActivityUserdetailResponse> ReportRootGetyammerActivityUserdetailAsync(ReportRootGetyammerActivityUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetyammerActivityUserdetailParameter, ReportRootGetyammerActivityUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerActivityUserdetailResponse> ReportRootGetyammerActivityUserdetailAsync(ReportRootGetyammerActivityUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetyammerActivityUserdetailParameter, ReportRootGetyammerActivityUserdetailResponse>(parameter, cancellationToken);
        }
    }
}
