using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydistributioncounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetTeamsteamActivitydistributioncountsParameter : IRestApiParameter, IQueryParameterProperty
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
public partial class ReportRootGetTeamsteamActivitydistributioncountsResponse : RestApiResponse
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
    public async ValueTask<ReportRootGetTeamsteamActivitydistributioncountsResponse> ReportRootGetTeamsteamActivitydistributioncountsAsync()
    {
        var p = new ReportRootGetTeamsteamActivitydistributioncountsParameter();
        return await this.SendAsync<ReportRootGetTeamsteamActivitydistributioncountsParameter, ReportRootGetTeamsteamActivitydistributioncountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydistributioncounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamActivitydistributioncountsResponse> ReportRootGetTeamsteamActivitydistributioncountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetTeamsteamActivitydistributioncountsParameter();
        return await this.SendAsync<ReportRootGetTeamsteamActivitydistributioncountsParameter, ReportRootGetTeamsteamActivitydistributioncountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydistributioncounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamActivitydistributioncountsResponse> ReportRootGetTeamsteamActivitydistributioncountsAsync(ReportRootGetTeamsteamActivitydistributioncountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetTeamsteamActivitydistributioncountsParameter, ReportRootGetTeamsteamActivitydistributioncountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydistributioncounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamActivitydistributioncountsResponse> ReportRootGetTeamsteamActivitydistributioncountsAsync(ReportRootGetTeamsteamActivitydistributioncountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetTeamsteamActivitydistributioncountsParameter, ReportRootGetTeamsteamActivitydistributioncountsResponse>(parameter, cancellationToken);
    }
}
