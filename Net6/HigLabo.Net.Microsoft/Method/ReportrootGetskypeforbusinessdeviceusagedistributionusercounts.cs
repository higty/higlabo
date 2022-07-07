using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessdeviceusagedistributionusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessDeviceUsageDistributionUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessDeviceUsageDistributionUserCounts: return $"/reports/getSkypeForBusinessDeviceUsageDistributionUserCounts";
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
    public partial class ReportrootGetskypeforbusinessdeviceusagedistributionusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusagedistributionusercountsResponse> ReportrootGetskypeforbusinessdeviceusagedistributionusercountsAsync()
        {
            var p = new ReportrootGetskypeforbusinessdeviceusagedistributionusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusagedistributionusercountsParameter, ReportrootGetskypeforbusinessdeviceusagedistributionusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusagedistributionusercountsResponse> ReportrootGetskypeforbusinessdeviceusagedistributionusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessdeviceusagedistributionusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusagedistributionusercountsParameter, ReportrootGetskypeforbusinessdeviceusagedistributionusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusagedistributionusercountsResponse> ReportrootGetskypeforbusinessdeviceusagedistributionusercountsAsync(ReportrootGetskypeforbusinessdeviceusagedistributionusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusagedistributionusercountsParameter, ReportrootGetskypeforbusinessdeviceusagedistributionusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusagedistributionusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusagedistributionusercountsResponse> ReportrootGetskypeforbusinessdeviceusagedistributionusercountsAsync(ReportrootGetskypeforbusinessdeviceusagedistributionusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusagedistributionusercountsParameter, ReportrootGetskypeforbusinessdeviceusagedistributionusercountsResponse>(parameter, cancellationToken);
        }
    }
}
