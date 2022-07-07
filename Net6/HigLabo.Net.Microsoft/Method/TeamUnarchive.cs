using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamUnarchiveParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_Id_Unarchive,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Unarchive: return $"/teams/{Id}/unarchive";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class TeamUnarchiveResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/team-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUnarchiveResponse> TeamUnarchiveAsync()
        {
            var p = new TeamUnarchiveParameter();
            return await this.SendAsync<TeamUnarchiveParameter, TeamUnarchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUnarchiveResponse> TeamUnarchiveAsync(CancellationToken cancellationToken)
        {
            var p = new TeamUnarchiveParameter();
            return await this.SendAsync<TeamUnarchiveParameter, TeamUnarchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUnarchiveResponse> TeamUnarchiveAsync(TeamUnarchiveParameter parameter)
        {
            return await this.SendAsync<TeamUnarchiveParameter, TeamUnarchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUnarchiveResponse> TeamUnarchiveAsync(TeamUnarchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamUnarchiveParameter, TeamUnarchiveResponse>(parameter, cancellationToken);
        }
    }
}
