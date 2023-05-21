using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-unarchive?view=graph-rest-1.0
    /// </summary>
    public partial class TeamUnarchiveParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Unarchive: return $"/teams/{Id}/unarchive";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_Id_Unarchive,
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
    public partial class TeamUnarchiveResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/team-unarchive?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUnarchiveResponse> TeamUnarchiveAsync()
        {
            var p = new TeamUnarchiveParameter();
            return await this.SendAsync<TeamUnarchiveParameter, TeamUnarchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUnarchiveResponse> TeamUnarchiveAsync(CancellationToken cancellationToken)
        {
            var p = new TeamUnarchiveParameter();
            return await this.SendAsync<TeamUnarchiveParameter, TeamUnarchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUnarchiveResponse> TeamUnarchiveAsync(TeamUnarchiveParameter parameter)
        {
            return await this.SendAsync<TeamUnarchiveParameter, TeamUnarchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUnarchiveResponse> TeamUnarchiveAsync(TeamUnarchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamUnarchiveParameter, TeamUnarchiveResponse>(parameter, cancellationToken);
        }
    }
}
