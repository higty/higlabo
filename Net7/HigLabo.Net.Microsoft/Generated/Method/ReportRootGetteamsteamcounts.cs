using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamcounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetteamsteamcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetTeamsTeamCounts: return $"/reports/getTeamsTeamCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsTeamCounts,
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
    public partial class ReportRootGetteamsteamcountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamcounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamcountsResponse> ReportRootGetteamsteamcountsAsync()
        {
            var p = new ReportRootGetteamsteamcountsParameter();
            return await this.SendAsync<ReportRootGetteamsteamcountsParameter, ReportRootGetteamsteamcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamcountsResponse> ReportRootGetteamsteamcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetteamsteamcountsParameter();
            return await this.SendAsync<ReportRootGetteamsteamcountsParameter, ReportRootGetteamsteamcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamcountsResponse> ReportRootGetteamsteamcountsAsync(ReportRootGetteamsteamcountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetteamsteamcountsParameter, ReportRootGetteamsteamcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamcountsResponse> ReportRootGetteamsteamcountsAsync(ReportRootGetteamsteamcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetteamsteamcountsParameter, ReportRootGetteamsteamcountsResponse>(parameter, cancellationToken);
        }
    }
}
