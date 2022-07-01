using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminUsergroupsAddTeamsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.usergroups.addTeams";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Team_Ids { get; set; }
        public string Usergroup_Id { get; set; }
        public bool? Auto_Provision { get; set; }
    }
    public partial class AdminUsergroupsAddTeamsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.usergroups.addTeams
        /// </summary>
        public async Task<AdminUsergroupsAddTeamsResponse> AdminUsergroupsAddTeamsAsync(string team_Ids, string usergroup_Id)
        {
            var p = new AdminUsergroupsAddTeamsParameter();
            p.Team_Ids = team_Ids;
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsAddTeamsParameter, AdminUsergroupsAddTeamsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.usergroups.addTeams
        /// </summary>
        public async Task<AdminUsergroupsAddTeamsResponse> AdminUsergroupsAddTeamsAsync(string team_Ids, string usergroup_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsergroupsAddTeamsParameter();
            p.Team_Ids = team_Ids;
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsAddTeamsParameter, AdminUsergroupsAddTeamsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.usergroups.addTeams
        /// </summary>
        public async Task<AdminUsergroupsAddTeamsResponse> AdminUsergroupsAddTeamsAsync(AdminUsergroupsAddTeamsParameter parameter)
        {
            return await this.SendAsync<AdminUsergroupsAddTeamsParameter, AdminUsergroupsAddTeamsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.usergroups.addTeams
        /// </summary>
        public async Task<AdminUsergroupsAddTeamsResponse> AdminUsergroupsAddTeamsAsync(AdminUsergroupsAddTeamsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsergroupsAddTeamsParameter, AdminUsergroupsAddTeamsResponse>(parameter, cancellationToken);
        }
    }
}
