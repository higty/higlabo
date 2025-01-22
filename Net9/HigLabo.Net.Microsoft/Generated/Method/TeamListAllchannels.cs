using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-list-allchannels?view=graph-rest-1.0
/// </summary>
public partial class TeamListAllchannelsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_AllChannels: return $"/teams/{TeamId}/allChannels";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teams_TeamId_AllChannels,
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
public partial class TeamListAllchannelsResponse : RestApiResponse<Channel>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-list-allchannels?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-allchannels?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListAllchannelsResponse> TeamListAllchannelsAsync()
    {
        var p = new TeamListAllchannelsParameter();
        return await this.SendAsync<TeamListAllchannelsParameter, TeamListAllchannelsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-allchannels?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListAllchannelsResponse> TeamListAllchannelsAsync(CancellationToken cancellationToken)
    {
        var p = new TeamListAllchannelsParameter();
        return await this.SendAsync<TeamListAllchannelsParameter, TeamListAllchannelsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-allchannels?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListAllchannelsResponse> TeamListAllchannelsAsync(TeamListAllchannelsParameter parameter)
    {
        return await this.SendAsync<TeamListAllchannelsParameter, TeamListAllchannelsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-allchannels?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListAllchannelsResponse> TeamListAllchannelsAsync(TeamListAllchannelsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamListAllchannelsParameter, TeamListAllchannelsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-allchannels?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Channel> TeamListAllchannelsEnumerateAsync(TeamListAllchannelsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<TeamListAllchannelsParameter, TeamListAllchannelsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Channel>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
