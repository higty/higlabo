using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId: return $"/teams/{TeamId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

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
            Channels,
            InstalledApps,
            Members,
            Operations,
            PrimaryChannel,
            Schedule,
            Template,
        }
        public enum ApiPath
        {
            Teams_TeamId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class TeamGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Classification { get; set; }
        public TeamSpecialization? Specialization { get; set; }
        public TeamVisibilityType? Visibility { get; set; }
        public TeamFunSettings? FunSettings { get; set; }
        public TeamGuestSettings? GuestSettings { get; set; }
        public string? InternalId { get; set; }
        public bool? IsArchived { get; set; }
        public TeamMemberSettings? MemberSettings { get; set; }
        public TeamMessagingSettings? MessagingSettings { get; set; }
        public string? WebUrl { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public Channel[]? Channels { get; set; }
        public TeamsAppInstallation[]? InstalledApps { get; set; }
        public ConversationMember[]? Members { get; set; }
        public TeamsASyncOperation[]? Operations { get; set; }
        public Channel? PrimaryChannel { get; set; }
        public Schedule? Schedule { get; set; }
        public TeamsTemplate? Template { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetResponse> TeamGetAsync()
        {
            var p = new TeamGetParameter();
            return await this.SendAsync<TeamGetParameter, TeamGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetResponse> TeamGetAsync(CancellationToken cancellationToken)
        {
            var p = new TeamGetParameter();
            return await this.SendAsync<TeamGetParameter, TeamGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetResponse> TeamGetAsync(TeamGetParameter parameter)
        {
            return await this.SendAsync<TeamGetParameter, TeamGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetResponse> TeamGetAsync(TeamGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamGetParameter, TeamGetResponse>(parameter, cancellationToken);
        }
    }
}
