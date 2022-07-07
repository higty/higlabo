using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetonedriveusageaccountdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveUsageAccountDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOneDriveUsageAccountDetail: return $"/reports/getOneDriveUsageAccountDetail";
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
    public partial class ReportrootGetonedriveusageaccountdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusageaccountdetailResponse> ReportrootGetonedriveusageaccountdetailAsync()
        {
            var p = new ReportrootGetonedriveusageaccountdetailParameter();
            return await this.SendAsync<ReportrootGetonedriveusageaccountdetailParameter, ReportrootGetonedriveusageaccountdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusageaccountdetailResponse> ReportrootGetonedriveusageaccountdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetonedriveusageaccountdetailParameter();
            return await this.SendAsync<ReportrootGetonedriveusageaccountdetailParameter, ReportrootGetonedriveusageaccountdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusageaccountdetailResponse> ReportrootGetonedriveusageaccountdetailAsync(ReportrootGetonedriveusageaccountdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetonedriveusageaccountdetailParameter, ReportrootGetonedriveusageaccountdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusageaccountdetailResponse> ReportrootGetonedriveusageaccountdetailAsync(ReportrootGetonedriveusageaccountdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetonedriveusageaccountdetailParameter, ReportrootGetonedriveusageaccountdetailResponse>(parameter, cancellationToken);
        }
    }
}
