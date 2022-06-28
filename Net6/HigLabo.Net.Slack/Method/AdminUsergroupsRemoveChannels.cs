
namespace HigLabo.Net.Slack
{
    public class AdminUsergroupsRemoveChannelsParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.usergroups.removeChannels";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Ids { get; set; } = "";
        public string Usergroup_Id { get; set; } = "";
    }
    public partial class AdminUsergroupsRemoveChannelsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsergroupsRemoveChannelsResponse> AdminUsergroupsRemoveChannelsAsync(string channel_Ids, string usergroup_Id)
        {
            var p = new AdminUsergroupsRemoveChannelsParameter();
            p.Channel_Ids = channel_Ids;
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsRemoveChannelsParameter, AdminUsergroupsRemoveChannelsResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsergroupsRemoveChannelsResponse> AdminUsergroupsRemoveChannelsAsync(string channel_Ids, string usergroup_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsergroupsRemoveChannelsParameter();
            p.Channel_Ids = channel_Ids;
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsRemoveChannelsParameter, AdminUsergroupsRemoveChannelsResponse>(p, cancellationToken);
        }
        public async Task<AdminUsergroupsRemoveChannelsResponse> AdminUsergroupsRemoveChannelsAsync(AdminUsergroupsRemoveChannelsParameter parameter)
        {
            return await this.SendAsync<AdminUsergroupsRemoveChannelsParameter, AdminUsergroupsRemoveChannelsResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsergroupsRemoveChannelsResponse> AdminUsergroupsRemoveChannelsAsync(AdminUsergroupsRemoveChannelsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsergroupsRemoveChannelsParameter, AdminUsergroupsRemoveChannelsResponse>(parameter, cancellationToken);
        }
    }
}
