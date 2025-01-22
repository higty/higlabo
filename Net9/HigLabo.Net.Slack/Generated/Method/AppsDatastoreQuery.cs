using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AppsDatastoreQueryParameter : IRestApiParameter, IRestApiPagingParameter
{
    string IRestApiParameter.ApiPath { get; } = "apps.datastore.query";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Datastore { get; set; }
    public string? App_Id { get; set; }
    public string? Cursor { get; set; }
    string? IRestApiPagingParameter.NextPageToken
    {
        get
        {
            return this.Cursor;
        }
        set
        {
            this.Cursor = value;
        }
    }
    public string? Expression { get; set; }
    public object? Expression_Attributes { get; set; }
    public object? Expression_Values { get; set; }
    public int? Limit { get; set; }
}
public partial class AppsDatastoreQueryResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/apps.datastore.query
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.query
    /// </summary>
    public async ValueTask<AppsDatastoreQueryResponse> AppsDatastoreQueryAsync(string? datastore)
    {
        var p = new AppsDatastoreQueryParameter();
        p.Datastore = datastore;
        return await this.SendAsync<AppsDatastoreQueryParameter, AppsDatastoreQueryResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.query
    /// </summary>
    public async ValueTask<AppsDatastoreQueryResponse> AppsDatastoreQueryAsync(string? datastore, CancellationToken cancellationToken)
    {
        var p = new AppsDatastoreQueryParameter();
        p.Datastore = datastore;
        return await this.SendAsync<AppsDatastoreQueryParameter, AppsDatastoreQueryResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.query
    /// </summary>
    public async ValueTask<AppsDatastoreQueryResponse> AppsDatastoreQueryAsync(AppsDatastoreQueryParameter parameter)
    {
        return await this.SendAsync<AppsDatastoreQueryParameter, AppsDatastoreQueryResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.query
    /// </summary>
    public async ValueTask<AppsDatastoreQueryResponse> AppsDatastoreQueryAsync(AppsDatastoreQueryParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AppsDatastoreQueryParameter, AppsDatastoreQueryResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.query
    /// </summary>
    public async ValueTask<List<AppsDatastoreQueryResponse>> AppsDatastoreQueryAsync(string? datastore, PagingContext<AppsDatastoreQueryResponse> context)
    {
        var p = new AppsDatastoreQueryParameter();
        p.Datastore = datastore;
        return await this.SendBatchAsync(p, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.query
    /// </summary>
    public async ValueTask<List<AppsDatastoreQueryResponse>> AppsDatastoreQueryAsync(string? datastore, PagingContext<AppsDatastoreQueryResponse> context, CancellationToken cancellationToken)
    {
        var p = new AppsDatastoreQueryParameter();
        p.Datastore = datastore;
        return await this.SendBatchAsync(p, context, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.query
    /// </summary>
    public async ValueTask<List<AppsDatastoreQueryResponse>> AppsDatastoreQueryAsync(AppsDatastoreQueryParameter parameter, PagingContext<AppsDatastoreQueryResponse> context)
    {
        return await this.SendBatchAsync(parameter, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.query
    /// </summary>
    public async ValueTask<List<AppsDatastoreQueryResponse>> AppsDatastoreQueryAsync(AppsDatastoreQueryParameter parameter, PagingContext<AppsDatastoreQueryResponse> context, CancellationToken cancellationToken)
    {
        return await this.SendBatchAsync(parameter, context, cancellationToken);
    }
}
