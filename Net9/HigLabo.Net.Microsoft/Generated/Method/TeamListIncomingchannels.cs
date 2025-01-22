using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-list-incomingchannels?view=graph-rest-1.0
/// </summary>
public partial class TeamListIncomingchannelsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_IncomingChannels: return $"/teams/{TeamId}/incomingChannels";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teams_TeamId_IncomingChannels,
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
public partial class TeamListIncomingchannelsResponse : RestApiResponse<Channel>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/team-list-incomingchannels?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-incomingchannels?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListIncomingchannelsResponse> TeamListIncomingchannelsAsync()
    {
        var p = new TeamListIncomingchannelsParameter();
        return await this.SendAsync<TeamListIncomingchannelsParameter, TeamListIncomingchannelsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-incomingchannels?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListIncomingchannelsResponse> TeamListIncomingchannelsAsync(CancellationToken cancellationToken)
    {
        var p = new TeamListIncomingchannelsParameter();
        return await this.SendAsync<TeamListIncomingchannelsParameter, TeamListIncomingchannelsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-incomingchannels?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListIncomingchannelsResponse> TeamListIncomingchannelsAsync(TeamListIncomingchannelsParameter parameter)
    {
        return await this.SendAsync<TeamListIncomingchannelsParameter, TeamListIncomingchannelsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-incomingchannels?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TeamListIncomingchannelsResponse> TeamListIncomingchannelsAsync(TeamListIncomingchannelsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamListIncomingchannelsParameter, TeamListIncomingchannelsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-list-incomingchannels?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Channel> TeamListIncomingchannelsEnumerateAsync(TeamListIncomingchannelsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<TeamListIncomingchannelsParameter, TeamListIncomingchannelsResponse>(parameter, cancellationToken);
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
