using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetteamsteamactivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetTeamsTeamActivityCounts: return $"/reports/getTeamsTeamActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsTeamActivityCounts,
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
    public partial class ReportRootGetteamsteamactivitycountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamactivitycountsResponse> ReportRootGetteamsteamactivitycountsAsync()
        {
            var p = new ReportRootGetteamsteamactivitycountsParameter();
            return await this.SendAsync<ReportRootGetteamsteamactivitycountsParameter, ReportRootGetteamsteamactivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamactivitycountsResponse> ReportRootGetteamsteamactivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetteamsteamactivitycountsParameter();
            return await this.SendAsync<ReportRootGetteamsteamactivitycountsParameter, ReportRootGetteamsteamactivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamactivitycountsResponse> ReportRootGetteamsteamactivitycountsAsync(ReportRootGetteamsteamactivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetteamsteamactivitycountsParameter, ReportRootGetteamsteamactivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamactivitycountsResponse> ReportRootGetteamsteamactivitycountsAsync(ReportRootGetteamsteamactivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetteamsteamactivitycountsParameter, ReportRootGetteamsteamactivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
