using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-sendactivitynotification?view=graph-rest-1.0
    /// </summary>
    public partial class ChatSendActivitynotificationParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_SendActivityNotification: return $"/chats/{ChatId}/sendActivityNotification";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatId_SendActivityNotification,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public TeamworkActivityTopic? Topic { get; set; }
        public string? ActivityType { get; set; }
        public Int64? ChainId { get; set; }
        public ItemBody? PreviewText { get; set; }
        public KeyValuePair[]? TemplateParameters { get; set; }
        public TeamworkNotificationRecipient? Recipient { get; set; }
    }
    public partial class ChatSendActivitynotificationResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-sendactivitynotification?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatSendActivitynotificationResponse> ChatSendActivitynotificationAsync()
        {
            var p = new ChatSendActivitynotificationParameter();
            return await this.SendAsync<ChatSendActivitynotificationParameter, ChatSendActivitynotificationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatSendActivitynotificationResponse> ChatSendActivitynotificationAsync(CancellationToken cancellationToken)
        {
            var p = new ChatSendActivitynotificationParameter();
            return await this.SendAsync<ChatSendActivitynotificationParameter, ChatSendActivitynotificationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatSendActivitynotificationResponse> ChatSendActivitynotificationAsync(ChatSendActivitynotificationParameter parameter)
        {
            return await this.SendAsync<ChatSendActivitynotificationParameter, ChatSendActivitynotificationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-sendactivitynotification?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatSendActivitynotificationResponse> ChatSendActivitynotificationAsync(ChatSendActivitynotificationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatSendActivitynotificationParameter, ChatSendActivitynotificationResponse>(parameter, cancellationToken);
        }
    }
}
