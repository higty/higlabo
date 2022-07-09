using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatPatchParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId: return $"/chats/{ChatId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Topic { get; set; }
    }
    public partial class ChatPatchResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-patch?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPatchResponse> ChatPatchAsync()
        {
            var p = new ChatPatchParameter();
            return await this.SendAsync<ChatPatchParameter, ChatPatchResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-patch?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPatchResponse> ChatPatchAsync(CancellationToken cancellationToken)
        {
            var p = new ChatPatchParameter();
            return await this.SendAsync<ChatPatchParameter, ChatPatchResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-patch?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPatchResponse> ChatPatchAsync(ChatPatchParameter parameter)
        {
            return await this.SendAsync<ChatPatchParameter, ChatPatchResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-patch?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPatchResponse> ChatPatchAsync(ChatPatchParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatPatchParameter, ChatPatchResponse>(parameter, cancellationToken);
        }
    }
}
