using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-markchatreadforuser?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMarkchatreadforUserParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_MarkChatReadForUser: return $"/chats/{ChatId}/markChatReadForUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatId_MarkChatReadForUser,
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
        public TeamworkUserIdentity? User { get; set; }
    }
    public partial class ChatMarkchatreadforUserResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-markchatreadforuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-markchatreadforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatMarkchatreadforUserResponse> ChatMarkchatreadforUserAsync()
        {
            var p = new ChatMarkchatreadforUserParameter();
            return await this.SendAsync<ChatMarkchatreadforUserParameter, ChatMarkchatreadforUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-markchatreadforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatMarkchatreadforUserResponse> ChatMarkchatreadforUserAsync(CancellationToken cancellationToken)
        {
            var p = new ChatMarkchatreadforUserParameter();
            return await this.SendAsync<ChatMarkchatreadforUserParameter, ChatMarkchatreadforUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-markchatreadforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatMarkchatreadforUserResponse> ChatMarkchatreadforUserAsync(ChatMarkchatreadforUserParameter parameter)
        {
            return await this.SendAsync<ChatMarkchatreadforUserParameter, ChatMarkchatreadforUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-markchatreadforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatMarkchatreadforUserResponse> ChatMarkchatreadforUserAsync(ChatMarkchatreadforUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatMarkchatreadforUserParameter, ChatMarkchatreadforUserResponse>(parameter, cancellationToken);
        }
    }
}
