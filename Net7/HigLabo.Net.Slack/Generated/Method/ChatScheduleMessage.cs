using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ChatScheduleMessageParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.scheduleMessage";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel { get; set; }
        public int? Post_At { get; set; }
        public string? Text { get; set; }
        public bool? As_User { get; set; }
        public string? Attachments { get; set; }
        public string? Blocks { get; set; }
        public bool? Link_Names { get; set; }
        public string? Metadata { get; set; }
        public string? Parse { get; set; }
        public bool? Reply_Broadcast { get; set; }
        public string? Thread_Ts { get; set; }
        public bool? Unfurl_Links { get; set; }
        public bool? Unfurl_Media { get; set; }
    }
    public partial class ChatScheduleMessageResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/chat.scheduleMessage
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduleMessage
        /// </summary>
        public async ValueTask<ChatScheduleMessageResponse> ChatScheduleMessageAsync(string? channel, int? post_At, string? text)
        {
            var p = new ChatScheduleMessageParameter();
            p.Channel = channel;
            p.Post_At = post_At;
            p.Text = text;
            return await this.SendAsync<ChatScheduleMessageParameter, ChatScheduleMessageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduleMessage
        /// </summary>
        public async ValueTask<ChatScheduleMessageResponse> ChatScheduleMessageAsync(string? channel, int? post_At, string? text, CancellationToken cancellationToken)
        {
            var p = new ChatScheduleMessageParameter();
            p.Channel = channel;
            p.Post_At = post_At;
            p.Text = text;
            return await this.SendAsync<ChatScheduleMessageParameter, ChatScheduleMessageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduleMessage
        /// </summary>
        public async ValueTask<ChatScheduleMessageResponse> ChatScheduleMessageAsync(ChatScheduleMessageParameter parameter)
        {
            return await this.SendAsync<ChatScheduleMessageParameter, ChatScheduleMessageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduleMessage
        /// </summary>
        public async ValueTask<ChatScheduleMessageResponse> ChatScheduleMessageAsync(ChatScheduleMessageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatScheduleMessageParameter, ChatScheduleMessageResponse>(parameter, cancellationToken);
        }
    }
}
