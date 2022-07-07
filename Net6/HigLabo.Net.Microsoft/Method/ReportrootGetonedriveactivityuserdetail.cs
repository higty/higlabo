using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetonedriveactivityuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveActivityUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOneDriveActivityUserDetail: return $"/reports/getOneDriveActivityUserDetail";
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
    public partial class ReportrootGetonedriveactivityuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityuserdetailResponse> ReportrootGetonedriveactivityuserdetailAsync()
        {
            var p = new ReportrootGetonedriveactivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetonedriveactivityuserdetailParameter, ReportrootGetonedriveactivityuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityuserdetailResponse> ReportrootGetonedriveactivityuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetonedriveactivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetonedriveactivityuserdetailParameter, ReportrootGetonedriveactivityuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityuserdetailResponse> ReportrootGetonedriveactivityuserdetailAsync(ReportrootGetonedriveactivityuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetonedriveactivityuserdetailParameter, ReportrootGetonedriveactivityuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityuserdetailResponse> ReportrootGetonedriveactivityuserdetailAsync(ReportrootGetonedriveactivityuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetonedriveactivityuserdetailParameter, ReportrootGetonedriveactivityuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
