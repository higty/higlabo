using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetmailboxusagedetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetMailboxUsageDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetMailboxUsageDetail: return $"/reports/getMailboxUsageDetail";
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
    public partial class ReportrootGetmailboxusagedetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagedetailResponse> ReportrootGetmailboxusagedetailAsync()
        {
            var p = new ReportrootGetmailboxusagedetailParameter();
            return await this.SendAsync<ReportrootGetmailboxusagedetailParameter, ReportrootGetmailboxusagedetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagedetailResponse> ReportrootGetmailboxusagedetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetmailboxusagedetailParameter();
            return await this.SendAsync<ReportrootGetmailboxusagedetailParameter, ReportrootGetmailboxusagedetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagedetailResponse> ReportrootGetmailboxusagedetailAsync(ReportrootGetmailboxusagedetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetmailboxusagedetailParameter, ReportrootGetmailboxusagedetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagedetailResponse> ReportrootGetmailboxusagedetailAsync(ReportrootGetmailboxusagedetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetmailboxusagedetailParameter, ReportrootGetmailboxusagedetailResponse>(parameter, cancellationToken);
        }
    }
}
