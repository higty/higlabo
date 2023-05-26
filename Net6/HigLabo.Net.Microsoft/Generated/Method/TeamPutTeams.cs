using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-put-teams?view=graph-rest-1.0
    /// </summary>
    public partial class TeamPutTeamsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Team: return $"/groups/{Id}/team";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_Team,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
    }
    public partial class TeamPutTeamsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? Classification { get; set; }
        public TeamClassSettings? ClassSettings { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public TeamFunSettings? FunSettings { get; set; }
        public TeamGuestSettings? GuestSettings { get; set; }
        public string? InternalId { get; set; }
        public bool? IsArchived { get; set; }
        public TeamMemberSettings? MemberSettings { get; set; }
        public TeamMessagingSettings? MessagingSettings { get; set; }
        public TeamSpecialization? Specialization { get; set; }
        public TeamSummary? Summary { get; set; }
        public string? TenantId { get; set; }
        public TeamVisibilityType? Visibility { get; set; }
        public string? WebUrl { get; set; }
        public Channel[]? AllChannels { get; set; }
        public Channel[]? Channels { get; set; }
        public Channel[]? IncomingChannels { get; set; }
        public TeamsAppInstallation[]? InstalledApps { get; set; }
        public ConversationMember[]? Members { get; set; }
        public TeamsASyncOperation[]? Operations { get; set; }
        public ProfilePhoto? Photo { get; set; }
        public Channel? PrimaryChannel { get; set; }
        public Schedule? Schedule { get; set; }
        public TeamworkTag[]? Tags { get; set; }
        public TeamsTemplate? Template { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-put-teams?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-put-teams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutTeamsResponse> TeamPutTeamsAsync()
        {
            var p = new TeamPutTeamsParameter();
            return await this.SendAsync<TeamPutTeamsParameter, TeamPutTeamsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-put-teams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutTeamsResponse> TeamPutTeamsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamPutTeamsParameter();
            return await this.SendAsync<TeamPutTeamsParameter, TeamPutTeamsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-put-teams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutTeamsResponse> TeamPutTeamsAsync(TeamPutTeamsParameter parameter)
        {
            return await this.SendAsync<TeamPutTeamsParameter, TeamPutTeamsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-put-teams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutTeamsResponse> TeamPutTeamsAsync(TeamPutTeamsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamPutTeamsParameter, TeamPutTeamsResponse>(parameter, cancellationToken);
        }
    }
}
