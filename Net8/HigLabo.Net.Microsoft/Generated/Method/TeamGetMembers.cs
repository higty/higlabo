using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-get-members?view=graph-rest-1.0
    /// </summary>
    public partial class TeamGetMembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? MembershipId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Members_MembershipId: return $"/teams/{TeamId}/members/{MembershipId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            Classification,
            ClassSettings,
            CreatedDateTime,
            Description,
            DisplayName,
            FunSettings,
            GuestSettings,
            InternalId,
            IsArchived,
            MemberSettings,
            MessagingSettings,
            Specialization,
            Summary,
            TenantId,
            Visibility,
            WebUrl,
            AllChannels,
            Channels,
            IncomingChannels,
            InstalledApps,
            Members,
            Operations,
            Photo,
            PrimaryChannel,
            Schedule,
            Tags,
            Template,
        }
        public enum ApiPath
        {
            Teams_TeamId_Members_MembershipId,
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
    public partial class TeamGetMembersResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string[]? Roles { get; set; }
        public DateTimeOffset? VisibleHistoryStartDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-get-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-get-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamGetMembersResponse> TeamGetMembersAsync()
        {
            var p = new TeamGetMembersParameter();
            return await this.SendAsync<TeamGetMembersParameter, TeamGetMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-get-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamGetMembersResponse> TeamGetMembersAsync(CancellationToken cancellationToken)
        {
            var p = new TeamGetMembersParameter();
            return await this.SendAsync<TeamGetMembersParameter, TeamGetMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-get-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamGetMembersResponse> TeamGetMembersAsync(TeamGetMembersParameter parameter)
        {
            return await this.SendAsync<TeamGetMembersParameter, TeamGetMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-get-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamGetMembersResponse> TeamGetMembersAsync(TeamGetMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamGetMembersParameter, TeamGetMembersResponse>(parameter, cancellationToken);
        }
    }
}
