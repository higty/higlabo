using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetskypeforbusinessdeviceusageUserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessDeviceUsageUserDetail: return $"/reports/getSkypeForBusinessDeviceUsageUserDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessDeviceUsageUserDetail,
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
    public partial class ReportRootGetskypeforbusinessdeviceusageUserdetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessdeviceusageUserdetailResponse> ReportRootGetskypeforbusinessdeviceusageUserdetailAsync()
        {
            var p = new ReportRootGetskypeforbusinessdeviceusageUserdetailParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusageUserdetailParameter, ReportRootGetskypeforbusinessdeviceusageUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessdeviceusageUserdetailResponse> ReportRootGetskypeforbusinessdeviceusageUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinessdeviceusageUserdetailParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusageUserdetailParameter, ReportRootGetskypeforbusinessdeviceusageUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessdeviceusageUserdetailResponse> ReportRootGetskypeforbusinessdeviceusageUserdetailAsync(ReportRootGetskypeforbusinessdeviceusageUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusageUserdetailParameter, ReportRootGetskypeforbusinessdeviceusageUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessdeviceusageUserdetailResponse> ReportRootGetskypeforbusinessdeviceusageUserdetailAsync(ReportRootGetskypeforbusinessdeviceusageUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusageUserdetailParameter, ReportRootGetskypeforbusinessdeviceusageUserdetailResponse>(parameter, cancellationToken);
        }
    }
}
