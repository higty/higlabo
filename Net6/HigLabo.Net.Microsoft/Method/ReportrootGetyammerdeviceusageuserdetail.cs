using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetyammerdeviceusageuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerDeviceUsageUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetYammerDeviceUsageUserDetail: return $"/reports/getYammerDeviceUsageUserDetail";
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
    public partial class ReportrootGetyammerdeviceusageuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusageuserdetailResponse> ReportrootGetyammerdeviceusageuserdetailAsync()
        {
            var p = new ReportrootGetyammerdeviceusageuserdetailParameter();
            return await this.SendAsync<ReportrootGetyammerdeviceusageuserdetailParameter, ReportrootGetyammerdeviceusageuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusageuserdetailResponse> ReportrootGetyammerdeviceusageuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetyammerdeviceusageuserdetailParameter();
            return await this.SendAsync<ReportrootGetyammerdeviceusageuserdetailParameter, ReportrootGetyammerdeviceusageuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusageuserdetailResponse> ReportrootGetyammerdeviceusageuserdetailAsync(ReportrootGetyammerdeviceusageuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetyammerdeviceusageuserdetailParameter, ReportrootGetyammerdeviceusageuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammerdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammerdeviceusageuserdetailResponse> ReportrootGetyammerdeviceusageuserdetailAsync(ReportrootGetyammerdeviceusageuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetyammerdeviceusageuserdetailParameter, ReportrootGetyammerdeviceusageuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
