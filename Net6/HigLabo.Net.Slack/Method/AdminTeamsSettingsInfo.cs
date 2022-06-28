
namespace HigLabo.Net.Slack
{
    public class AdminTeamsSettingsInfoParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.teams.settings.info";
        public string HttpMethod { get; private set; } = "POST";
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminTeamsSettingsInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminTeamsSettingsInfoResponse> AdminTeamsSettingsInfoAsync(string team_Id)
        {
            var p = new AdminTeamsSettingsInfoParameter();
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsInfoParameter, AdminTeamsSettingsInfoResponse>(p, CancellationToken.None);
        }
        public async Task<AdminTeamsSettingsInfoResponse> AdminTeamsSettingsInfoAsync(string team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsSettingsInfoParameter();
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsInfoParameter, AdminTeamsSettingsInfoResponse>(p, cancellationToken);
        }
        public async Task<AdminTeamsSettingsInfoResponse> AdminTeamsSettingsInfoAsync(AdminTeamsSettingsInfoParameter parameter)
        {
            return await this.SendAsync<AdminTeamsSettingsInfoParameter, AdminTeamsSettingsInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminTeamsSettingsInfoResponse> AdminTeamsSettingsInfoAsync(AdminTeamsSettingsInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsSettingsInfoParameter, AdminTeamsSettingsInfoResponse>(parameter, cancellationToken);
        }
    }
}
