using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetteamsdeviceusageUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetTeamsDeviceUsageUserCounts: return $"/reports/getTeamsDeviceUsageUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsDeviceUsageUserCounts,
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
    public partial class ReportRootGetteamsdeviceusageUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsdeviceusageUsercountsResponse> ReportRootGetteamsdeviceusageUsercountsAsync()
        {
            var p = new ReportRootGetteamsdeviceusageUsercountsParameter();
            return await this.SendAsync<ReportRootGetteamsdeviceusageUsercountsParameter, ReportRootGetteamsdeviceusageUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsdeviceusageUsercountsResponse> ReportRootGetteamsdeviceusageUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetteamsdeviceusageUsercountsParameter();
            return await this.SendAsync<ReportRootGetteamsdeviceusageUsercountsParameter, ReportRootGetteamsdeviceusageUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsdeviceusageUsercountsResponse> ReportRootGetteamsdeviceusageUsercountsAsync(ReportRootGetteamsdeviceusageUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetteamsdeviceusageUsercountsParameter, ReportRootGetteamsdeviceusageUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsdeviceusageUsercountsResponse> ReportRootGetteamsdeviceusageUsercountsAsync(ReportRootGetteamsdeviceusageUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetteamsdeviceusageUsercountsParameter, ReportRootGetteamsdeviceusageUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
