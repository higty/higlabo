
namespace HigLabo.Net.Slack
{
    public partial class UsergroupsCreateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "usergroups.create";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Name { get; set; }
        public string Channels { get; set; }
        public string Description { get; set; }
        public string Handle { get; set; }
        public bool? Include_Count { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class UsergroupsCreateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsergroupsCreateResponse> UsergroupsCreateAsync(string name)
        {
            var p = new UsergroupsCreateParameter();
            p.Name = name;
            return await this.SendAsync<UsergroupsCreateParameter, UsergroupsCreateResponse>(p, CancellationToken.None);
        }
        public async Task<UsergroupsCreateResponse> UsergroupsCreateAsync(string name, CancellationToken cancellationToken)
        {
            var p = new UsergroupsCreateParameter();
            p.Name = name;
            return await this.SendAsync<UsergroupsCreateParameter, UsergroupsCreateResponse>(p, cancellationToken);
        }
        public async Task<UsergroupsCreateResponse> UsergroupsCreateAsync(UsergroupsCreateParameter parameter)
        {
            return await this.SendAsync<UsergroupsCreateParameter, UsergroupsCreateResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsergroupsCreateResponse> UsergroupsCreateAsync(UsergroupsCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsergroupsCreateParameter, UsergroupsCreateResponse>(parameter, cancellationToken);
        }
    }
}
