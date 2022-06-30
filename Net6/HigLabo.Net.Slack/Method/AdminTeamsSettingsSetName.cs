
namespace HigLabo.Net.Slack
{
    public partial class AdminTeamsSettingsSetNameParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.teams.settings.setName";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Name { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminTeamsSettingsSetNameResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminTeamsSettingsSetNameResponse> AdminTeamsSettingsSetNameAsync(string name, string team_Id)
        {
            var p = new AdminTeamsSettingsSetNameParameter();
            p.Name = name;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsSetNameParameter, AdminTeamsSettingsSetNameResponse>(p, CancellationToken.None);
        }
        public async Task<AdminTeamsSettingsSetNameResponse> AdminTeamsSettingsSetNameAsync(string name, string team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsSettingsSetNameParameter();
            p.Name = name;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsSetNameParameter, AdminTeamsSettingsSetNameResponse>(p, cancellationToken);
        }
        public async Task<AdminTeamsSettingsSetNameResponse> AdminTeamsSettingsSetNameAsync(AdminTeamsSettingsSetNameParameter parameter)
        {
            return await this.SendAsync<AdminTeamsSettingsSetNameParameter, AdminTeamsSettingsSetNameResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminTeamsSettingsSetNameResponse> AdminTeamsSettingsSetNameAsync(AdminTeamsSettingsSetNameParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsSettingsSetNameParameter, AdminTeamsSettingsSetNameResponse>(parameter, cancellationToken);
        }
    }
}
