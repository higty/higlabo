using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminUsergroupsAddChannelsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.usergroups.addChannels";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Ids { get; set; }
        public string? Usergroup_Id { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminUsergroupsAddChannelsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.usergroups.addChannels
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.usergroups.addChannels
        /// </summary>
        public async Task<AdminUsergroupsAddChannelsResponse> AdminUsergroupsAddChannelsAsync(string? channel_Ids, string? usergroup_Id)
        {
            var p = new AdminUsergroupsAddChannelsParameter();
            p.Channel_Ids = channel_Ids;
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsAddChannelsParameter, AdminUsergroupsAddChannelsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.usergroups.addChannels
        /// </summary>
        public async Task<AdminUsergroupsAddChannelsResponse> AdminUsergroupsAddChannelsAsync(string? channel_Ids, string? usergroup_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsergroupsAddChannelsParameter();
            p.Channel_Ids = channel_Ids;
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsAddChannelsParameter, AdminUsergroupsAddChannelsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.usergroups.addChannels
        /// </summary>
        public async Task<AdminUsergroupsAddChannelsResponse> AdminUsergroupsAddChannelsAsync(AdminUsergroupsAddChannelsParameter parameter)
        {
            return await this.SendAsync<AdminUsergroupsAddChannelsParameter, AdminUsergroupsAddChannelsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.usergroups.addChannels
        /// </summary>
        public async Task<AdminUsergroupsAddChannelsResponse> AdminUsergroupsAddChannelsAsync(AdminUsergroupsAddChannelsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsergroupsAddChannelsParameter, AdminUsergroupsAddChannelsResponse>(parameter, cancellationToken);
        }
    }
}
