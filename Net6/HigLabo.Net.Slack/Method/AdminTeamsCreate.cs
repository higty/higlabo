
namespace HigLabo.Net.Slack
{
    public partial class AdminTeamsCreateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.teams.create";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Team_Domain { get; set; }
        public string Team_Name { get; set; }
        public string Team_Description { get; set; }
        public string Team_Discoverability { get; set; }
    }
    public partial class AdminTeamsCreateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.create
        /// </summary>
        public async Task<AdminTeamsCreateResponse> AdminTeamsCreateAsync(string team_Domain, string team_Name)
        {
            var p = new AdminTeamsCreateParameter();
            p.Team_Domain = team_Domain;
            p.Team_Name = team_Name;
            return await this.SendAsync<AdminTeamsCreateParameter, AdminTeamsCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.create
        /// </summary>
        public async Task<AdminTeamsCreateResponse> AdminTeamsCreateAsync(string team_Domain, string team_Name, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsCreateParameter();
            p.Team_Domain = team_Domain;
            p.Team_Name = team_Name;
            return await this.SendAsync<AdminTeamsCreateParameter, AdminTeamsCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.create
        /// </summary>
        public async Task<AdminTeamsCreateResponse> AdminTeamsCreateAsync(AdminTeamsCreateParameter parameter)
        {
            return await this.SendAsync<AdminTeamsCreateParameter, AdminTeamsCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.create
        /// </summary>
        public async Task<AdminTeamsCreateResponse> AdminTeamsCreateAsync(AdminTeamsCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsCreateParameter, AdminTeamsCreateResponse>(parameter, cancellationToken);
        }
    }
}
