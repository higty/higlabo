using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-post?view=graph-rest-1.0
    /// </summary>
    public partial class ChatPostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats: return $"/chats";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ChatPostParameterChatType
        {
            Group,
            OneOnOne,
        }
        public enum ApiPath
        {
            Chats,
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
        public string? Topic { get; set; }
        public ChatPostParameterChatType ChatType { get; set; }
        public ConversationMember[]? Members { get; set; }
    }
    public partial class ChatPostResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostResponse> ChatPostAsync()
        {
            var p = new ChatPostParameter();
            return await this.SendAsync<ChatPostParameter, ChatPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostResponse> ChatPostAsync(CancellationToken cancellationToken)
        {
            var p = new ChatPostParameter();
            return await this.SendAsync<ChatPostParameter, ChatPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostResponse> ChatPostAsync(ChatPostParameter parameter)
        {
            return await this.SendAsync<ChatPostParameter, ChatPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostResponse> ChatPostAsync(ChatPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatPostParameter, ChatPostResponse>(parameter, cancellationToken);
        }
    }
}
