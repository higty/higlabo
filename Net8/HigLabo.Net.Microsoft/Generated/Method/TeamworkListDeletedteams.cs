using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
/// </summary>
public partial class TeamworkListDeletedTeamsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teamwork_DeletedTeams: return $"/teamwork/deletedTeams";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teamwork_DeletedTeams,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class TeamworkListDeletedTeamsResponse : RestApiResponse<DeletedTeam>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamworkListDeletedTeamsResponse> TeamworkListDeletedTeamsAsync()
    {
        var p = new TeamworkListDeletedTeamsParameter();
        return await this.SendAsync<TeamworkListDeletedTeamsParameter, TeamworkListDeletedTeamsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamworkListDeletedTeamsResponse> TeamworkListDeletedTeamsAsync(CancellationToken cancellationToken)
    {
        var p = new TeamworkListDeletedTeamsParameter();
        return await this.SendAsync<TeamworkListDeletedTeamsParameter, TeamworkListDeletedTeamsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamworkListDeletedTeamsResponse> TeamworkListDeletedTeamsAsync(TeamworkListDeletedTeamsParameter parameter)
    {
        return await this.SendAsync<TeamworkListDeletedTeamsParameter, TeamworkListDeletedTeamsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamworkListDeletedTeamsResponse> TeamworkListDeletedTeamsAsync(TeamworkListDeletedTeamsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamworkListDeletedTeamsParameter, TeamworkListDeletedTeamsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DeletedTeam> TeamworkListDeletedTeamsEnumerateAsync(TeamworkListDeletedTeamsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<TeamworkListDeletedTeamsParameter, TeamworkListDeletedTeamsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DeletedTeam>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
