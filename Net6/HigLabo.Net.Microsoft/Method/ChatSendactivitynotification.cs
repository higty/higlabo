using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatSendactivitynotificationParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Chats_ChatId_SendActivityNotification,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Chats_ChatId_SendActivityNotification: return $"/chats/{ChatId}/sendActivityNotification";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public TeamworkActivityTopic? Topic { get; set; }
        public string? ActivityType { get; set; }
        public Int64? ChainId { get; set; }
        public ItemBody? PreviewText { get; set; }
        public KeyValuePair[]? TemplateParameters { get; set; }
        public TeamworkNotificationRecipient? Recipient { get; set; }
        public string ChatId { get; set; }
    }
    public partial class ChatSendactivitynotificationResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatSendactivitynotificationResponse> ChatSendactivitynotificationAsync()
        {
            var p = new ChatSendactivitynotificationParameter();
            return await this.SendAsync<ChatSendactivitynotificationParameter, ChatSendactivitynotificationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatSendactivitynotificationResponse> ChatSendactivitynotificationAsync(CancellationToken cancellationToken)
        {
            var p = new ChatSendactivitynotificationParameter();
            return await this.SendAsync<ChatSendactivitynotificationParameter, ChatSendactivitynotificationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatSendactivitynotificationResponse> ChatSendactivitynotificationAsync(ChatSendactivitynotificationParameter parameter)
        {
            return await this.SendAsync<ChatSendactivitynotificationParameter, ChatSendactivitynotificationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatSendactivitynotificationResponse> ChatSendactivitynotificationAsync(ChatSendactivitynotificationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatSendactivitynotificationParameter, ChatSendactivitynotificationResponse>(parameter, cancellationToken);
        }
    }
}
