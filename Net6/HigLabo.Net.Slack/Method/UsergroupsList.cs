
namespace HigLabo.Net.Slack
{
    public partial class UsergroupsListParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "usergroups.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public bool? Include_Count { get; set; }
        public bool? Include_Disabled { get; set; }
        public bool? Include_Users { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class UsergroupsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/usergroups.list
        /// </summary>
        public async Task<UsergroupsListResponse> UsergroupsListAsync()
        {
            var p = new UsergroupsListParameter();
            return await this.SendAsync<UsergroupsListParameter, UsergroupsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/usergroups.list
        /// </summary>
        public async Task<UsergroupsListResponse> UsergroupsListAsync(CancellationToken cancellationToken)
        {
            var p = new UsergroupsListParameter();
            return await this.SendAsync<UsergroupsListParameter, UsergroupsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/usergroups.list
        /// </summary>
        public async Task<UsergroupsListResponse> UsergroupsListAsync(UsergroupsListParameter parameter)
        {
            return await this.SendAsync<UsergroupsListParameter, UsergroupsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/usergroups.list
        /// </summary>
        public async Task<UsergroupsListResponse> UsergroupsListAsync(UsergroupsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsergroupsListParameter, UsergroupsListResponse>(parameter, cancellationToken);
        }
    }
}
