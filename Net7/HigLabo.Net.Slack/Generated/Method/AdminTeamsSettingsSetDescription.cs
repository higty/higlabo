using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.teams.settings.setDescription
    /// </summary>
    public partial class AdminTeamsSettingsSetDescriptionParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.teams.settings.setDescription";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Description { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminTeamsSettingsSetDescriptionResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.teams.settings.setDescription
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.settings.setDescription
        /// </summary>
        public async ValueTask<AdminTeamsSettingsSetDescriptionResponse> AdminTeamsSettingsSetDescriptionAsync(string? description, string? team_Id)
        {
            var p = new AdminTeamsSettingsSetDescriptionParameter();
            p.Description = description;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsSetDescriptionParameter, AdminTeamsSettingsSetDescriptionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.settings.setDescription
        /// </summary>
        public async ValueTask<AdminTeamsSettingsSetDescriptionResponse> AdminTeamsSettingsSetDescriptionAsync(string? description, string? team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsSettingsSetDescriptionParameter();
            p.Description = description;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsSetDescriptionParameter, AdminTeamsSettingsSetDescriptionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.settings.setDescription
        /// </summary>
        public async ValueTask<AdminTeamsSettingsSetDescriptionResponse> AdminTeamsSettingsSetDescriptionAsync(AdminTeamsSettingsSetDescriptionParameter parameter)
        {
            return await this.SendAsync<AdminTeamsSettingsSetDescriptionParameter, AdminTeamsSettingsSetDescriptionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.settings.setDescription
        /// </summary>
        public async ValueTask<AdminTeamsSettingsSetDescriptionResponse> AdminTeamsSettingsSetDescriptionAsync(AdminTeamsSettingsSetDescriptionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsSettingsSetDescriptionParameter, AdminTeamsSettingsSetDescriptionResponse>(parameter, cancellationToken);
        }
    }
}
