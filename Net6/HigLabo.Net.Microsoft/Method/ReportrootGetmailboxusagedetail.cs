using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetmailboxusagedetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetMailboxUsageDetail: return $"/reports/getMailboxUsageDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetMailboxUsageDetail,
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
    public partial class ReportRootGetmailboxusagedetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagedetailResponse> ReportRootGetmailboxusagedetailAsync()
        {
            var p = new ReportRootGetmailboxusagedetailParameter();
            return await this.SendAsync<ReportRootGetmailboxusagedetailParameter, ReportRootGetmailboxusagedetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagedetailResponse> ReportRootGetmailboxusagedetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetmailboxusagedetailParameter();
            return await this.SendAsync<ReportRootGetmailboxusagedetailParameter, ReportRootGetmailboxusagedetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagedetailResponse> ReportRootGetmailboxusagedetailAsync(ReportRootGetmailboxusagedetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetmailboxusagedetailParameter, ReportRootGetmailboxusagedetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getmailboxusagedetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetmailboxusagedetailResponse> ReportRootGetmailboxusagedetailAsync(ReportRootGetmailboxusagedetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetmailboxusagedetailParameter, ReportRootGetmailboxusagedetailResponse>(parameter, cancellationToken);
        }
    }
}
