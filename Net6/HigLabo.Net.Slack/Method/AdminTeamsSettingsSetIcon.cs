﻿
namespace HigLabo.Net.Slack
{
    public partial class AdminTeamsSettingsSetIconParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.teams.settings.setIcon";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Image_Url { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminTeamsSettingsSetIconResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminTeamsSettingsSetIconResponse> AdminTeamsSettingsSetIconAsync(string image_Url, string team_Id)
        {
            var p = new AdminTeamsSettingsSetIconParameter();
            p.Image_Url = image_Url;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsSetIconParameter, AdminTeamsSettingsSetIconResponse>(p, CancellationToken.None);
        }
        public async Task<AdminTeamsSettingsSetIconResponse> AdminTeamsSettingsSetIconAsync(string image_Url, string team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsSettingsSetIconParameter();
            p.Image_Url = image_Url;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsSettingsSetIconParameter, AdminTeamsSettingsSetIconResponse>(p, cancellationToken);
        }
        public async Task<AdminTeamsSettingsSetIconResponse> AdminTeamsSettingsSetIconAsync(AdminTeamsSettingsSetIconParameter parameter)
        {
            return await this.SendAsync<AdminTeamsSettingsSetIconParameter, AdminTeamsSettingsSetIconResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminTeamsSettingsSetIconResponse> AdminTeamsSettingsSetIconAsync(AdminTeamsSettingsSetIconParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsSettingsSetIconParameter, AdminTeamsSettingsSetIconResponse>(parameter, cancellationToken);
        }
    }
}