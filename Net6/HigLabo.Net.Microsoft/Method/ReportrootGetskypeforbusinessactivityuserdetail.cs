using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessactivityuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessActivityUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessActivityUserDetail: return $"/reports/getSkypeForBusinessActivityUserDetail";
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
    public partial class ReportrootGetskypeforbusinessactivityuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivityuserdetailResponse> ReportrootGetskypeforbusinessactivityuserdetailAsync()
        {
            var p = new ReportrootGetskypeforbusinessactivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessactivityuserdetailParameter, ReportrootGetskypeforbusinessactivityuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivityuserdetailResponse> ReportrootGetskypeforbusinessactivityuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessactivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessactivityuserdetailParameter, ReportrootGetskypeforbusinessactivityuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivityuserdetailResponse> ReportrootGetskypeforbusinessactivityuserdetailAsync(ReportrootGetskypeforbusinessactivityuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessactivityuserdetailParameter, ReportrootGetskypeforbusinessactivityuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivityuserdetailResponse> ReportrootGetskypeforbusinessactivityuserdetailAsync(ReportrootGetskypeforbusinessactivityuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessactivityuserdetailParameter, ReportrootGetskypeforbusinessactivityuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
