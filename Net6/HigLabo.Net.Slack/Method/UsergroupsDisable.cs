
namespace HigLabo.Net.Slack
{
    public class UsergroupsDisableParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "usergroups.disable";
        public string HttpMethod { get; private set; } = "POST";
        public string Usergroup { get; set; } = "";
        public bool? Include_Count { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class UsergroupsDisableResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsergroupsDisableResponse> UsergroupsDisableAsync(string usergroup)
        {
            var p = new UsergroupsDisableParameter();
            p.Usergroup = usergroup;
            return await this.SendAsync<UsergroupsDisableParameter, UsergroupsDisableResponse>(p, CancellationToken.None);
        }
        public async Task<UsergroupsDisableResponse> UsergroupsDisableAsync(string usergroup, CancellationToken cancellationToken)
        {
            var p = new UsergroupsDisableParameter();
            p.Usergroup = usergroup;
            return await this.SendAsync<UsergroupsDisableParameter, UsergroupsDisableResponse>(p, cancellationToken);
        }
        public async Task<UsergroupsDisableResponse> UsergroupsDisableAsync(UsergroupsDisableParameter parameter)
        {
            return await this.SendAsync<UsergroupsDisableParameter, UsergroupsDisableResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsergroupsDisableResponse> UsergroupsDisableAsync(UsergroupsDisableParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsergroupsDisableParameter, UsergroupsDisableResponse>(parameter, cancellationToken);
        }
    }
}
