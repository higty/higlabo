using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-hideforuser?view=graph-rest-1.0
    /// </summary>
    public partial class ChatHideforUserParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatsId_HideForUser: return $"/chats/{ChatsId}/hideForUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatsId_HideForUser,
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
    public partial class ChatHideforUserResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-hideforuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-hideforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatHideforUserResponse> ChatHideforUserAsync()
        {
            var p = new ChatHideforUserParameter();
            return await this.SendAsync<ChatHideforUserParameter, ChatHideforUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-hideforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatHideforUserResponse> ChatHideforUserAsync(CancellationToken cancellationToken)
        {
            var p = new ChatHideforUserParameter();
            return await this.SendAsync<ChatHideforUserParameter, ChatHideforUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-hideforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatHideforUserResponse> ChatHideforUserAsync(ChatHideforUserParameter parameter)
        {
            return await this.SendAsync<ChatHideforUserParameter, ChatHideforUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-hideforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatHideforUserResponse> ChatHideforUserAsync(ChatHideforUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatHideforUserParameter, ChatHideforUserResponse>(parameter, cancellationToken);
        }
    }
}
