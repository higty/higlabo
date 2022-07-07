using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetteamsuseractivityuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsUserActivityUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetTeamsUserActivityUserDetail: return $"/reports/getTeamsUserActivityUserDetail";
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
    public partial class ReportrootGetteamsuseractivityuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivityuserdetailResponse> ReportrootGetteamsuseractivityuserdetailAsync()
        {
            var p = new ReportrootGetteamsuseractivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetteamsuseractivityuserdetailParameter, ReportrootGetteamsuseractivityuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivityuserdetailResponse> ReportrootGetteamsuseractivityuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetteamsuseractivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetteamsuseractivityuserdetailParameter, ReportrootGetteamsuseractivityuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivityuserdetailResponse> ReportrootGetteamsuseractivityuserdetailAsync(ReportrootGetteamsuseractivityuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetteamsuseractivityuserdetailParameter, ReportrootGetteamsuseractivityuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivityuserdetailResponse> ReportrootGetteamsuseractivityuserdetailAsync(ReportrootGetteamsuseractivityuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetteamsuseractivityuserdetailParameter, ReportrootGetteamsuseractivityuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
