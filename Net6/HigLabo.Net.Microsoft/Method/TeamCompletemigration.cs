using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamCompletemigrationParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_CompleteMigration,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_CompleteMigration: return $"/teams/{TeamId}/completeMigration";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
    }
    public partial class TeamCompletemigrationResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-completemigration?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamCompletemigrationResponse> TeamCompletemigrationAsync()
        {
            var p = new TeamCompletemigrationParameter();
            return await this.SendAsync<TeamCompletemigrationParameter, TeamCompletemigrationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-completemigration?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamCompletemigrationResponse> TeamCompletemigrationAsync(CancellationToken cancellationToken)
        {
            var p = new TeamCompletemigrationParameter();
            return await this.SendAsync<TeamCompletemigrationParameter, TeamCompletemigrationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-completemigration?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamCompletemigrationResponse> TeamCompletemigrationAsync(TeamCompletemigrationParameter parameter)
        {
            return await this.SendAsync<TeamCompletemigrationParameter, TeamCompletemigrationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-completemigration?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamCompletemigrationResponse> TeamCompletemigrationAsync(TeamCompletemigrationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamCompletemigrationParameter, TeamCompletemigrationResponse>(parameter, cancellationToken);
        }
    }
}
