using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetonedriveactivityfilecountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetonedriveactivityfilecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveactivityfilecountsResponse> ReportRootGetonedriveactivityfilecountsAsync()
        {
            var p = new ReportRootGetonedriveactivityfilecountsParameter();
            return await this.SendAsync<ReportRootGetonedriveactivityfilecountsParameter, ReportRootGetonedriveactivityfilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveactivityfilecountsResponse> ReportRootGetonedriveactivityfilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetonedriveactivityfilecountsParameter();
            return await this.SendAsync<ReportRootGetonedriveactivityfilecountsParameter, ReportRootGetonedriveactivityfilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveactivityfilecountsResponse> ReportRootGetonedriveactivityfilecountsAsync(ReportRootGetonedriveactivityfilecountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetonedriveactivityfilecountsParameter, ReportRootGetonedriveactivityfilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveactivityfilecountsResponse> ReportRootGetonedriveactivityfilecountsAsync(ReportRootGetonedriveactivityfilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetonedriveactivityfilecountsParameter, ReportRootGetonedriveactivityfilecountsResponse>(parameter, cancellationToken);
        }
    }
}
