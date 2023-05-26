using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetskypeforbusinessdeviceusageUsercountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetskypeforbusinessdeviceusageUsercountsResponse : RestApiResponse
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
        public async Task<ReportRootGetskypeforbusinessdeviceusageUsercountsResponse> ReportRootGetskypeforbusinessdeviceusageUsercountsAsync()
        {
            var p = new ReportRootGetskypeforbusinessdeviceusageUsercountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusageUsercountsParameter, ReportRootGetskypeforbusinessdeviceusageUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessdeviceusageUsercountsResponse> ReportRootGetskypeforbusinessdeviceusageUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinessdeviceusageUsercountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusageUsercountsParameter, ReportRootGetskypeforbusinessdeviceusageUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessdeviceusageUsercountsResponse> ReportRootGetskypeforbusinessdeviceusageUsercountsAsync(ReportRootGetskypeforbusinessdeviceusageUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusageUsercountsParameter, ReportRootGetskypeforbusinessdeviceusageUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessdeviceusageUsercountsResponse> ReportRootGetskypeforbusinessdeviceusageUsercountsAsync(ReportRootGetskypeforbusinessdeviceusageUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusageUsercountsParameter, ReportRootGetskypeforbusinessdeviceusageUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
