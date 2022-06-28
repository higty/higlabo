
namespace HigLabo.Net.Slack
{
    public class AdminTeamsCreateParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.teams.create";
        public string HttpMethod { get; private set; } = "POST";
        public string Team_Domain { get; set; } = "";
        public string Team_Name { get; set; } = "";
        public string Team_Description { get; set; } = "";
        public string Team_Discoverability { get; set; } = "";
    }
    public partial class AdminTeamsCreateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminTeamsCreateResponse> AdminTeamsCreateAsync(string team_Domain, string team_Name)
        {
            var p = new AdminTeamsCreateParameter();
            p.Team_Domain = team_Domain;
            p.Team_Name = team_Name;
            return await this.SendAsync<AdminTeamsCreateParameter, AdminTeamsCreateResponse>(p, CancellationToken.None);
        }
        public async Task<AdminTeamsCreateResponse> AdminTeamsCreateAsync(string team_Domain, string team_Name, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsCreateParameter();
            p.Team_Domain = team_Domain;
            p.Team_Name = team_Name;
            return await this.SendAsync<AdminTeamsCreateParameter, AdminTeamsCreateResponse>(p, cancellationToken);
        }
        public async Task<AdminTeamsCreateResponse> AdminTeamsCreateAsync(AdminTeamsCreateParameter parameter)
        {
            return await this.SendAsync<AdminTeamsCreateParameter, AdminTeamsCreateResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminTeamsCreateResponse> AdminTeamsCreateAsync(AdminTeamsCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsCreateParameter, AdminTeamsCreateResponse>(parameter, cancellationToken);
        }
    }
}
