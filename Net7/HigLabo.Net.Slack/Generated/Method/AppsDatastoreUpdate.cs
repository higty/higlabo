using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.update
    /// </summary>
    public partial class AppsDatastoreUpdateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.datastore.update";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Datastore { get; set; }
        public object? Item { get; set; }
        public string? App_Id { get; set; }
    }
    public partial class AppsDatastoreUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.update
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.update
        /// </summary>
        public async ValueTask<AppsDatastoreUpdateResponse> AppsDatastoreUpdateAsync(string? datastore, object? item)
        {
            var p = new AppsDatastoreUpdateParameter();
            p.Datastore = datastore;
            p.Item = item;
            return await this.SendAsync<AppsDatastoreUpdateParameter, AppsDatastoreUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.update
        /// </summary>
        public async ValueTask<AppsDatastoreUpdateResponse> AppsDatastoreUpdateAsync(string? datastore, object? item, CancellationToken cancellationToken)
        {
            var p = new AppsDatastoreUpdateParameter();
            p.Datastore = datastore;
            p.Item = item;
            return await this.SendAsync<AppsDatastoreUpdateParameter, AppsDatastoreUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.update
        /// </summary>
        public async ValueTask<AppsDatastoreUpdateResponse> AppsDatastoreUpdateAsync(AppsDatastoreUpdateParameter parameter)
        {
            return await this.SendAsync<AppsDatastoreUpdateParameter, AppsDatastoreUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.update
        /// </summary>
        public async ValueTask<AppsDatastoreUpdateResponse> AppsDatastoreUpdateAsync(AppsDatastoreUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsDatastoreUpdateParameter, AppsDatastoreUpdateResponse>(parameter, cancellationToken);
        }
    }
}
