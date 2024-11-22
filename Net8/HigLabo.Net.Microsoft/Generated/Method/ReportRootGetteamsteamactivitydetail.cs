using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetTeamsteamActivitydetailParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetTeamsTeamActivityDetail: return $"/reports/getTeamsTeamActivityDetail";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetTeamsTeamActivityDetail,
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
public partial class ReportRootGetTeamsteamActivitydetailResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamActivitydetailResponse> ReportRootGetTeamsteamActivitydetailAsync()
    {
        var p = new ReportRootGetTeamsteamActivitydetailParameter();
        return await this.SendAsync<ReportRootGetTeamsteamActivitydetailParameter, ReportRootGetTeamsteamActivitydetailResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamActivitydetailResponse> ReportRootGetTeamsteamActivitydetailAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetTeamsteamActivitydetailParameter();
        return await this.SendAsync<ReportRootGetTeamsteamActivitydetailParameter, ReportRootGetTeamsteamActivitydetailResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamActivitydetailResponse> ReportRootGetTeamsteamActivitydetailAsync(ReportRootGetTeamsteamActivitydetailParameter parameter)
    {
        return await this.SendAsync<ReportRootGetTeamsteamActivitydetailParameter, ReportRootGetTeamsteamActivitydetailResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsteamActivitydetailResponse> ReportRootGetTeamsteamActivitydetailAsync(ReportRootGetTeamsteamActivitydetailParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetTeamsteamActivitydetailParameter, ReportRootGetTeamsteamActivitydetailResponse>(parameter, cancellationToken);
    }
}
