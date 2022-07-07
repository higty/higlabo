using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamCloneParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_Id_Clone,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Clone: return $"/teams/{Id}/clone";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Classification { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? MailNickname { get; set; }
        public ClonableTeamParts? PartsToClone { get; set; }
        public TeamVisibilityType? Visibility { get; set; }
        public string Id { get; set; }
    }
    public partial class TeamCloneResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public TeamsAsyncOperationType? OperationType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TeamsAsyncOperationStatus? Status { get; set; }
        public DateTimeOffset? LastActionDateTime { get; set; }
        public Int32? AttemptsCount { get; set; }
        public Guid? TargetResourceId { get; set; }
        public string? TargetResourceLocation { get; set; }
        public OperationError? Error { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-clone?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamCloneResponse> TeamCloneAsync()
        {
            var p = new TeamCloneParameter();
            return await this.SendAsync<TeamCloneParameter, TeamCloneResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-clone?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamCloneResponse> TeamCloneAsync(CancellationToken cancellationToken)
        {
            var p = new TeamCloneParameter();
            return await this.SendAsync<TeamCloneParameter, TeamCloneResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-clone?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamCloneResponse> TeamCloneAsync(TeamCloneParameter parameter)
        {
            return await this.SendAsync<TeamCloneParameter, TeamCloneResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-clone?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamCloneResponse> TeamCloneAsync(TeamCloneParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamCloneParameter, TeamCloneResponse>(parameter, cancellationToken);
        }
    }
}
