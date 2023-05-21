using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetm365appUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetM365AppUserCounts: return $"/reports/getM365AppUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetM365AppUserCounts,
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
    public partial class ReportRootGetm365appUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetm365appUsercountsResponse> ReportRootGetm365appUsercountsAsync()
        {
            var p = new ReportRootGetm365appUsercountsParameter();
            return await this.SendAsync<ReportRootGetm365appUsercountsParameter, ReportRootGetm365appUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetm365appUsercountsResponse> ReportRootGetm365appUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetm365appUsercountsParameter();
            return await this.SendAsync<ReportRootGetm365appUsercountsParameter, ReportRootGetm365appUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetm365appUsercountsResponse> ReportRootGetm365appUsercountsAsync(ReportRootGetm365appUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetm365appUsercountsParameter, ReportRootGetm365appUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetm365appUsercountsResponse> ReportRootGetm365appUsercountsAsync(ReportRootGetm365appUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetm365appUsercountsParameter, ReportRootGetm365appUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
