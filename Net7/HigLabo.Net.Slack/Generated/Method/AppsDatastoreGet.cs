using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.get
    /// </summary>
    public partial class AppsDatastoreGetParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.datastore.get";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Datastore { get; set; }
        public string? Id { get; set; }
        public string? App_Id { get; set; }
    }
    public partial class AppsDatastoreGetResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.get
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.get
        /// </summary>
        public async ValueTask<AppsDatastoreGetResponse> AppsDatastoreGetAsync(string? datastore, string? id)
        {
            var p = new AppsDatastoreGetParameter();
            p.Datastore = datastore;
            p.Id = id;
            return await this.SendAsync<AppsDatastoreGetParameter, AppsDatastoreGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.get
        /// </summary>
        public async ValueTask<AppsDatastoreGetResponse> AppsDatastoreGetAsync(string? datastore, string? id, CancellationToken cancellationToken)
        {
            var p = new AppsDatastoreGetParameter();
            p.Datastore = datastore;
            p.Id = id;
            return await this.SendAsync<AppsDatastoreGetParameter, AppsDatastoreGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.get
        /// </summary>
        public async ValueTask<AppsDatastoreGetResponse> AppsDatastoreGetAsync(AppsDatastoreGetParameter parameter)
        {
            return await this.SendAsync<AppsDatastoreGetParameter, AppsDatastoreGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.get
        /// </summary>
        public async ValueTask<AppsDatastoreGetResponse> AppsDatastoreGetAsync(AppsDatastoreGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsDatastoreGetParameter, AppsDatastoreGetResponse>(parameter, cancellationToken);
        }
    }
}
