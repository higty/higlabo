using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetteamsUseractivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetTeamsUserActivityCounts: return $"/reports/getTeamsUserActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsUserActivityCounts,
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
    public partial class ReportRootGetteamsUseractivitycountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsUseractivitycountsResponse> ReportRootGetteamsUseractivitycountsAsync()
        {
            var p = new ReportRootGetteamsUseractivitycountsParameter();
            return await this.SendAsync<ReportRootGetteamsUseractivitycountsParameter, ReportRootGetteamsUseractivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsUseractivitycountsResponse> ReportRootGetteamsUseractivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetteamsUseractivitycountsParameter();
            return await this.SendAsync<ReportRootGetteamsUseractivitycountsParameter, ReportRootGetteamsUseractivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsUseractivitycountsResponse> ReportRootGetteamsUseractivitycountsAsync(ReportRootGetteamsUseractivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetteamsUseractivitycountsParameter, ReportRootGetteamsUseractivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsUseractivitycountsResponse> ReportRootGetteamsUseractivitycountsAsync(ReportRootGetteamsUseractivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetteamsUseractivitycountsParameter, ReportRootGetteamsUseractivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
