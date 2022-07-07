using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetteamsdeviceusageuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsDeviceUsageUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetTeamsDeviceUsageUserDetail: return $"/reports/getTeamsDeviceUsageUserDetail";
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
    public partial class ReportrootGetteamsdeviceusageuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusageuserdetailResponse> ReportrootGetteamsdeviceusageuserdetailAsync()
        {
            var p = new ReportrootGetteamsdeviceusageuserdetailParameter();
            return await this.SendAsync<ReportrootGetteamsdeviceusageuserdetailParameter, ReportrootGetteamsdeviceusageuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusageuserdetailResponse> ReportrootGetteamsdeviceusageuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetteamsdeviceusageuserdetailParameter();
            return await this.SendAsync<ReportrootGetteamsdeviceusageuserdetailParameter, ReportrootGetteamsdeviceusageuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusageuserdetailResponse> ReportrootGetteamsdeviceusageuserdetailAsync(ReportrootGetteamsdeviceusageuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetteamsdeviceusageuserdetailParameter, ReportrootGetteamsdeviceusageuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsdeviceusageuserdetailResponse> ReportrootGetteamsdeviceusageuserdetailAsync(ReportrootGetteamsdeviceusageuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetteamsdeviceusageuserdetailParameter, ReportrootGetteamsdeviceusageuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
