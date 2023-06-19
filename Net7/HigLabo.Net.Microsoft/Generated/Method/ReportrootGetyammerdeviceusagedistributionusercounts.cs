using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusagedistributionusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetyammerdeviceusagedistributionUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetYammerDeviceUsageDistributionUserCounts: return $"/reports/getYammerDeviceUsageDistributionUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerDeviceUsageDistributionUserCounts,
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
    public partial class ReportRootGetyammerdeviceusagedistributionUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusagedistributionusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusagedistributionUsercountsResponse> ReportRootGetyammerdeviceusagedistributionUsercountsAsync()
        {
            var p = new ReportRootGetyammerdeviceusagedistributionUsercountsParameter();
            return await this.SendAsync<ReportRootGetyammerdeviceusagedistributionUsercountsParameter, ReportRootGetyammerdeviceusagedistributionUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusagedistributionUsercountsResponse> ReportRootGetyammerdeviceusagedistributionUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetyammerdeviceusagedistributionUsercountsParameter();
            return await this.SendAsync<ReportRootGetyammerdeviceusagedistributionUsercountsParameter, ReportRootGetyammerdeviceusagedistributionUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusagedistributionUsercountsResponse> ReportRootGetyammerdeviceusagedistributionUsercountsAsync(ReportRootGetyammerdeviceusagedistributionUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetyammerdeviceusagedistributionUsercountsParameter, ReportRootGetyammerdeviceusagedistributionUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerdeviceusagedistributionUsercountsResponse> ReportRootGetyammerdeviceusagedistributionUsercountsAsync(ReportRootGetyammerdeviceusagedistributionUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetyammerdeviceusagedistributionUsercountsParameter, ReportRootGetyammerdeviceusagedistributionUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
