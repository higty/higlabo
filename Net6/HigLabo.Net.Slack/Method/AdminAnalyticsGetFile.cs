using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminAnalyticsGetFileParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.analytics.getFile";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Type { get; set; }
        public string Date { get; set; }
        public bool Metadata_Only { get; set; }
    }
    public partial class AdminAnalyticsGetFileResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.analytics.getFile
        /// </summary>
        public async Task<AdminAnalyticsGetFileResponse> AdminAnalyticsGetFileAsync(string type)
        {
            var p = new AdminAnalyticsGetFileParameter();
            p.Type = type;
            return await this.SendAsync<AdminAnalyticsGetFileParameter, AdminAnalyticsGetFileResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.analytics.getFile
        /// </summary>
        public async Task<AdminAnalyticsGetFileResponse> AdminAnalyticsGetFileAsync(string type, CancellationToken cancellationToken)
        {
            var p = new AdminAnalyticsGetFileParameter();
            p.Type = type;
            return await this.SendAsync<AdminAnalyticsGetFileParameter, AdminAnalyticsGetFileResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.analytics.getFile
        /// </summary>
        public async Task<AdminAnalyticsGetFileResponse> AdminAnalyticsGetFileAsync(AdminAnalyticsGetFileParameter parameter)
        {
            return await this.SendAsync<AdminAnalyticsGetFileParameter, AdminAnalyticsGetFileResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.analytics.getFile
        /// </summary>
        public async Task<AdminAnalyticsGetFileResponse> AdminAnalyticsGetFileAsync(AdminAnalyticsGetFileParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAnalyticsGetFileParameter, AdminAnalyticsGetFileResponse>(parameter, cancellationToken);
        }
    }
}
