using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-unhideforuser?view=graph-rest-1.0
    /// </summary>
    public partial class ChatUnhideforUserParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatsId_UnhideForUser: return $"/chats/{ChatsId}/unhideForUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatsId_UnhideForUser,
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
    public partial class ChatUnhideforUserResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-unhideforuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-unhideforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatUnhideforUserResponse> ChatUnhideforUserAsync()
        {
            var p = new ChatUnhideforUserParameter();
            return await this.SendAsync<ChatUnhideforUserParameter, ChatUnhideforUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-unhideforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatUnhideforUserResponse> ChatUnhideforUserAsync(CancellationToken cancellationToken)
        {
            var p = new ChatUnhideforUserParameter();
            return await this.SendAsync<ChatUnhideforUserParameter, ChatUnhideforUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-unhideforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatUnhideforUserResponse> ChatUnhideforUserAsync(ChatUnhideforUserParameter parameter)
        {
            return await this.SendAsync<ChatUnhideforUserParameter, ChatUnhideforUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-unhideforuser?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatUnhideforUserResponse> ChatUnhideforUserAsync(ChatUnhideforUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatUnhideforUserParameter, ChatUnhideforUserResponse>(parameter, cancellationToken);
        }
    }
}
