using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class ReactionsAddParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "reactions.add";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Channel { get; set; }
    public string? Name { get; set; }
    public string? Timestamp { get; set; }
}
public partial class ReactionsAddResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/reactions.add
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/reactions.add
    /// </summary>
    public async ValueTask<ReactionsAddResponse> ReactionsAddAsync(string? channel, string? name, string? timestamp)
    {
        var p = new ReactionsAddParameter();
        p.Channel = channel;
        p.Name = name;
        p.Timestamp = timestamp;
        return await this.SendAsync<ReactionsAddParameter, ReactionsAddResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/reactions.add
    /// </summary>
    public async ValueTask<ReactionsAddResponse> ReactionsAddAsync(string? channel, string? name, string? timestamp, CancellationToken cancellationToken)
    {
        var p = new ReactionsAddParameter();
        p.Channel = channel;
        p.Name = name;
        p.Timestamp = timestamp;
        return await this.SendAsync<ReactionsAddParameter, ReactionsAddResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/reactions.add
    /// </summary>
    public async ValueTask<ReactionsAddResponse> ReactionsAddAsync(ReactionsAddParameter parameter)
    {
        return await this.SendAsync<ReactionsAddParameter, ReactionsAddResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/reactions.add
    /// </summary>
    public async ValueTask<ReactionsAddResponse> ReactionsAddAsync(ReactionsAddParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReactionsAddParameter, ReactionsAddResponse>(parameter, cancellationToken);
    }
}
