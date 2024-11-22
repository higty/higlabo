using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AdminTeamsSettingsSetDiscoverabilityParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "admin.teams.settings.setDiscoverability";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Discoverability { get; set; }
    public string? Team_Id { get; set; }
}
public partial class AdminTeamsSettingsSetDiscoverabilityResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/admin.teams.settings.setDiscoverability
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/admin.teams.settings.setDiscoverability
    /// </summary>
    public async ValueTask<AdminTeamsSettingsSetDiscoverabilityResponse> AdminTeamsSettingsSetDiscoverabilityAsync(string? discoverability, string? team_Id)
    {
        var p = new AdminTeamsSettingsSetDiscoverabilityParameter();
        p.Discoverability = discoverability;
        p.Team_Id = team_Id;
        return await this.SendAsync<AdminTeamsSettingsSetDiscoverabilityParameter, AdminTeamsSettingsSetDiscoverabilityResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.teams.settings.setDiscoverability
    /// </summary>
    public async ValueTask<AdminTeamsSettingsSetDiscoverabilityResponse> AdminTeamsSettingsSetDiscoverabilityAsync(string? discoverability, string? team_Id, CancellationToken cancellationToken)
    {
        var p = new AdminTeamsSettingsSetDiscoverabilityParameter();
        p.Discoverability = discoverability;
        p.Team_Id = team_Id;
        return await this.SendAsync<AdminTeamsSettingsSetDiscoverabilityParameter, AdminTeamsSettingsSetDiscoverabilityResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.teams.settings.setDiscoverability
    /// </summary>
    public async ValueTask<AdminTeamsSettingsSetDiscoverabilityResponse> AdminTeamsSettingsSetDiscoverabilityAsync(AdminTeamsSettingsSetDiscoverabilityParameter parameter)
    {
        return await this.SendAsync<AdminTeamsSettingsSetDiscoverabilityParameter, AdminTeamsSettingsSetDiscoverabilityResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.teams.settings.setDiscoverability
    /// </summary>
    public async ValueTask<AdminTeamsSettingsSetDiscoverabilityResponse> AdminTeamsSettingsSetDiscoverabilityAsync(AdminTeamsSettingsSetDiscoverabilityParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdminTeamsSettingsSetDiscoverabilityParameter, AdminTeamsSettingsSetDiscoverabilityResponse>(parameter, cancellationToken);
    }
}
