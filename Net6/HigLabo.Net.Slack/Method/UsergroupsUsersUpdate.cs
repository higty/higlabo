
namespace HigLabo.Net.Slack
{
    public class UsergroupsUsersUpdateParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "usergroups.users.update";
        public string HttpMethod { get; private set; } = "POST";
        public string Usergroup { get; set; } = "";
        public string Users { get; set; } = "";
        public bool? Include_Count { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class UsergroupsUsersUpdateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsergroupsUsersUpdateResponse> UsergroupsUsersUpdateAsync(string usergroup, string users)
        {
            var p = new UsergroupsUsersUpdateParameter();
            p.Usergroup = usergroup;
            p.Users = users;
            return await this.SendAsync<UsergroupsUsersUpdateParameter, UsergroupsUsersUpdateResponse>(p, CancellationToken.None);
        }
        public async Task<UsergroupsUsersUpdateResponse> UsergroupsUsersUpdateAsync(string usergroup, string users, CancellationToken cancellationToken)
        {
            var p = new UsergroupsUsersUpdateParameter();
            p.Usergroup = usergroup;
            p.Users = users;
            return await this.SendAsync<UsergroupsUsersUpdateParameter, UsergroupsUsersUpdateResponse>(p, cancellationToken);
        }
        public async Task<UsergroupsUsersUpdateResponse> UsergroupsUsersUpdateAsync(UsergroupsUsersUpdateParameter parameter)
        {
            return await this.SendAsync<UsergroupsUsersUpdateParameter, UsergroupsUsersUpdateResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsergroupsUsersUpdateResponse> UsergroupsUsersUpdateAsync(UsergroupsUsersUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsergroupsUsersUpdateParameter, UsergroupsUsersUpdateResponse>(parameter, cancellationToken);
        }
    }
}
