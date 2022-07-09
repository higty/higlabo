using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
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
        public string? Id { get; set; }
        public TeamsASyncOperationType? OperationType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TeamsASyncOperationStatus? Status { get; set; }
        public DateTimeOffset? LastActionDateTime { get; set; }
        public Int32? AttemptsCount { get; set; }
        public Guid? TargetResourceId { get; set; }
        public string? TargetResourceLocation { get; set; }
        public OperationError? Error { get; set; }
    }
    public partial class TeamArchiveResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public TeamsASyncOperationType? OperationType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TeamsASyncOperationStatus? Status { get; set; }
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
