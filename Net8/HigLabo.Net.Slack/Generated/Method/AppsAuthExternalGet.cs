using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AppsAuthExternalGetParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "apps.auth.external.get";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? External_Token_Id { get; set; }
    public bool? Force_Refresh { get; set; }
}
public partial class AppsAuthExternalGetResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/apps.auth.external.get
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/apps.auth.external.get
    /// </summary>
    public async ValueTask<AppsAuthExternalGetResponse> AppsAuthExternalGetAsync(string? external_Token_Id)
    {
        var p = new AppsAuthExternalGetParameter();
        p.External_Token_Id = external_Token_Id;
        return await this.SendAsync<AppsAuthExternalGetParameter, AppsAuthExternalGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.auth.external.get
    /// </summary>
    public async ValueTask<AppsAuthExternalGetResponse> AppsAuthExternalGetAsync(string? external_Token_Id, CancellationToken cancellationToken)
    {
        var p = new AppsAuthExternalGetParameter();
        p.External_Token_Id = external_Token_Id;
        return await this.SendAsync<AppsAuthExternalGetParameter, AppsAuthExternalGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.auth.external.get
    /// </summary>
    public async ValueTask<AppsAuthExternalGetResponse> AppsAuthExternalGetAsync(AppsAuthExternalGetParameter parameter)
    {
        return await this.SendAsync<AppsAuthExternalGetParameter, AppsAuthExternalGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.auth.external.get
    /// </summary>
    public async ValueTask<AppsAuthExternalGetResponse> AppsAuthExternalGetAsync(AppsAuthExternalGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AppsAuthExternalGetParameter, AppsAuthExternalGetResponse>(parameter, cancellationToken);
    }
}
