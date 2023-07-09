using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetemailappusageUserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetEmailAppUsageUserDetail: return $"/reports/getEmailAppUsageUserDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailAppUsageUserDetail,
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
    public partial class ReportRootGetemailappusageUserdetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageUserdetailResponse> ReportRootGetemailappusageUserdetailAsync()
        {
            var p = new ReportRootGetemailappusageUserdetailParameter();
            return await this.SendAsync<ReportRootGetemailappusageUserdetailParameter, ReportRootGetemailappusageUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageUserdetailResponse> ReportRootGetemailappusageUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetemailappusageUserdetailParameter();
            return await this.SendAsync<ReportRootGetemailappusageUserdetailParameter, ReportRootGetemailappusageUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageUserdetailResponse> ReportRootGetemailappusageUserdetailAsync(ReportRootGetemailappusageUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetemailappusageUserdetailParameter, ReportRootGetemailappusageUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageUserdetailResponse> ReportRootGetemailappusageUserdetailAsync(ReportRootGetemailappusageUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetemailappusageUserdetailParameter, ReportRootGetemailappusageUserdetailResponse>(parameter, cancellationToken);
        }
    }
}
