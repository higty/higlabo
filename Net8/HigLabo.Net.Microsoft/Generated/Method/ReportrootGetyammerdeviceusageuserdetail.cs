using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetyammerdeviceusageUserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetYammerDeviceUsageUserDetail: return $"/reports/getYammerDeviceUsageUserDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerDeviceUsageUserDetail,
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
    public partial class ReportRootGetyammerdeviceusageUserdetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusageUserdetailResponse> ReportRootGetyammerdeviceusageUserdetailAsync()
        {
            var p = new ReportRootGetyammerdeviceusageUserdetailParameter();
            return await this.SendAsync<ReportRootGetyammerdeviceusageUserdetailParameter, ReportRootGetyammerdeviceusageUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusageUserdetailResponse> ReportRootGetyammerdeviceusageUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetyammerdeviceusageUserdetailParameter();
            return await this.SendAsync<ReportRootGetyammerdeviceusageUserdetailParameter, ReportRootGetyammerdeviceusageUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusageUserdetailResponse> ReportRootGetyammerdeviceusageUserdetailAsync(ReportRootGetyammerdeviceusageUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetyammerdeviceusageUserdetailParameter, ReportRootGetyammerdeviceusageUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusageUserdetailResponse> ReportRootGetyammerdeviceusageUserdetailAsync(ReportRootGetyammerdeviceusageUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetyammerdeviceusageUserdetailParameter, ReportRootGetyammerdeviceusageUserdetailResponse>(parameter, cancellationToken);
        }
    }
}
