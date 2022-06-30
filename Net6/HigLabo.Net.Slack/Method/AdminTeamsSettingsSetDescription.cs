
namespace HigLabo.Net.Slack
{
    public partial class AdminTeamsSettingsSetDescriptionParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.teams.settings.setDescription";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Description { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminTeamsSettingsSetDescriptionResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminTeamsSettingsSetDescriptionResponse> AdminTeamsSettingsSetDescriptionAsync(string description, string team_Id)
        {
            var p = new AdminTeamsSettingsSetDescriptionParameter();
            p.Description = description;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsSetDescriptionParameter, AdminTeamsSettingsSetDescriptionResponse>(p, CancellationToken.None);
        }
        public async Task<AdminTeamsSettingsSetDescriptionResponse> AdminTeamsSettingsSetDescriptionAsync(string description, string team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsSettingsSetDescriptionParameter();
            p.Description = description;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsSetDescriptionParameter, AdminTeamsSettingsSetDescriptionResponse>(p, cancellationToken);
        }
        public async Task<AdminTeamsSettingsSetDescriptionResponse> AdminTeamsSettingsSetDescriptionAsync(AdminTeamsSettingsSetDescriptionParameter parameter)
        {
            return await this.SendAsync<AdminTeamsSettingsSetDescriptionParameter, AdminTeamsSettingsSetDescriptionResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminTeamsSettingsSetDescriptionResponse> AdminTeamsSettingsSetDescriptionAsync(AdminTeamsSettingsSetDescriptionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsSettingsSetDescriptionParameter, AdminTeamsSettingsSetDescriptionResponse>(parameter, cancellationToken);
        }
    }
}
