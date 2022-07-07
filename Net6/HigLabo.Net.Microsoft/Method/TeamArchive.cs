using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamArchiveParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_Id_Archive,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Archive: return $"/teams/{Id}/archive";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class TeamArchiveResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/team-archive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamArchiveResponse> TeamArchiveAsync()
        {
            var p = new TeamArchiveParameter();
            return await this.SendAsync<TeamArchiveParameter, TeamArchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-archive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamArchiveResponse> TeamArchiveAsync(CancellationToken cancellationToken)
        {
            var p = new TeamArchiveParameter();
            return await this.SendAsync<TeamArchiveParameter, TeamArchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-archive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamArchiveResponse> TeamArchiveAsync(TeamArchiveParameter parameter)
        {
            return await this.SendAsync<TeamArchiveParameter, TeamArchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-archive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamArchiveResponse> TeamArchiveAsync(TeamArchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamArchiveParameter, TeamArchiveResponse>(parameter, cancellationToken);
        }
    }
}
