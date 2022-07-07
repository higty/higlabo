using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessdeviceusageusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessDeviceUsageUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessDeviceUsageUserCounts: return $"/reports/getSkypeForBusinessDeviceUsageUserCounts";
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
    public partial class ReportrootGetskypeforbusinessdeviceusageusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusageusercountsResponse> ReportrootGetskypeforbusinessdeviceusageusercountsAsync()
        {
            var p = new ReportrootGetskypeforbusinessdeviceusageusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusageusercountsParameter, ReportrootGetskypeforbusinessdeviceusageusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusageusercountsResponse> ReportrootGetskypeforbusinessdeviceusageusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessdeviceusageusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusageusercountsParameter, ReportrootGetskypeforbusinessdeviceusageusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusageusercountsResponse> ReportrootGetskypeforbusinessdeviceusageusercountsAsync(ReportrootGetskypeforbusinessdeviceusageusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusageusercountsParameter, ReportrootGetskypeforbusinessdeviceusageusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusageusercountsResponse> ReportrootGetskypeforbusinessdeviceusageusercountsAsync(ReportrootGetskypeforbusinessdeviceusageusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusageusercountsParameter, ReportrootGetskypeforbusinessdeviceusageusercountsResponse>(parameter, cancellationToken);
        }
    }
}
