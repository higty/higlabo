using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetOneDriveActivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOneDriveActivityUserCounts: return $"/reports/getOneDriveActivityUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveActivityUserCounts,
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
    public partial class ReportRootGetOneDriveActivityUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveActivityUsercountsResponse> ReportRootGetOneDriveActivityUsercountsAsync()
        {
            var p = new ReportRootGetOneDriveActivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetOneDriveActivityUsercountsParameter, ReportRootGetOneDriveActivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveActivityUsercountsResponse> ReportRootGetOneDriveActivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetOneDriveActivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetOneDriveActivityUsercountsParameter, ReportRootGetOneDriveActivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveActivityUsercountsResponse> ReportRootGetOneDriveActivityUsercountsAsync(ReportRootGetOneDriveActivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetOneDriveActivityUsercountsParameter, ReportRootGetOneDriveActivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveActivityUsercountsResponse> ReportRootGetOneDriveActivityUsercountsAsync(ReportRootGetOneDriveActivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetOneDriveActivityUsercountsParameter, ReportRootGetOneDriveActivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
