using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagemailboxcounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetmailboxusagemailboxcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetMailboxUsageMailboxCounts: return $"/reports/getMailboxUsageMailboxCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetMailboxUsageMailboxCounts,
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
    public partial class ReportRootGetmailboxusagemailboxcountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagemailboxcounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagemailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetmailboxusagemailboxcountsResponse> ReportRootGetmailboxusagemailboxcountsAsync()
        {
            var p = new ReportRootGetmailboxusagemailboxcountsParameter();
            return await this.SendAsync<ReportRootGetmailboxusagemailboxcountsParameter, ReportRootGetmailboxusagemailboxcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagemailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetmailboxusagemailboxcountsResponse> ReportRootGetmailboxusagemailboxcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetmailboxusagemailboxcountsParameter();
            return await this.SendAsync<ReportRootGetmailboxusagemailboxcountsParameter, ReportRootGetmailboxusagemailboxcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagemailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetmailboxusagemailboxcountsResponse> ReportRootGetmailboxusagemailboxcountsAsync(ReportRootGetmailboxusagemailboxcountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetmailboxusagemailboxcountsParameter, ReportRootGetmailboxusagemailboxcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagemailboxcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetmailboxusagemailboxcountsResponse> ReportRootGetmailboxusagemailboxcountsAsync(ReportRootGetmailboxusagemailboxcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetmailboxusagemailboxcountsParameter, ReportRootGetmailboxusagemailboxcountsResponse>(parameter, cancellationToken);
        }
    }
}
