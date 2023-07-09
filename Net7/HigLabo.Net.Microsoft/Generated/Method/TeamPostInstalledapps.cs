using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-post-installedapps?view=graph-rest-1.0
    /// </summary>
    public partial class TeamPostInstalledappsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_InstalledApps: return $"/teams/{TeamId}/installedApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_InstalledApps,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? TeamsApp { get; set; }
    }
    public partial class TeamPostInstalledappsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-post-installedapps?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamPostInstalledappsResponse> TeamPostInstalledappsAsync()
        {
            var p = new TeamPostInstalledappsParameter();
            return await this.SendAsync<TeamPostInstalledappsParameter, TeamPostInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamPostInstalledappsResponse> TeamPostInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamPostInstalledappsParameter();
            return await this.SendAsync<TeamPostInstalledappsParameter, TeamPostInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamPostInstalledappsResponse> TeamPostInstalledappsAsync(TeamPostInstalledappsParameter parameter)
        {
            return await this.SendAsync<TeamPostInstalledappsParameter, TeamPostInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamPostInstalledappsResponse> TeamPostInstalledappsAsync(TeamPostInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamPostInstalledappsParameter, TeamPostInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
