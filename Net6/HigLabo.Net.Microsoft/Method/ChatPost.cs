using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatPostParameter : IRestApiParameter
    {
        public enum ChatPostParameterChatType
        {
            Group,
            OneOnOne,
        }
        public enum ApiPath
        {
            Chats,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Chats: return $"/chats";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostResponse> ChatPostAsync()
        {
            var p = new ChatPostParameter();
            return await this.SendAsync<ChatPostParameter, ChatPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostResponse> ChatPostAsync(CancellationToken cancellationToken)
        {
            var p = new ChatPostParameter();
            return await this.SendAsync<ChatPostParameter, ChatPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostResponse> ChatPostAsync(ChatPostParameter parameter)
        {
            return await this.SendAsync<ChatPostParameter, ChatPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostResponse> ChatPostAsync(ChatPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatPostParameter, ChatPostResponse>(parameter, cancellationToken);
        }
    }
}
