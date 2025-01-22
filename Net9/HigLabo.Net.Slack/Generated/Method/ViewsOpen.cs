using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class ViewsOpenParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "views.open";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? View { get; set; }
    public string? Trigger_Id { get; set; }
    public string? Interactivity_Pointer { get; set; }
}
public partial class ViewsOpenResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/views.open
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/views.open
    /// </summary>
    public async ValueTask<ViewsOpenResponse> ViewsOpenAsync(string? view)
    {
        var p = new ViewsOpenParameter();
        p.View = view;
        return await this.SendAsync<ViewsOpenParameter, ViewsOpenResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/views.open
    /// </summary>
    public async ValueTask<ViewsOpenResponse> ViewsOpenAsync(string? view, CancellationToken cancellationToken)
    {
        var p = new ViewsOpenParameter();
        p.View = view;
        return await this.SendAsync<ViewsOpenParameter, ViewsOpenResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/views.open
    /// </summary>
    public async ValueTask<ViewsOpenResponse> ViewsOpenAsync(ViewsOpenParameter parameter)
    {
        return await this.SendAsync<ViewsOpenParameter, ViewsOpenResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/views.open
    /// </summary>
    public async ValueTask<ViewsOpenResponse> ViewsOpenAsync(ViewsOpenParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ViewsOpenParameter, ViewsOpenResponse>(parameter, cancellationToken);
    }
}
