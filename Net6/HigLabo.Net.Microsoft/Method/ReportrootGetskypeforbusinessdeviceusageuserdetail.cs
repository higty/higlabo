using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessdeviceusageuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessDeviceUsageUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessDeviceUsageUserDetail: return $"/reports/getSkypeForBusinessDeviceUsageUserDetail";
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
    public partial class ReportrootGetskypeforbusinessdeviceusageuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusageuserdetailResponse> ReportrootGetskypeforbusinessdeviceusageuserdetailAsync()
        {
            var p = new ReportrootGetskypeforbusinessdeviceusageuserdetailParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusageuserdetailParameter, ReportrootGetskypeforbusinessdeviceusageuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusageuserdetailResponse> ReportrootGetskypeforbusinessdeviceusageuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessdeviceusageuserdetailParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusageuserdetailParameter, ReportrootGetskypeforbusinessdeviceusageuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusageuserdetailResponse> ReportrootGetskypeforbusinessdeviceusageuserdetailAsync(ReportrootGetskypeforbusinessdeviceusageuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusageuserdetailParameter, ReportrootGetskypeforbusinessdeviceusageuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessdeviceusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessdeviceusageuserdetailResponse> ReportrootGetskypeforbusinessdeviceusageuserdetailAsync(ReportrootGetskypeforbusinessdeviceusageuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessdeviceusageuserdetailParameter, ReportrootGetskypeforbusinessdeviceusageuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
