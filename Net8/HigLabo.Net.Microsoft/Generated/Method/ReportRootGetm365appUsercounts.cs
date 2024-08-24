using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetM365appUsercountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetM365appUsercountsResponse : RestApiResponse
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
        public async ValueTask<ReportRootGetM365appUsercountsResponse> ReportRootGetM365appUsercountsAsync()
        {
            var p = new ReportRootGetM365appUsercountsParameter();
            return await this.SendAsync<ReportRootGetM365appUsercountsParameter, ReportRootGetM365appUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetM365appUsercountsResponse> ReportRootGetM365appUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetM365appUsercountsParameter();
            return await this.SendAsync<ReportRootGetM365appUsercountsParameter, ReportRootGetM365appUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetM365appUsercountsResponse> ReportRootGetM365appUsercountsAsync(ReportRootGetM365appUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetM365appUsercountsParameter, ReportRootGetM365appUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetM365appUsercountsResponse> ReportRootGetM365appUsercountsAsync(ReportRootGetM365appUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetM365appUsercountsParameter, ReportRootGetM365appUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
