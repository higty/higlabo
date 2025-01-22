using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AppsManifestDeleteParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "apps.manifest.delete";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? App_Id { get; set; }
}
public partial class AppsManifestDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/apps.manifest.delete
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/apps.manifest.delete
    /// </summary>
    public async ValueTask<AppsManifestDeleteResponse> AppsManifestDeleteAsync(string? app_Id)
    {
        var p = new AppsManifestDeleteParameter();
        p.App_Id = app_Id;
        return await this.SendAsync<AppsManifestDeleteParameter, AppsManifestDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.manifest.delete
    /// </summary>
    public async ValueTask<AppsManifestDeleteResponse> AppsManifestDeleteAsync(string? app_Id, CancellationToken cancellationToken)
    {
        var p = new AppsManifestDeleteParameter();
        p.App_Id = app_Id;
        return await this.SendAsync<AppsManifestDeleteParameter, AppsManifestDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.manifest.delete
    /// </summary>
    public async ValueTask<AppsManifestDeleteResponse> AppsManifestDeleteAsync(AppsManifestDeleteParameter parameter)
    {
        return await this.SendAsync<AppsManifestDeleteParameter, AppsManifestDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.manifest.delete
    /// </summary>
    public async ValueTask<AppsManifestDeleteResponse> AppsManifestDeleteAsync(AppsManifestDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AppsManifestDeleteParameter, AppsManifestDeleteResponse>(parameter, cancellationToken);
    }
}
