
namespace HigLabo.Net.Slack
{
    public partial class TeamPreferencesListParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "team.preferences.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
    }
    public partial class TeamPreferencesListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<TeamPreferencesListResponse> TeamPreferencesListAsync()
        {
            var p = new TeamPreferencesListParameter();
            return await this.SendAsync<TeamPreferencesListParameter, TeamPreferencesListResponse>(p, CancellationToken.None);
        }
        public async Task<TeamPreferencesListResponse> TeamPreferencesListAsync(CancellationToken cancellationToken)
        {
            var p = new TeamPreferencesListParameter();
            return await this.SendAsync<TeamPreferencesListParameter, TeamPreferencesListResponse>(p, cancellationToken);
        }
        public async Task<TeamPreferencesListResponse> TeamPreferencesListAsync(TeamPreferencesListParameter parameter)
        {
            return await this.SendAsync<TeamPreferencesListParameter, TeamPreferencesListResponse>(parameter, CancellationToken.None);
        }
        public async Task<TeamPreferencesListResponse> TeamPreferencesListAsync(TeamPreferencesListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamPreferencesListParameter, TeamPreferencesListResponse>(parameter, cancellationToken);
        }
    }
}
