using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetSkypeforBusinessdeviceusageUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessDeviceUsageUserCounts: return $"/reports/getSkypeForBusinessDeviceUsageUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessDeviceUsageUserCounts,
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
    public partial class ReportRootGetSkypeforBusinessdeviceusageUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessdeviceusageUsercountsResponse> ReportRootGetSkypeforBusinessdeviceusageUsercountsAsync()
        {
            var p = new ReportRootGetSkypeforBusinessdeviceusageUsercountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinessdeviceusageUsercountsParameter, ReportRootGetSkypeforBusinessdeviceusageUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessdeviceusageUsercountsResponse> ReportRootGetSkypeforBusinessdeviceusageUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetSkypeforBusinessdeviceusageUsercountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinessdeviceusageUsercountsParameter, ReportRootGetSkypeforBusinessdeviceusageUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessdeviceusageUsercountsResponse> ReportRootGetSkypeforBusinessdeviceusageUsercountsAsync(ReportRootGetSkypeforBusinessdeviceusageUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinessdeviceusageUsercountsParameter, ReportRootGetSkypeforBusinessdeviceusageUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessdeviceusageUsercountsResponse> ReportRootGetSkypeforBusinessdeviceusageUsercountsAsync(ReportRootGetSkypeforBusinessdeviceusageUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinessdeviceusageUsercountsParameter, ReportRootGetSkypeforBusinessdeviceusageUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
