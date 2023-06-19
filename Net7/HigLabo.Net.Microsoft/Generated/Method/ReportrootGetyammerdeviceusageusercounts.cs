using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetyammerdeviceusageUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetYammerDeviceUsageUserCounts: return $"/reports/getYammerDeviceUsageUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerDeviceUsageUserCounts,
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
    public partial class ReportRootGetyammerdeviceusageUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusageUsercountsResponse> ReportRootGetyammerdeviceusageUsercountsAsync()
        {
            var p = new ReportRootGetyammerdeviceusageUsercountsParameter();
            return await this.SendAsync<ReportRootGetyammerdeviceusageUsercountsParameter, ReportRootGetyammerdeviceusageUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusageUsercountsResponse> ReportRootGetyammerdeviceusageUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetyammerdeviceusageUsercountsParameter();
            return await this.SendAsync<ReportRootGetyammerdeviceusageUsercountsParameter, ReportRootGetyammerdeviceusageUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusageUsercountsResponse> ReportRootGetyammerdeviceusageUsercountsAsync(ReportRootGetyammerdeviceusageUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetyammerdeviceusageUsercountsParameter, ReportRootGetyammerdeviceusageUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusageUsercountsResponse> ReportRootGetyammerdeviceusageUsercountsAsync(ReportRootGetyammerdeviceusageUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetyammerdeviceusageUsercountsParameter, ReportRootGetyammerdeviceusageUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
