﻿
namespace HigLabo.Net.Slack
{
    public partial class AdminUsergroupsListChannelsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.usergroups.listChannels";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Usergroup_Id { get; set; }
        public bool? Include_Num_Members { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminUsergroupsListChannelsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsergroupsListChannelsResponse> AdminUsergroupsListChannelsAsync(string usergroup_Id)
        {
            var p = new AdminUsergroupsListChannelsParameter();
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsListChannelsParameter, AdminUsergroupsListChannelsResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsergroupsListChannelsResponse> AdminUsergroupsListChannelsAsync(string usergroup_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsergroupsListChannelsParameter();
            p.Usergroup_Id = usergroup_Id;
            return await this.SendAsync<AdminUsergroupsListChannelsParameter, AdminUsergroupsListChannelsResponse>(p, cancellationToken);
        }
        public async Task<AdminUsergroupsListChannelsResponse> AdminUsergroupsListChannelsAsync(AdminUsergroupsListChannelsParameter parameter)
        {
            return await this.SendAsync<AdminUsergroupsListChannelsParameter, AdminUsergroupsListChannelsResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsergroupsListChannelsResponse> AdminUsergroupsListChannelsAsync(AdminUsergroupsListChannelsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsergroupsListChannelsParameter, AdminUsergroupsListChannelsResponse>(parameter, cancellationToken);
        }
    }
}