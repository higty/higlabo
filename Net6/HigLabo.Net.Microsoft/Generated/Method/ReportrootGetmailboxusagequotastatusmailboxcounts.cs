using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagequotastatusmailboxcounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetmailboxusagequotaStatusmailboxcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetMailboxUsageQuotaStatusMailboxCounts: return $"/reports/getMailboxUsageQuotaStatusMailboxCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetMailboxUsageQuotaStatusMailboxCounts,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class ReportRootGetmailboxusagequotaStatusmailboxcountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagequotastatusmailboxcounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagequotastatusmailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagequotaStatusmailboxcountsResponse> ReportRootGetmailboxusagequotaStatusmailboxcountsAsync()
        {
            var p = new ReportRootGetmailboxusagequotaStatusmailboxcountsParameter();
            return await this.SendAsync<ReportRootGetmailboxusagequotaStatusmailboxcountsParameter, ReportRootGetmailboxusagequotaStatusmailboxcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagequotastatusmailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagequotaStatusmailboxcountsResponse> ReportRootGetmailboxusagequotaStatusmailboxcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetmailboxusagequotaStatusmailboxcountsParameter();
            return await this.SendAsync<ReportRootGetmailboxusagequotaStatusmailboxcountsParameter, ReportRootGetmailboxusagequotaStatusmailboxcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagequotastatusmailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagequotaStatusmailboxcountsResponse> ReportRootGetmailboxusagequotaStatusmailboxcountsAsync(ReportRootGetmailboxusagequotaStatusmailboxcountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetmailboxusagequotaStatusmailboxcountsParameter, ReportRootGetmailboxusagequotaStatusmailboxcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagequotastatusmailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagequotaStatusmailboxcountsResponse> ReportRootGetmailboxusagequotaStatusmailboxcountsAsync(ReportRootGetmailboxusagequotaStatusmailboxcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetmailboxusagequotaStatusmailboxcountsParameter, ReportRootGetmailboxusagequotaStatusmailboxcountsResponse>(parameter, cancellationToken);
        }
    }
}
