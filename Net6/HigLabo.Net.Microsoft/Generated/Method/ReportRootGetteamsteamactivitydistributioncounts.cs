using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydistributioncounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetteamsteamactivitydistributioncountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetTeamsTeamActivityDistributionCounts: return $"/reports/getTeamsTeamActivityDistributionCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsTeamActivityDistributionCounts,
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
    public partial class ReportRootGetteamsteamactivitydistributioncountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydistributioncounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydistributioncounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsteamactivitydistributioncountsResponse> ReportRootGetteamsteamactivitydistributioncountsAsync()
        {
            var p = new ReportRootGetteamsteamactivitydistributioncountsParameter();
            return await this.SendAsync<ReportRootGetteamsteamactivitydistributioncountsParameter, ReportRootGetteamsteamactivitydistributioncountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydistributioncounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsteamactivitydistributioncountsResponse> ReportRootGetteamsteamactivitydistributioncountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetteamsteamactivitydistributioncountsParameter();
            return await this.SendAsync<ReportRootGetteamsteamactivitydistributioncountsParameter, ReportRootGetteamsteamactivitydistributioncountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydistributioncounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsteamactivitydistributioncountsResponse> ReportRootGetteamsteamactivitydistributioncountsAsync(ReportRootGetteamsteamactivitydistributioncountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetteamsteamactivitydistributioncountsParameter, ReportRootGetteamsteamactivitydistributioncountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydistributioncounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsteamactivitydistributioncountsResponse> ReportRootGetteamsteamactivitydistributioncountsAsync(ReportRootGetteamsteamactivitydistributioncountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetteamsteamactivitydistributioncountsParameter, ReportRootGetteamsteamactivitydistributioncountsResponse>(parameter, cancellationToken);
        }
    }
}
