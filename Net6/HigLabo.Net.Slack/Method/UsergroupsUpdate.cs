
namespace HigLabo.Net.Slack
{
    public partial class UsergroupsUpdateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "usergroups.update";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Usergroup { get; set; }
        public string Channels { get; set; }
        public string Description { get; set; }
        public string Handle { get; set; }
        public bool? Include_Count { get; set; }
        public string Name { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class UsergroupsUpdateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsergroupsUpdateResponse> UsergroupsUpdateAsync(string usergroup)
        {
            var p = new UsergroupsUpdateParameter();
            p.Usergroup = usergroup;
            return await this.SendAsync<UsergroupsUpdateParameter, UsergroupsUpdateResponse>(p, CancellationToken.None);
        }
        public async Task<UsergroupsUpdateResponse> UsergroupsUpdateAsync(string usergroup, CancellationToken cancellationToken)
        {
            var p = new UsergroupsUpdateParameter();
            p.Usergroup = usergroup;
            return await this.SendAsync<UsergroupsUpdateParameter, UsergroupsUpdateResponse>(p, cancellationToken);
        }
        public async Task<UsergroupsUpdateResponse> UsergroupsUpdateAsync(UsergroupsUpdateParameter parameter)
        {
            return await this.SendAsync<UsergroupsUpdateParameter, UsergroupsUpdateResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsergroupsUpdateResponse> UsergroupsUpdateAsync(UsergroupsUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsergroupsUpdateParameter, UsergroupsUpdateResponse>(parameter, cancellationToken);
        }
    }
}
