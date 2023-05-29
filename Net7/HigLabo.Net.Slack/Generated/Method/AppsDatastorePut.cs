using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AppsDatastorePutParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.datastore.put";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Datastore { get; set; }
        public object? Item { get; set; }
        public string? App_Id { get; set; }
    }
    public partial class AppsDatastorePutResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.datastore.put
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.put
        /// </summary>
        public async Task<AppsDatastorePutResponse> AppsDatastorePutAsync(string? datastore, object? item)
        {
            var p = new AppsDatastorePutParameter();
            p.Datastore = datastore;
            p.Item = item;
            return await this.SendAsync<AppsDatastorePutParameter, AppsDatastorePutResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.put
        /// </summary>
        public async Task<AppsDatastorePutResponse> AppsDatastorePutAsync(string? datastore, object? item, CancellationToken cancellationToken)
        {
            var p = new AppsDatastorePutParameter();
            p.Datastore = datastore;
            p.Item = item;
            return await this.SendAsync<AppsDatastorePutParameter, AppsDatastorePutResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.put
        /// </summary>
        public async Task<AppsDatastorePutResponse> AppsDatastorePutAsync(AppsDatastorePutParameter parameter)
        {
            return await this.SendAsync<AppsDatastorePutParameter, AppsDatastorePutResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.datastore.put
        /// </summary>
        public async Task<AppsDatastorePutResponse> AppsDatastorePutAsync(AppsDatastorePutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsDatastorePutParameter, AppsDatastorePutResponse>(parameter, cancellationToken);
        }
    }
}
