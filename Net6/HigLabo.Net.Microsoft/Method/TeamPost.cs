using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamPostParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams: return $"/teams";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class TeamPostResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/team-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPostResponse> TeamPostAsync()
        {
            var p = new TeamPostParameter();
            return await this.SendAsync<TeamPostParameter, TeamPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPostResponse> TeamPostAsync(CancellationToken cancellationToken)
        {
            var p = new TeamPostParameter();
            return await this.SendAsync<TeamPostParameter, TeamPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPostResponse> TeamPostAsync(TeamPostParameter parameter)
        {
            return await this.SendAsync<TeamPostParameter, TeamPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPostResponse> TeamPostAsync(TeamPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamPostParameter, TeamPostResponse>(parameter, cancellationToken);
        }
    }
}
