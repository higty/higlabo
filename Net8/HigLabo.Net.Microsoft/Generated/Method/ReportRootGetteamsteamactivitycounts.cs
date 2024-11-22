using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitycounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetTeamsteamActivitycountsParameter : IRestApiParameter, IQueryParameterProperty
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
public partial class ReportRootGetTeamsteamActivitycountsResponse : RestApiResponse
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
    public async ValueTask<ReportRootGetTeamsteamActivitycountsResponse> ReportRootGetTeamsteamActivitycountsAsync()
    {
        var p = new ReportRootGetTeamsteamActivitycountsParameter();
        return await this.SendAsync<ReportRootGetTeamsteamActivitycountsParameter, ReportRootGetTeamsteamActivitycountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamActivitycountsResponse> ReportRootGetTeamsteamActivitycountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetTeamsteamActivitycountsParameter();
        return await this.SendAsync<ReportRootGetTeamsteamActivitycountsParameter, ReportRootGetTeamsteamActivitycountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamActivitycountsResponse> ReportRootGetTeamsteamActivitycountsAsync(ReportRootGetTeamsteamActivitycountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetTeamsteamActivitycountsParameter, ReportRootGetTeamsteamActivitycountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamActivitycountsResponse> ReportRootGetTeamsteamActivitycountsAsync(ReportRootGetTeamsteamActivitycountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetTeamsteamActivitycountsParameter, ReportRootGetTeamsteamActivitycountsResponse>(parameter, cancellationToken);
    }
}
