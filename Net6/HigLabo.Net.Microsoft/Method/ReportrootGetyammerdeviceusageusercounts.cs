using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetyammerdeviceusageusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerDeviceUsageUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetYammerDeviceUsageUserCounts: return $"/reports/getYammerDeviceUsageUserCounts";
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
    public partial class ReportrootGetyammerdeviceusageusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusageusercountsResponse> ReportrootGetyammerdeviceusageusercountsAsync()
        {
            var p = new ReportrootGetyammerdeviceusageusercountsParameter();
            return await this.SendAsync<ReportrootGetyammerdeviceusageusercountsParameter, ReportrootGetyammerdeviceusageusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusageusercountsResponse> ReportrootGetyammerdeviceusageusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetyammerdeviceusageusercountsParameter();
            return await this.SendAsync<ReportrootGetyammerdeviceusageusercountsParameter, ReportrootGetyammerdeviceusageusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusageusercountsResponse> ReportrootGetyammerdeviceusageusercountsAsync(ReportrootGetyammerdeviceusageusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetyammerdeviceusageusercountsParameter, ReportrootGetyammerdeviceusageusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusageusercountsResponse> ReportrootGetyammerdeviceusageusercountsAsync(ReportrootGetyammerdeviceusageusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetyammerdeviceusageusercountsParameter, ReportrootGetyammerdeviceusageusercountsResponse>(parameter, cancellationToken);
        }
    }
}
