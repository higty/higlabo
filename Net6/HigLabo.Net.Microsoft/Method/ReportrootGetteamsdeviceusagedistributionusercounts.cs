using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetteamsdeviceusagedistributionusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsDeviceUsageDistributionUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetTeamsDeviceUsageDistributionUserCounts: return $"/reports/getTeamsDeviceUsageDistributionUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class ReportrootGetteamsdeviceusagedistributionusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusagedistributionusercountsResponse> ReportrootGetteamsdeviceusagedistributionusercountsAsync()
        {
            var p = new ReportrootGetteamsdeviceusagedistributionusercountsParameter();
            return await this.SendAsync<ReportrootGetteamsdeviceusagedistributionusercountsParameter, ReportrootGetteamsdeviceusagedistributionusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusagedistributionusercountsResponse> ReportrootGetteamsdeviceusagedistributionusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetteamsdeviceusagedistributionusercountsParameter();
            return await this.SendAsync<ReportrootGetteamsdeviceusagedistributionusercountsParameter, ReportrootGetteamsdeviceusagedistributionusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusagedistributionusercountsResponse> ReportrootGetteamsdeviceusagedistributionusercountsAsync(ReportrootGetteamsdeviceusagedistributionusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetteamsdeviceusagedistributionusercountsParameter, ReportrootGetteamsdeviceusagedistributionusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusagedistributionusercountsResponse> ReportrootGetteamsdeviceusagedistributionusercountsAsync(ReportrootGetteamsdeviceusagedistributionusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetteamsdeviceusagedistributionusercountsParameter, ReportrootGetteamsdeviceusagedistributionusercountsResponse>(parameter, cancellationToken);
        }
    }
}
