using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-post?view=graph-rest-1.0
/// </summary>
public partial class TeamPostParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams: return $"/teams";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams,
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
public partial class TeamPostResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/team-post?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamPostResponse> TeamPostAsync()
    {
        var p = new TeamPostParameter();
        return await this.SendAsync<TeamPostParameter, TeamPostResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamPostResponse> TeamPostAsync(CancellationToken cancellationToken)
    {
        var p = new TeamPostParameter();
        return await this.SendAsync<TeamPostParameter, TeamPostResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamPostResponse> TeamPostAsync(TeamPostParameter parameter)
    {
        return await this.SendAsync<TeamPostParameter, TeamPostResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamPostResponse> TeamPostAsync(TeamPostParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamPostParameter, TeamPostResponse>(parameter, cancellationToken);
    }
}
