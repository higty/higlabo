using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetoffice365activeuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365ActiveUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOffice365ActiveUserDetail: return $"/reports/getOffice365ActiveUserDetail";
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
    public partial class ReportrootGetoffice365activeuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activeuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activeuserdetailResponse> ReportrootGetoffice365activeuserdetailAsync()
        {
            var p = new ReportrootGetoffice365activeuserdetailParameter();
            return await this.SendAsync<ReportrootGetoffice365activeuserdetailParameter, ReportrootGetoffice365activeuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activeuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activeuserdetailResponse> ReportrootGetoffice365activeuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetoffice365activeuserdetailParameter();
            return await this.SendAsync<ReportrootGetoffice365activeuserdetailParameter, ReportrootGetoffice365activeuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activeuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activeuserdetailResponse> ReportrootGetoffice365activeuserdetailAsync(ReportrootGetoffice365activeuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetoffice365activeuserdetailParameter, ReportrootGetoffice365activeuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activeuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activeuserdetailResponse> ReportrootGetoffice365activeuserdetailAsync(ReportrootGetoffice365activeuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetoffice365activeuserdetailParameter, ReportrootGetoffice365activeuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
