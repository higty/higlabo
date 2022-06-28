
namespace HigLabo.Net.Slack
{
    public class UsergroupsUsersListParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "usergroups.users.list";
        public string HttpMethod { get; private set; } = "GET";
        public string Usergroup { get; set; } = "";
        public bool? Include_Disabled { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class UsergroupsUsersListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsergroupsUsersListResponse> UsergroupsUsersListAsync(string usergroup)
        {
            var p = new UsergroupsUsersListParameter();
            p.Usergroup = usergroup;
            return await this.SendAsync<UsergroupsUsersListParameter, UsergroupsUsersListResponse>(p, CancellationToken.None);
        }
        public async Task<UsergroupsUsersListResponse> UsergroupsUsersListAsync(string usergroup, CancellationToken cancellationToken)
        {
            var p = new UsergroupsUsersListParameter();
            p.Usergroup = usergroup;
            return await this.SendAsync<UsergroupsUsersListParameter, UsergroupsUsersListResponse>(p, cancellationToken);
        }
        public async Task<UsergroupsUsersListResponse> UsergroupsUsersListAsync(UsergroupsUsersListParameter parameter)
        {
            return await this.SendAsync<UsergroupsUsersListParameter, UsergroupsUsersListResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsergroupsUsersListResponse> UsergroupsUsersListAsync(UsergroupsUsersListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsergroupsUsersListParameter, UsergroupsUsersListResponse>(parameter, cancellationToken);
        }
    }
}
