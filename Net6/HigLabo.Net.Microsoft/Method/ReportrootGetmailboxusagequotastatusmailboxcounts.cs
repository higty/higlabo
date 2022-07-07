using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetmailboxusagequotastatusmailboxcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetMailboxUsageQuotaStatusMailboxCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetMailboxUsageQuotaStatusMailboxCounts: return $"/reports/getMailboxUsageQuotaStatusMailboxCounts";
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
    public partial class ReportrootGetmailboxusagequotastatusmailboxcountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagequotastatusmailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagequotastatusmailboxcountsResponse> ReportrootGetmailboxusagequotastatusmailboxcountsAsync()
        {
            var p = new ReportrootGetmailboxusagequotastatusmailboxcountsParameter();
            return await this.SendAsync<ReportrootGetmailboxusagequotastatusmailboxcountsParameter, ReportrootGetmailboxusagequotastatusmailboxcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagequotastatusmailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagequotastatusmailboxcountsResponse> ReportrootGetmailboxusagequotastatusmailboxcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetmailboxusagequotastatusmailboxcountsParameter();
            return await this.SendAsync<ReportrootGetmailboxusagequotastatusmailboxcountsParameter, ReportrootGetmailboxusagequotastatusmailboxcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagequotastatusmailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagequotastatusmailboxcountsResponse> ReportrootGetmailboxusagequotastatusmailboxcountsAsync(ReportrootGetmailboxusagequotastatusmailboxcountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetmailboxusagequotastatusmailboxcountsParameter, ReportrootGetmailboxusagequotastatusmailboxcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagequotastatusmailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetmailboxusagequotastatusmailboxcountsResponse> ReportrootGetmailboxusagequotastatusmailboxcountsAsync(ReportrootGetmailboxusagequotastatusmailboxcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetmailboxusagequotastatusmailboxcountsParameter, ReportrootGetmailboxusagequotastatusmailboxcountsResponse>(parameter, cancellationToken);
        }
    }
}
