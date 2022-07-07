using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ChatUnfurlParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.unfurl";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
        public string Ts { get; set; }
        public string Unfurls { get; set; }
        public string Source { get; set; }
        public string Unfurl_Id { get; set; }
        public string User_Auth_Blocks { get; set; }
        public string User_Auth_Message { get; set; }
        public bool User_Auth_Required { get; set; }
        public string User_Auth_Url { get; set; }
    }
    public partial class ChatUnfurlResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/chat.unfurl
        /// </summary>
        public async Task<ChatUnfurlResponse> ChatUnfurlAsync(string channel, string ts, string unfurls)
        {
            var p = new ChatUnfurlParameter();
            p.Channel = channel;
            p.Ts = ts;
            p.Unfurls = unfurls;
            return await this.SendAsync<ChatUnfurlParameter, ChatUnfurlResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.unfurl
        /// </summary>
        public async Task<ChatUnfurlResponse> ChatUnfurlAsync(string channel, string ts, string unfurls, CancellationToken cancellationToken)
        {
            var p = new ChatUnfurlParameter();
            p.Channel = channel;
            p.Ts = ts;
            p.Unfurls = unfurls;
            return await this.SendAsync<ChatUnfurlParameter, ChatUnfurlResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.unfurl
        /// </summary>
        public async Task<ChatUnfurlResponse> ChatUnfurlAsync(ChatUnfurlParameter parameter)
        {
            return await this.SendAsync<ChatUnfurlParameter, ChatUnfurlResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.unfurl
        /// </summary>
        public async Task<ChatUnfurlResponse> ChatUnfurlAsync(ChatUnfurlParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatUnfurlParameter, ChatUnfurlResponse>(parameter, cancellationToken);
        }
    }
}
