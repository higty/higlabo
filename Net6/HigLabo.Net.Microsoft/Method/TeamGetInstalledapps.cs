using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamGetInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            DisplayName,
            Description,
            Classification,
            Specialization,
            Visibility,
            FunSettings,
            GuestSettings,
            InternalId,
            IsArchived,
            MemberSettings,
            MessagingSettings,
            WebUrl,
            CreatedDateTime,
        }
        public enum ApiPath
        {
            Teams_Id_InstalledApps_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_InstalledApps_Id: return $"/teams/{TeamsId}/installedApps/{InstalledAppsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string TeamsId { get; set; }
        public string InstalledAppsId { get; set; }
    }
    public partial class TeamGetInstalledappsResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetInstalledappsResponse> TeamGetInstalledappsAsync()
        {
            var p = new TeamGetInstalledappsParameter();
            return await this.SendAsync<TeamGetInstalledappsParameter, TeamGetInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetInstalledappsResponse> TeamGetInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamGetInstalledappsParameter();
            return await this.SendAsync<TeamGetInstalledappsParameter, TeamGetInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetInstalledappsResponse> TeamGetInstalledappsAsync(TeamGetInstalledappsParameter parameter)
        {
            return await this.SendAsync<TeamGetInstalledappsParameter, TeamGetInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetInstalledappsResponse> TeamGetInstalledappsAsync(TeamGetInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamGetInstalledappsParameter, TeamGetInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
