using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetyammerdeviceusagedistributionusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerDeviceUsageDistributionUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetYammerDeviceUsageDistributionUserCounts: return $"/reports/getYammerDeviceUsageDistributionUserCounts";
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
    public partial class ReportrootGetyammerdeviceusagedistributionusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusagedistributionusercountsResponse> ReportrootGetyammerdeviceusagedistributionusercountsAsync()
        {
            var p = new ReportrootGetyammerdeviceusagedistributionusercountsParameter();
            return await this.SendAsync<ReportrootGetyammerdeviceusagedistributionusercountsParameter, ReportrootGetyammerdeviceusagedistributionusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusagedistributionusercountsResponse> ReportrootGetyammerdeviceusagedistributionusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetyammerdeviceusagedistributionusercountsParameter();
            return await this.SendAsync<ReportrootGetyammerdeviceusagedistributionusercountsParameter, ReportrootGetyammerdeviceusagedistributionusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusagedistributionusercountsResponse> ReportrootGetyammerdeviceusagedistributionusercountsAsync(ReportrootGetyammerdeviceusagedistributionusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetyammerdeviceusagedistributionusercountsParameter, ReportrootGetyammerdeviceusagedistributionusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusagedistributionusercountsResponse> ReportrootGetyammerdeviceusagedistributionusercountsAsync(ReportrootGetyammerdeviceusagedistributionusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetyammerdeviceusagedistributionusercountsParameter, ReportrootGetyammerdeviceusagedistributionusercountsResponse>(parameter, cancellationToken);
        }
    }
}
