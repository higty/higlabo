using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetOneDriveActivityfilecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOneDriveActivityFileCounts: return $"/reports/getOneDriveActivityFileCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveActivityFileCounts,
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
    public partial class ReportRootGetOneDriveActivityfilecountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveActivityfilecountsResponse> ReportRootGetOneDriveActivityfilecountsAsync()
        {
            var p = new ReportRootGetOneDriveActivityfilecountsParameter();
            return await this.SendAsync<ReportRootGetOneDriveActivityfilecountsParameter, ReportRootGetOneDriveActivityfilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveActivityfilecountsResponse> ReportRootGetOneDriveActivityfilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetOneDriveActivityfilecountsParameter();
            return await this.SendAsync<ReportRootGetOneDriveActivityfilecountsParameter, ReportRootGetOneDriveActivityfilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveActivityfilecountsResponse> ReportRootGetOneDriveActivityfilecountsAsync(ReportRootGetOneDriveActivityfilecountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetOneDriveActivityfilecountsParameter, ReportRootGetOneDriveActivityfilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveActivityfilecountsResponse> ReportRootGetOneDriveActivityfilecountsAsync(ReportRootGetOneDriveActivityfilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetOneDriveActivityfilecountsParameter, ReportRootGetOneDriveActivityfilecountsResponse>(parameter, cancellationToken);
        }
    }
}
