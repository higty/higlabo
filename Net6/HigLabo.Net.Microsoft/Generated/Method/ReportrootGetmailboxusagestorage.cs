using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagestorage?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetmailboxusagestorageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetMailboxUsageStorage: return $"/reports/getMailboxUsageStorage";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetMailboxUsageStorage,
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
    public partial class ReportRootGetmailboxusagestorageResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagestorage?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagestorageResponse> ReportRootGetmailboxusagestorageAsync()
        {
            var p = new ReportRootGetmailboxusagestorageParameter();
            return await this.SendAsync<ReportRootGetmailboxusagestorageParameter, ReportRootGetmailboxusagestorageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagestorageResponse> ReportRootGetmailboxusagestorageAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetmailboxusagestorageParameter();
            return await this.SendAsync<ReportRootGetmailboxusagestorageParameter, ReportRootGetmailboxusagestorageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagestorageResponse> ReportRootGetmailboxusagestorageAsync(ReportRootGetmailboxusagestorageParameter parameter)
        {
            return await this.SendAsync<ReportRootGetmailboxusagestorageParameter, ReportRootGetmailboxusagestorageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getmailboxusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagestorageResponse> ReportRootGetmailboxusagestorageAsync(ReportRootGetmailboxusagestorageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetmailboxusagestorageParameter, ReportRootGetmailboxusagestorageResponse>(parameter, cancellationToken);
        }
    }
}
