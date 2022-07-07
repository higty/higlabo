using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetmailboxusagemailboxcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetMailboxUsageMailboxCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetMailboxUsageMailboxCounts: return $"/reports/getMailboxUsageMailboxCounts";
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
    public partial class ReportrootGetmailboxusagemailboxcountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagemailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagemailboxcountsResponse> ReportrootGetmailboxusagemailboxcountsAsync()
        {
            var p = new ReportrootGetmailboxusagemailboxcountsParameter();
            return await this.SendAsync<ReportrootGetmailboxusagemailboxcountsParameter, ReportrootGetmailboxusagemailboxcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagemailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagemailboxcountsResponse> ReportrootGetmailboxusagemailboxcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetmailboxusagemailboxcountsParameter();
            return await this.SendAsync<ReportrootGetmailboxusagemailboxcountsParameter, ReportrootGetmailboxusagemailboxcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagemailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagemailboxcountsResponse> ReportrootGetmailboxusagemailboxcountsAsync(ReportrootGetmailboxusagemailboxcountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetmailboxusagemailboxcountsParameter, ReportrootGetmailboxusagemailboxcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagemailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagemailboxcountsResponse> ReportrootGetmailboxusagemailboxcountsAsync(ReportrootGetmailboxusagemailboxcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetmailboxusagemailboxcountsParameter, ReportrootGetmailboxusagemailboxcountsResponse>(parameter, cancellationToken);
        }
    }
}
