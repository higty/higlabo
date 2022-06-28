
namespace HigLabo.Net.Slack
{
    public class AdminUsergroupsAddTeamsParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.usergroups.addTeams";
        public string HttpMethod { get; private set; } = "POST";
        public string Team_Ids { get; set; } = "";
        public string Usergroup_Id { get; set; } = "";
        public bool? Auto_Provision { get; set; }
    }
    public partial class AdminUsergroupsAddTeamsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsergroupsAddTeamsResponse> AdminUsergroupsAddTeamsAsync(string team_Ids, string usergroup_Id)
        {
            var p = new AdminUsergroupsAddTeamsParameter();
            p.Team_Ids = team_Ids;
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsAddTeamsParameter, AdminUsergroupsAddTeamsResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsergroupsAddTeamsResponse> AdminUsergroupsAddTeamsAsync(string team_Ids, string usergroup_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsergroupsAddTeamsParameter();
            p.Team_Ids = team_Ids;
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsAddTeamsParameter, AdminUsergroupsAddTeamsResponse>(p, cancellationToken);
        }
        public async Task<AdminUsergroupsAddTeamsResponse> AdminUsergroupsAddTeamsAsync(AdminUsergroupsAddTeamsParameter parameter)
        {
            return await this.SendAsync<AdminUsergroupsAddTeamsParameter, AdminUsergroupsAddTeamsResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsergroupsAddTeamsResponse> AdminUsergroupsAddTeamsAsync(AdminUsergroupsAddTeamsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsergroupsAddTeamsParameter, AdminUsergroupsAddTeamsResponse>(parameter, cancellationToken);
        }
    }
}
