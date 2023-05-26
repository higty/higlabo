using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminTeamsSettingsSetDefaultChannelsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.teams.settings.setDefaultChannels";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Channel_Ids { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminTeamsSettingsSetDefaultChannelsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.settings.setDefaultChannels
        /// </summary>
        public async Task<AdminTeamsSettingsSetDefaultChannelsResponse> AdminTeamsSettingsSetDefaultChannelsAsync(string? channel_Ids, string? team_Id)
        {
            var p = new AdminTeamsSettingsSetDefaultChannelsParameter();
            p.Channel_Ids = channel_Ids;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsSetDefaultChannelsParameter, AdminTeamsSettingsSetDefaultChannelsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.settings.setDefaultChannels
        /// </summary>
        public async Task<AdminTeamsSettingsSetDefaultChannelsResponse> AdminTeamsSettingsSetDefaultChannelsAsync(string? channel_Ids, string? team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsSettingsSetDefaultChannelsParameter();
            p.Channel_Ids = channel_Ids;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsSetDefaultChannelsParameter, AdminTeamsSettingsSetDefaultChannelsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.settings.setDefaultChannels
        /// </summary>
        public async Task<AdminTeamsSettingsSetDefaultChannelsResponse> AdminTeamsSettingsSetDefaultChannelsAsync(AdminTeamsSettingsSetDefaultChannelsParameter parameter)
        {
            return await this.SendAsync<AdminTeamsSettingsSetDefaultChannelsParameter, AdminTeamsSettingsSetDefaultChannelsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.settings.setDefaultChannels
        /// </summary>
        public async Task<AdminTeamsSettingsSetDefaultChannelsResponse> AdminTeamsSettingsSetDefaultChannelsAsync(AdminTeamsSettingsSetDefaultChannelsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsSettingsSetDefaultChannelsParameter, AdminTeamsSettingsSetDefaultChannelsResponse>(parameter, cancellationToken);
        }
    }
}
