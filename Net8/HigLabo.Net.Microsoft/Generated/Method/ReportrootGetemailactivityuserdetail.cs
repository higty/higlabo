using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetemailActivityUserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetEmailActivityUserDetail: return $"/reports/getEmailActivityUserDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailActivityUserDetail,
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
    public partial class ReportRootGetemailActivityUserdetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailActivityUserdetailResponse> ReportRootGetemailActivityUserdetailAsync()
        {
            var p = new ReportRootGetemailActivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetemailActivityUserdetailParameter, ReportRootGetemailActivityUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailActivityUserdetailResponse> ReportRootGetemailActivityUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetemailActivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetemailActivityUserdetailParameter, ReportRootGetemailActivityUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailActivityUserdetailResponse> ReportRootGetemailActivityUserdetailAsync(ReportRootGetemailActivityUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetemailActivityUserdetailParameter, ReportRootGetemailActivityUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailActivityUserdetailResponse> ReportRootGetemailActivityUserdetailAsync(ReportRootGetemailActivityUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetemailActivityUserdetailParameter, ReportRootGetemailActivityUserdetailResponse>(parameter, cancellationToken);
        }
    }
}
