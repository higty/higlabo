using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class DndInfoParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "dnd.info";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? Team_Id { get; set; }
    public string? User { get; set; }
}
public partial class DndInfoResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/dnd.info
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/dnd.info
    /// </summary>
    public async ValueTask<DndInfoResponse> DndInfoAsync()
    {
        var p = new DndInfoParameter();
        return await this.SendAsync<DndInfoParameter, DndInfoResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/dnd.info
    /// </summary>
    public async ValueTask<DndInfoResponse> DndInfoAsync(CancellationToken cancellationToken)
    {
        var p = new DndInfoParameter();
        return await this.SendAsync<DndInfoParameter, DndInfoResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/dnd.info
    /// </summary>
    public async ValueTask<DndInfoResponse> DndInfoAsync(DndInfoParameter parameter)
    {
        return await this.SendAsync<DndInfoParameter, DndInfoResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/dnd.info
    /// </summary>
    public async ValueTask<DndInfoResponse> DndInfoAsync(DndInfoParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DndInfoParameter, DndInfoResponse>(parameter, cancellationToken);
    }
}
