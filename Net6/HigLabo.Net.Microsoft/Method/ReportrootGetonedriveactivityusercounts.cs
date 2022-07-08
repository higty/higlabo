using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetonedriveactivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetonedriveactivityUsercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveactivityUsercountsResponse> ReportRootGetonedriveactivityUsercountsAsync()
        {
            var p = new ReportRootGetonedriveactivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetonedriveactivityUsercountsParameter, ReportRootGetonedriveactivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveactivityUsercountsResponse> ReportRootGetonedriveactivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetonedriveactivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetonedriveactivityUsercountsParameter, ReportRootGetonedriveactivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveactivityUsercountsResponse> ReportRootGetonedriveactivityUsercountsAsync(ReportRootGetonedriveactivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetonedriveactivityUsercountsParameter, ReportRootGetonedriveactivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveactivityUsercountsResponse> ReportRootGetonedriveactivityUsercountsAsync(ReportRootGetonedriveactivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetonedriveactivityUsercountsParameter, ReportRootGetonedriveactivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
