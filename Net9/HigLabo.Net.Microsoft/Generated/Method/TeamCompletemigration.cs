using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-completemigration?view=graph-rest-1.0
/// </summary>
public partial class TeamCompleteMigrationParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_CompleteMigration: return $"/teams/{TeamId}/completeMigration";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_CompleteMigration,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
}
public partial class TeamCompleteMigrationResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-completemigration?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-completemigration?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamCompleteMigrationResponse> TeamCompleteMigrationAsync()
    {
        var p = new TeamCompleteMigrationParameter();
        return await this.SendAsync<TeamCompleteMigrationParameter, TeamCompleteMigrationResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-completemigration?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamCompleteMigrationResponse> TeamCompleteMigrationAsync(CancellationToken cancellationToken)
    {
        var p = new TeamCompleteMigrationParameter();
        return await this.SendAsync<TeamCompleteMigrationParameter, TeamCompleteMigrationResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-completemigration?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamCompleteMigrationResponse> TeamCompleteMigrationAsync(TeamCompleteMigrationParameter parameter)
    {
        return await this.SendAsync<TeamCompleteMigrationParameter, TeamCompleteMigrationResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-completemigration?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamCompleteMigrationResponse> TeamCompleteMigrationAsync(TeamCompleteMigrationParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamCompleteMigrationParameter, TeamCompleteMigrationResponse>(parameter, cancellationToken);
    }
}
