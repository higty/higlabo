using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class RtmStartParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "rtm.start";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public bool? Batch_Presence_Aware { get; set; }
    public bool? Include_Locale { get; set; }
    public bool? Mpim_Aware { get; set; }
    public bool? No_Latest { get; set; }
    public bool? No_Unreads { get; set; }
    public bool? Presence_Sub { get; set; }
    public bool? Simple_Latest { get; set; }
}
public partial class RtmStartResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/rtm.start
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/rtm.start
    /// </summary>
    public async ValueTask<RtmStartResponse> RtmStartAsync()
    {
        var p = new RtmStartParameter();
        return await this.SendAsync<RtmStartParameter, RtmStartResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/rtm.start
    /// </summary>
    public async ValueTask<RtmStartResponse> RtmStartAsync(CancellationToken cancellationToken)
    {
        var p = new RtmStartParameter();
        return await this.SendAsync<RtmStartParameter, RtmStartResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/rtm.start
    /// </summary>
    public async ValueTask<RtmStartResponse> RtmStartAsync(RtmStartParameter parameter)
    {
        return await this.SendAsync<RtmStartParameter, RtmStartResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/rtm.start
    /// </summary>
    public async ValueTask<RtmStartResponse> RtmStartAsync(RtmStartParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<RtmStartParameter, RtmStartResponse>(parameter, cancellationToken);
    }
}
