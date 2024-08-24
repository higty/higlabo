using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagefilecounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetOneDriveusagefilecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOneDriveUsageFileCounts: return $"/reports/getOneDriveUsageFileCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveUsageFileCounts,
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
    public partial class ReportRootGetOneDriveusagefilecountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagefilecounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusagefilecountsResponse> ReportRootGetOneDriveusagefilecountsAsync()
        {
            var p = new ReportRootGetOneDriveusagefilecountsParameter();
            return await this.SendAsync<ReportRootGetOneDriveusagefilecountsParameter, ReportRootGetOneDriveusagefilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusagefilecountsResponse> ReportRootGetOneDriveusagefilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetOneDriveusagefilecountsParameter();
            return await this.SendAsync<ReportRootGetOneDriveusagefilecountsParameter, ReportRootGetOneDriveusagefilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusagefilecountsResponse> ReportRootGetOneDriveusagefilecountsAsync(ReportRootGetOneDriveusagefilecountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetOneDriveusagefilecountsParameter, ReportRootGetOneDriveusagefilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusagefilecountsResponse> ReportRootGetOneDriveusagefilecountsAsync(ReportRootGetOneDriveusagefilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetOneDriveusagefilecountsParameter, ReportRootGetOneDriveusagefilecountsResponse>(parameter, cancellationToken);
        }
    }
}
