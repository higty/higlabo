using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AdminUsergroupsRemoveChannelsParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "admin.usergroups.removeChannels";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Channel_Ids { get; set; }
    public string? Usergroup_Id { get; set; }
}
public partial class AdminUsergroupsRemoveChannelsResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/admin.usergroups.removeChannels
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/admin.usergroups.removeChannels
    /// </summary>
    public async ValueTask<AdminUsergroupsRemoveChannelsResponse> AdminUsergroupsRemoveChannelsAsync(string? channel_Ids, string? usergroup_Id)
    {
        var p = new AdminUsergroupsRemoveChannelsParameter();
        p.Channel_Ids = channel_Ids;
        p.Usergroup_Id = usergroup_Id;
        return await this.SendAsync<AdminUsergroupsRemoveChannelsParameter, AdminUsergroupsRemoveChannelsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.usergroups.removeChannels
    /// </summary>
    public async ValueTask<AdminUsergroupsRemoveChannelsResponse> AdminUsergroupsRemoveChannelsAsync(string? channel_Ids, string? usergroup_Id, CancellationToken cancellationToken)
    {
        var p = new AdminUsergroupsRemoveChannelsParameter();
        p.Channel_Ids = channel_Ids;
        p.Usergroup_Id = usergroup_Id;
        return await this.SendAsync<AdminUsergroupsRemoveChannelsParameter, AdminUsergroupsRemoveChannelsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.usergroups.removeChannels
    /// </summary>
    public async ValueTask<AdminUsergroupsRemoveChannelsResponse> AdminUsergroupsRemoveChannelsAsync(AdminUsergroupsRemoveChannelsParameter parameter)
    {
        return await this.SendAsync<AdminUsergroupsRemoveChannelsParameter, AdminUsergroupsRemoveChannelsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.usergroups.removeChannels
    /// </summary>
    public async ValueTask<AdminUsergroupsRemoveChannelsResponse> AdminUsergroupsRemoveChannelsAsync(AdminUsergroupsRemoveChannelsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdminUsergroupsRemoveChannelsParameter, AdminUsergroupsRemoveChannelsResponse>(parameter, cancellationToken);
    }
}
