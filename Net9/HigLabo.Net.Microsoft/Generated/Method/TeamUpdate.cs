using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-update?view=graph-rest-1.0
/// </summary>
public partial class TeamUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId: return $"/teams/{TeamId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
}
public partial class TeamUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamUpdateResponse> TeamUpdateAsync()
    {
        var p = new TeamUpdateParameter();
        return await this.SendAsync<TeamUpdateParameter, TeamUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamUpdateResponse> TeamUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new TeamUpdateParameter();
        return await this.SendAsync<TeamUpdateParameter, TeamUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamUpdateResponse> TeamUpdateAsync(TeamUpdateParameter parameter)
    {
        return await this.SendAsync<TeamUpdateParameter, TeamUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamUpdateResponse> TeamUpdateAsync(TeamUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamUpdateParameter, TeamUpdateResponse>(parameter, cancellationToken);
    }
}
