using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountcounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetOneDriveusageAccountcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOneDriveUsageAccountCounts: return $"/reports/getOneDriveUsageAccountCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveUsageAccountCounts,
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
    public partial class ReportRootGetOneDriveusageAccountcountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountcounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusageAccountcountsResponse> ReportRootGetOneDriveusageAccountcountsAsync()
        {
            var p = new ReportRootGetOneDriveusageAccountcountsParameter();
            return await this.SendAsync<ReportRootGetOneDriveusageAccountcountsParameter, ReportRootGetOneDriveusageAccountcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusageAccountcountsResponse> ReportRootGetOneDriveusageAccountcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetOneDriveusageAccountcountsParameter();
            return await this.SendAsync<ReportRootGetOneDriveusageAccountcountsParameter, ReportRootGetOneDriveusageAccountcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusageAccountcountsResponse> ReportRootGetOneDriveusageAccountcountsAsync(ReportRootGetOneDriveusageAccountcountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetOneDriveusageAccountcountsParameter, ReportRootGetOneDriveusageAccountcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusageAccountcountsResponse> ReportRootGetOneDriveusageAccountcountsAsync(ReportRootGetOneDriveusageAccountcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetOneDriveusageAccountcountsParameter, ReportRootGetOneDriveusageAccountcountsResponse>(parameter, cancellationToken);
        }
    }
}
