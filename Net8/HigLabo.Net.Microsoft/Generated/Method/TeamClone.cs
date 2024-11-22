using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-clone?view=graph-rest-1.0
/// </summary>
public partial class TeamCloneParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_Id_Clone: return $"/teams/{Id}/clone";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_Id_Clone,
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
    public string? Classification { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? MailNickname { get; set; }
    public ClonableTeamParts? PartsToClone { get; set; }
    public TeamVisibilityType? Visibility { get; set; }
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
public partial class TeamCloneResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/team-clone?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-clone?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamCloneResponse> TeamCloneAsync()
    {
        var p = new TeamCloneParameter();
        return await this.SendAsync<TeamCloneParameter, TeamCloneResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-clone?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamCloneResponse> TeamCloneAsync(CancellationToken cancellationToken)
    {
        var p = new TeamCloneParameter();
        return await this.SendAsync<TeamCloneParameter, TeamCloneResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-clone?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamCloneResponse> TeamCloneAsync(TeamCloneParameter parameter)
    {
        return await this.SendAsync<TeamCloneParameter, TeamCloneResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-clone?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamCloneResponse> TeamCloneAsync(TeamCloneParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamCloneParameter, TeamCloneResponse>(parameter, cancellationToken);
    }
}
