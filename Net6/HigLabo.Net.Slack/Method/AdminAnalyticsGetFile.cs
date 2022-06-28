
namespace HigLabo.Net.Slack
{
    public class AdminAnalyticsGetFileParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.analytics.getFile";
        public string HttpMethod { get; private set; } = "GET";
        public string Type { get; set; } = "";
        public string Date { get; set; } = "";
        public bool? Metadata_Only { get; set; }
    }
    public partial class AdminAnalyticsGetFileResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAnalyticsGetFileResponse> AdminAnalyticsGetFileAsync(string type)
        {
            var p = new AdminAnalyticsGetFileParameter();
            p.Type = type;
            return await this.SendAsync<AdminAnalyticsGetFileParameter, AdminAnalyticsGetFileResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAnalyticsGetFileResponse> AdminAnalyticsGetFileAsync(string type, CancellationToken cancellationToken)
        {
            var p = new AdminAnalyticsGetFileParameter();
            p.Type = type;
            return await this.SendAsync<AdminAnalyticsGetFileParameter, AdminAnalyticsGetFileResponse>(p, cancellationToken);
        }
        public async Task<AdminAnalyticsGetFileResponse> AdminAnalyticsGetFileAsync(AdminAnalyticsGetFileParameter parameter)
        {
            return await this.SendAsync<AdminAnalyticsGetFileParameter, AdminAnalyticsGetFileResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAnalyticsGetFileResponse> AdminAnalyticsGetFileAsync(AdminAnalyticsGetFileParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAnalyticsGetFileParameter, AdminAnalyticsGetFileResponse>(parameter, cancellationToken);
        }
    }
}
