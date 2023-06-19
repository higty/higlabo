using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-archive?view=graph-rest-1.0
    /// </summary>
    public partial class TeamArchiveParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Archive: return $"/teams/{Id}/archive";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_Id_Archive,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Int32? AttemptsCount { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public OperationError? Error { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastActionDateTime { get; set; }
        public TeamsASyncOperationType? OperationType { get; set; }
        public TeamsASyncOperationStatus? Status { get; set; }
        public Guid? TargetResourceId { get; set; }
        public string? TargetResourceLocation { get; set; }
    }
    public partial class TeamArchiveResponse : RestApiResponse
    {
        public Int32? AttemptsCount { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public OperationError? Error { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastActionDateTime { get; set; }
        public TeamsASyncOperationType? OperationType { get; set; }
        public TeamsASyncOperationStatus? Status { get; set; }
        public Guid? TargetResourceId { get; set; }
        public string? TargetResourceLocation { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-archive?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-archive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamArchiveResponse> TeamArchiveAsync()
        {
            var p = new TeamArchiveParameter();
            return await this.SendAsync<TeamArchiveParameter, TeamArchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-archive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamArchiveResponse> TeamArchiveAsync(CancellationToken cancellationToken)
        {
            var p = new TeamArchiveParameter();
            return await this.SendAsync<TeamArchiveParameter, TeamArchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-archive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamArchiveResponse> TeamArchiveAsync(TeamArchiveParameter parameter)
        {
            return await this.SendAsync<TeamArchiveParameter, TeamArchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-archive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamArchiveResponse> TeamArchiveAsync(TeamArchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamArchiveParameter, TeamArchiveResponse>(parameter, cancellationToken);
        }
    }
}
