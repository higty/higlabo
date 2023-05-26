using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusagedistributionusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetteamsdeviceusagedistributionUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetTeamsDeviceUsageDistributionUserCounts: return $"/reports/getTeamsDeviceUsageDistributionUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsDeviceUsageDistributionUserCounts,
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
    public partial class ReportRootGetteamsdeviceusagedistributionUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusagedistributionusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsdeviceusagedistributionUsercountsResponse> ReportRootGetteamsdeviceusagedistributionUsercountsAsync()
        {
            var p = new ReportRootGetteamsdeviceusagedistributionUsercountsParameter();
            return await this.SendAsync<ReportRootGetteamsdeviceusagedistributionUsercountsParameter, ReportRootGetteamsdeviceusagedistributionUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsdeviceusagedistributionUsercountsResponse> ReportRootGetteamsdeviceusagedistributionUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetteamsdeviceusagedistributionUsercountsParameter();
            return await this.SendAsync<ReportRootGetteamsdeviceusagedistributionUsercountsParameter, ReportRootGetteamsdeviceusagedistributionUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsdeviceusagedistributionUsercountsResponse> ReportRootGetteamsdeviceusagedistributionUsercountsAsync(ReportRootGetteamsdeviceusagedistributionUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetteamsdeviceusagedistributionUsercountsParameter, ReportRootGetteamsdeviceusagedistributionUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsdeviceusagedistributionUsercountsResponse> ReportRootGetteamsdeviceusagedistributionUsercountsAsync(ReportRootGetteamsdeviceusagedistributionUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetteamsdeviceusagedistributionUsercountsParameter, ReportRootGetteamsdeviceusagedistributionUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
