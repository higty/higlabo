using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusagedistributionusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessDeviceUsageDistributionUserCounts: return $"/reports/getSkypeForBusinessDeviceUsageDistributionUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessDeviceUsageDistributionUserCounts,
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
    public partial class ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusagedistributionusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsResponse> ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsAsync()
        {
            var p = new ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsParameter, ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsResponse> ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsParameter, ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsResponse> ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsAsync(ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsParameter, ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsResponse> ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsAsync(ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsParameter, ReportRootGetskypeforbusinessdeviceusagedistributionUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
