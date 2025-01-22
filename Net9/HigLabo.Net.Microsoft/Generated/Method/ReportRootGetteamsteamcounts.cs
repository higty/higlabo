using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamcounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetTeamsteamcountsParameter : IRestApiParameter, IQueryParameterProperty
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
public partial class ReportRootGetTeamsteamcountsResponse : RestApiResponse
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
    public async ValueTask<ReportRootGetTeamsteamcountsResponse> ReportRootGetTeamsteamcountsAsync()
    {
        var p = new ReportRootGetTeamsteamcountsParameter();
        return await this.SendAsync<ReportRootGetTeamsteamcountsParameter, ReportRootGetTeamsteamcountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamcountsResponse> ReportRootGetTeamsteamcountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetTeamsteamcountsParameter();
        return await this.SendAsync<ReportRootGetTeamsteamcountsParameter, ReportRootGetTeamsteamcountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamcountsResponse> ReportRootGetTeamsteamcountsAsync(ReportRootGetTeamsteamcountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetTeamsteamcountsParameter, ReportRootGetTeamsteamcountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamcountsResponse> ReportRootGetTeamsteamcountsAsync(ReportRootGetTeamsteamcountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetTeamsteamcountsParameter, ReportRootGetTeamsteamcountsResponse>(parameter, cancellationToken);
    }
}
