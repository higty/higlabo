using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamPutTeamsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_Team,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Team: return $"/groups/{Id}/team";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string Id { get; set; }
    }
    public partial class TeamPutTeamsResponse : RestApiResponse
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
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-put-teams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutTeamsResponse> TeamPutTeamsAsync()
        {
            var p = new TeamPutTeamsParameter();
            return await this.SendAsync<TeamPutTeamsParameter, TeamPutTeamsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-put-teams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutTeamsResponse> TeamPutTeamsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamPutTeamsParameter();
            return await this.SendAsync<TeamPutTeamsParameter, TeamPutTeamsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-put-teams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutTeamsResponse> TeamPutTeamsAsync(TeamPutTeamsParameter parameter)
        {
            return await this.SendAsync<TeamPutTeamsParameter, TeamPutTeamsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-put-teams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutTeamsResponse> TeamPutTeamsAsync(TeamPutTeamsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamPutTeamsParameter, TeamPutTeamsResponse>(parameter, cancellationToken);
        }
    }
}
