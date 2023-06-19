using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-markchatunreadforuser?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMarkchatunreadforUserParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_MarkChatUnreadForUser: return $"/chats/{ChatId}/markChatUnreadForUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatId_MarkChatUnreadForUser,
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
        public DateTimeOffset? LastMessageReadDateTime { get; set; }
        public TeamworkUserIdentity? User { get; set; }
    }
    public partial class ChatMarkchatunreadforUserResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-markchatunreadforuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-markchatunreadforuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatMarkchatunreadforUserResponse> ChatMarkchatunreadforUserAsync()
        {
            var p = new ChatMarkchatunreadforUserParameter();
            return await this.SendAsync<ChatMarkchatunreadforUserParameter, ChatMarkchatunreadforUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-markchatunreadforuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatMarkchatunreadforUserResponse> ChatMarkchatunreadforUserAsync(CancellationToken cancellationToken)
        {
            var p = new ChatMarkchatunreadforUserParameter();
            return await this.SendAsync<ChatMarkchatunreadforUserParameter, ChatMarkchatunreadforUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-markchatunreadforuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatMarkchatunreadforUserResponse> ChatMarkchatunreadforUserAsync(ChatMarkchatunreadforUserParameter parameter)
        {
            return await this.SendAsync<ChatMarkchatunreadforUserParameter, ChatMarkchatunreadforUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-markchatunreadforuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatMarkchatunreadforUserResponse> ChatMarkchatunreadforUserAsync(ChatMarkchatunreadforUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatMarkchatunreadforUserParameter, ChatMarkchatunreadforUserResponse>(parameter, cancellationToken);
        }
    }
}
