using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetTeamsdeviceusageUsercountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetTeamsdeviceusageUsercountsResponse : RestApiResponse
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
        public async ValueTask<ReportRootGetTeamsdeviceusageUsercountsResponse> ReportRootGetTeamsdeviceusageUsercountsAsync()
        {
            var p = new ReportRootGetTeamsdeviceusageUsercountsParameter();
            return await this.SendAsync<ReportRootGetTeamsdeviceusageUsercountsParameter, ReportRootGetTeamsdeviceusageUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsdeviceusageUsercountsResponse> ReportRootGetTeamsdeviceusageUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetTeamsdeviceusageUsercountsParameter();
            return await this.SendAsync<ReportRootGetTeamsdeviceusageUsercountsParameter, ReportRootGetTeamsdeviceusageUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsdeviceusageUsercountsResponse> ReportRootGetTeamsdeviceusageUsercountsAsync(ReportRootGetTeamsdeviceusageUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetTeamsdeviceusageUsercountsParameter, ReportRootGetTeamsdeviceusageUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsdeviceusageUsercountsResponse> ReportRootGetTeamsdeviceusageUsercountsAsync(ReportRootGetTeamsdeviceusageUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetTeamsdeviceusageUsercountsParameter, ReportRootGetTeamsdeviceusageUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
