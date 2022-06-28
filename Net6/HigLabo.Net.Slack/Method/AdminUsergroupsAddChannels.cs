
namespace HigLabo.Net.Slack
{
    public class AdminUsergroupsAddChannelsParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.usergroups.addChannels";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Ids { get; set; } = "";
        public string Usergroup_Id { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminUsergroupsAddChannelsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsergroupsAddChannelsResponse> AdminUsergroupsAddChannelsAsync(string channel_Ids, string usergroup_Id)
        {
            var p = new AdminUsergroupsAddChannelsParameter();
            p.Channel_Ids = channel_Ids;
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsAddChannelsParameter, AdminUsergroupsAddChannelsResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsergroupsAddChannelsResponse> AdminUsergroupsAddChannelsAsync(string channel_Ids, string usergroup_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsergroupsAddChannelsParameter();
            p.Channel_Ids = channel_Ids;
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsAddChannelsParameter, AdminUsergroupsAddChannelsResponse>(p, cancellationToken);
        }
        public async Task<AdminUsergroupsAddChannelsResponse> AdminUsergroupsAddChannelsAsync(AdminUsergroupsAddChannelsParameter parameter)
        {
            return await this.SendAsync<AdminUsergroupsAddChannelsParameter, AdminUsergroupsAddChannelsResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsergroupsAddChannelsResponse> AdminUsergroupsAddChannelsAsync(AdminUsergroupsAddChannelsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsergroupsAddChannelsParameter, AdminUsergroupsAddChannelsResponse>(parameter, cancellationToken);
        }
    }
}
