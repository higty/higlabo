using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ChatDeleteScheduledMessageParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.deleteScheduledMessage";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel { get; set; }
        public string? Scheduled_Message_Id { get; set; }
        public bool? As_User { get; set; }
    }
    public partial class ChatDeleteScheduledMessageResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/chat.deleteScheduledMessage
        /// </summary>
        public async Task<ChatDeleteScheduledMessageResponse> ChatDeleteScheduledMessageAsync(string? channel, string? scheduled_Message_Id)
        {
            var p = new ChatDeleteScheduledMessageParameter();
            p.Channel = channel;
            p.Scheduled_Message_Id = scheduled_Message_Id;
            return await this.SendAsync<ChatDeleteScheduledMessageParameter, ChatDeleteScheduledMessageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.deleteScheduledMessage
        /// </summary>
        public async Task<ChatDeleteScheduledMessageResponse> ChatDeleteScheduledMessageAsync(string? channel, string? scheduled_Message_Id, CancellationToken cancellationToken)
        {
            var p = new ChatDeleteScheduledMessageParameter();
            p.Channel = channel;
            p.Scheduled_Message_Id = scheduled_Message_Id;
            return await this.SendAsync<ChatDeleteScheduledMessageParameter, ChatDeleteScheduledMessageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.deleteScheduledMessage
        /// </summary>
        public async Task<ChatDeleteScheduledMessageResponse> ChatDeleteScheduledMessageAsync(ChatDeleteScheduledMessageParameter parameter)
        {
            return await this.SendAsync<ChatDeleteScheduledMessageParameter, ChatDeleteScheduledMessageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.deleteScheduledMessage
        /// </summary>
        public async Task<ChatDeleteScheduledMessageResponse> ChatDeleteScheduledMessageAsync(ChatDeleteScheduledMessageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatDeleteScheduledMessageParameter, ChatDeleteScheduledMessageResponse>(parameter, cancellationToken);
        }
    }
}
