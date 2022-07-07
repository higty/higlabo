using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetteamsdeviceusageusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsDeviceUsageUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetTeamsDeviceUsageUserCounts: return $"/reports/getTeamsDeviceUsageUserCounts";
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
    public partial class ReportrootGetteamsdeviceusageusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusageusercountsResponse> ReportrootGetteamsdeviceusageusercountsAsync()
        {
            var p = new ReportrootGetteamsdeviceusageusercountsParameter();
            return await this.SendAsync<ReportrootGetteamsdeviceusageusercountsParameter, ReportrootGetteamsdeviceusageusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusageusercountsResponse> ReportrootGetteamsdeviceusageusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetteamsdeviceusageusercountsParameter();
            return await this.SendAsync<ReportrootGetteamsdeviceusageusercountsParameter, ReportrootGetteamsdeviceusageusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusageusercountsResponse> ReportrootGetteamsdeviceusageusercountsAsync(ReportrootGetteamsdeviceusageusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetteamsdeviceusageusercountsParameter, ReportrootGetteamsdeviceusageusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusageusercountsResponse> ReportrootGetteamsdeviceusageusercountsAsync(ReportrootGetteamsdeviceusageusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetteamsdeviceusageusercountsParameter, ReportrootGetteamsdeviceusageusercountsResponse>(parameter, cancellationToken);
        }
    }
}
