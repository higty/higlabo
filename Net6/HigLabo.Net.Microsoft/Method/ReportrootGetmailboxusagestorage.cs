using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetmailboxusagestorageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetMailboxUsageStorage,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetMailboxUsageStorage: return $"/reports/getMailboxUsageStorage";
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
    public partial class ReportrootGetmailboxusagestorageResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagestorageResponse> ReportrootGetmailboxusagestorageAsync()
        {
            var p = new ReportrootGetmailboxusagestorageParameter();
            return await this.SendAsync<ReportrootGetmailboxusagestorageParameter, ReportrootGetmailboxusagestorageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagestorageResponse> ReportrootGetmailboxusagestorageAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetmailboxusagestorageParameter();
            return await this.SendAsync<ReportrootGetmailboxusagestorageParameter, ReportrootGetmailboxusagestorageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagestorageResponse> ReportrootGetmailboxusagestorageAsync(ReportrootGetmailboxusagestorageParameter parameter)
        {
            return await this.SendAsync<ReportrootGetmailboxusagestorageParameter, ReportrootGetmailboxusagestorageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagestorageResponse> ReportrootGetmailboxusagestorageAsync(ReportrootGetmailboxusagestorageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetmailboxusagestorageParameter, ReportrootGetmailboxusagestorageResponse>(parameter, cancellationToken);
        }
    }
}
