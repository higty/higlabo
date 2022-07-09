using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatmessageUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatThreadId { get; set; }
            public string? MessageId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_: return $"/teams/";
                    case ApiPath.Chats_ChatThreadId_Messages_MessageId: return $"/chats/{ChatThreadId}/messages/{MessageId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_,
            Chats_ChatThreadId_Messages_MessageId,
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
    }
    public partial class ChatmessageUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageUpdateResponse> ChatmessageUpdateAsync()
        {
            var p = new ChatmessageUpdateParameter();
            return await this.SendAsync<ChatmessageUpdateParameter, ChatmessageUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageUpdateResponse> ChatmessageUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessageUpdateParameter();
            return await this.SendAsync<ChatmessageUpdateParameter, ChatmessageUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageUpdateResponse> ChatmessageUpdateAsync(ChatmessageUpdateParameter parameter)
        {
            return await this.SendAsync<ChatmessageUpdateParameter, ChatmessageUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageUpdateResponse> ChatmessageUpdateAsync(ChatmessageUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessageUpdateParameter, ChatmessageUpdateResponse>(parameter, cancellationToken);
        }
    }
}
