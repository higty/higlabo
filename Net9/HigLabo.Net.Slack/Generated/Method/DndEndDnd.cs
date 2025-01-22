using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class DndEndDndParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "dnd.endDnd";
    string IRestApiParameter.HttpMethod { get; } = "POST";
}
public partial class DndEndDndResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/dnd.endDnd
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/dnd.endDnd
    /// </summary>
    public async ValueTask<DndEndDndResponse> DndEndDndAsync()
    {
        var p = new DndEndDndParameter();
        return await this.SendAsync<DndEndDndParameter, DndEndDndResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/dnd.endDnd
    /// </summary>
    public async ValueTask<DndEndDndResponse> DndEndDndAsync(CancellationToken cancellationToken)
    {
        var p = new DndEndDndParameter();
        return await this.SendAsync<DndEndDndParameter, DndEndDndResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/dnd.endDnd
    /// </summary>
    public async ValueTask<DndEndDndResponse> DndEndDndAsync(DndEndDndParameter parameter)
    {
        return await this.SendAsync<DndEndDndParameter, DndEndDndResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/dnd.endDnd
    /// </summary>
    public async ValueTask<DndEndDndResponse> DndEndDndAsync(DndEndDndParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DndEndDndParameter, DndEndDndResponse>(parameter, cancellationToken);
    }
}
