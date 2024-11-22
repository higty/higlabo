using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AppsAuthExternalDeleteParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "apps.auth.external.delete";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? App_Id { get; set; }
    public string? External_Token_Id { get; set; }
    public string? Provider_Key { get; set; }
}
public partial class AppsAuthExternalDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/apps.auth.external.delete
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/apps.auth.external.delete
    /// </summary>
    public async ValueTask<AppsAuthExternalDeleteResponse> AppsAuthExternalDeleteAsync()
    {
        var p = new AppsAuthExternalDeleteParameter();
        return await this.SendAsync<AppsAuthExternalDeleteParameter, AppsAuthExternalDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.auth.external.delete
    /// </summary>
    public async ValueTask<AppsAuthExternalDeleteResponse> AppsAuthExternalDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new AppsAuthExternalDeleteParameter();
        return await this.SendAsync<AppsAuthExternalDeleteParameter, AppsAuthExternalDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.auth.external.delete
    /// </summary>
    public async ValueTask<AppsAuthExternalDeleteResponse> AppsAuthExternalDeleteAsync(AppsAuthExternalDeleteParameter parameter)
    {
        return await this.SendAsync<AppsAuthExternalDeleteParameter, AppsAuthExternalDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.auth.external.delete
    /// </summary>
    public async ValueTask<AppsAuthExternalDeleteResponse> AppsAuthExternalDeleteAsync(AppsAuthExternalDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AppsAuthExternalDeleteParameter, AppsAuthExternalDeleteResponse>(parameter, cancellationToken);
    }
}
