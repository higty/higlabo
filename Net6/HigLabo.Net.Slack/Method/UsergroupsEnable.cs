
namespace HigLabo.Net.Slack
{
    public partial class UsergroupsEnableParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "usergroups.enable";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Usergroup { get; set; }
        public bool? Include_Count { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class UsergroupsEnableResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsergroupsEnableResponse> UsergroupsEnableAsync(string usergroup)
        {
            var p = new UsergroupsEnableParameter();
            p.Usergroup = usergroup;
            return await this.SendAsync<UsergroupsEnableParameter, UsergroupsEnableResponse>(p, CancellationToken.None);
        }
        public async Task<UsergroupsEnableResponse> UsergroupsEnableAsync(string usergroup, CancellationToken cancellationToken)
        {
            var p = new UsergroupsEnableParameter();
            p.Usergroup = usergroup;
            return await this.SendAsync<UsergroupsEnableParameter, UsergroupsEnableResponse>(p, cancellationToken);
        }
        public async Task<UsergroupsEnableResponse> UsergroupsEnableAsync(UsergroupsEnableParameter parameter)
        {
            return await this.SendAsync<UsergroupsEnableParameter, UsergroupsEnableResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsergroupsEnableResponse> UsergroupsEnableAsync(UsergroupsEnableParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsergroupsEnableParameter, UsergroupsEnableResponse>(parameter, cancellationToken);
        }
    }
}
