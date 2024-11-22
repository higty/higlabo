using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AppsDatastoreDeleteParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "apps.datastore.delete";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Datastore { get; set; }
    public string? Id { get; set; }
    public string? App_Id { get; set; }
}
public partial class AppsDatastoreDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/apps.datastore.delete
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.delete
    /// </summary>
    public async ValueTask<AppsDatastoreDeleteResponse> AppsDatastoreDeleteAsync(string? datastore, string? id)
    {
        var p = new AppsDatastoreDeleteParameter();
        p.Datastore = datastore;
        p.Id = id;
        return await this.SendAsync<AppsDatastoreDeleteParameter, AppsDatastoreDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.delete
    /// </summary>
    public async ValueTask<AppsDatastoreDeleteResponse> AppsDatastoreDeleteAsync(string? datastore, string? id, CancellationToken cancellationToken)
    {
        var p = new AppsDatastoreDeleteParameter();
        p.Datastore = datastore;
        p.Id = id;
        return await this.SendAsync<AppsDatastoreDeleteParameter, AppsDatastoreDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.delete
    /// </summary>
    public async ValueTask<AppsDatastoreDeleteResponse> AppsDatastoreDeleteAsync(AppsDatastoreDeleteParameter parameter)
    {
        return await this.SendAsync<AppsDatastoreDeleteParameter, AppsDatastoreDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.delete
    /// </summary>
    public async ValueTask<AppsDatastoreDeleteResponse> AppsDatastoreDeleteAsync(AppsDatastoreDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AppsDatastoreDeleteParameter, AppsDatastoreDeleteResponse>(parameter, cancellationToken);
    }
}
