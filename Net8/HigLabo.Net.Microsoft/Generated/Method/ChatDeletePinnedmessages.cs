using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chat-delete-pinnedmessages?view=graph-rest-1.0
/// </summary>
public partial class ChatDeletePinnedmessagesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ChatId { get; set; }
        public string? PinnedChatMessageId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Chats_ChatId_PinnedMessages_PinnedChatMessageId: return $"/chats/{ChatId}/pinnedMessages/{PinnedChatMessageId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Chats_ChatId_PinnedMessages_PinnedChatMessageId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class ChatDeletePinnedmessagesResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chat-delete-pinnedmessages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-delete-pinnedmessages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatDeletePinnedmessagesResponse> ChatDeletePinnedmessagesAsync()
    {
        var p = new ChatDeletePinnedmessagesParameter();
        return await this.SendAsync<ChatDeletePinnedmessagesParameter, ChatDeletePinnedmessagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-delete-pinnedmessages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatDeletePinnedmessagesResponse> ChatDeletePinnedmessagesAsync(CancellationToken cancellationToken)
    {
        var p = new ChatDeletePinnedmessagesParameter();
        return await this.SendAsync<ChatDeletePinnedmessagesParameter, ChatDeletePinnedmessagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-delete-pinnedmessages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatDeletePinnedmessagesResponse> ChatDeletePinnedmessagesAsync(ChatDeletePinnedmessagesParameter parameter)
    {
        return await this.SendAsync<ChatDeletePinnedmessagesParameter, ChatDeletePinnedmessagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-delete-pinnedmessages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatDeletePinnedmessagesResponse> ChatDeletePinnedmessagesAsync(ChatDeletePinnedmessagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ChatDeletePinnedmessagesParameter, ChatDeletePinnedmessagesResponse>(parameter, cancellationToken);
    }
}
