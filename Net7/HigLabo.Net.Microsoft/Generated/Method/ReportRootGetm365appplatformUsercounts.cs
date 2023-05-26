using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appplatformusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetm365appplatformUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetM365AppPlatformUserCounts: return $"/reports/getM365AppPlatformUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetM365AppPlatformUserCounts,
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
    public partial class ReportRootGetm365appplatformUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appplatformusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appplatformusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetm365appplatformUsercountsResponse> ReportRootGetm365appplatformUsercountsAsync()
        {
            var p = new ReportRootGetm365appplatformUsercountsParameter();
            return await this.SendAsync<ReportRootGetm365appplatformUsercountsParameter, ReportRootGetm365appplatformUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appplatformusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetm365appplatformUsercountsResponse> ReportRootGetm365appplatformUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetm365appplatformUsercountsParameter();
            return await this.SendAsync<ReportRootGetm365appplatformUsercountsParameter, ReportRootGetm365appplatformUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appplatformusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetm365appplatformUsercountsResponse> ReportRootGetm365appplatformUsercountsAsync(ReportRootGetm365appplatformUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetm365appplatformUsercountsParameter, ReportRootGetm365appplatformUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appplatformusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetm365appplatformUsercountsResponse> ReportRootGetm365appplatformUsercountsAsync(ReportRootGetm365appplatformUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetm365appplatformUsercountsParameter, ReportRootGetm365appplatformUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
