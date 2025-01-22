using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class ToolingTokensRotateParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "tooling.tokens.rotate";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? Refresh_Token { get; set; }
}
public partial class ToolingTokensRotateResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/tooling.tokens.rotate
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/tooling.tokens.rotate
    /// </summary>
    public async ValueTask<ToolingTokensRotateResponse> ToolingTokensRotateAsync(string? refresh_Token)
    {
        var p = new ToolingTokensRotateParameter();
        p.Refresh_Token = refresh_Token;
        return await this.SendAsync<ToolingTokensRotateParameter, ToolingTokensRotateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/tooling.tokens.rotate
    /// </summary>
    public async ValueTask<ToolingTokensRotateResponse> ToolingTokensRotateAsync(string? refresh_Token, CancellationToken cancellationToken)
    {
        var p = new ToolingTokensRotateParameter();
        p.Refresh_Token = refresh_Token;
        return await this.SendAsync<ToolingTokensRotateParameter, ToolingTokensRotateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/tooling.tokens.rotate
    /// </summary>
    public async ValueTask<ToolingTokensRotateResponse> ToolingTokensRotateAsync(ToolingTokensRotateParameter parameter)
    {
        return await this.SendAsync<ToolingTokensRotateParameter, ToolingTokensRotateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/tooling.tokens.rotate
    /// </summary>
    public async ValueTask<ToolingTokensRotateResponse> ToolingTokensRotateAsync(ToolingTokensRotateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ToolingTokensRotateParameter, ToolingTokensRotateResponse>(parameter, cancellationToken);
    }
}
