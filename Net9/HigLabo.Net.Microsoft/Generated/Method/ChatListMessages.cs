using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
/// </summary>
public partial class ChatListMessagesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ChatId { get; set; }
        public string? UserIdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Chats_ChatId_Messages: return $"/me/chats/{ChatId}/messages";
                case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}/messages";
                case ApiPath.Chats_ChatId_Messages: return $"/chats/{ChatId}/messages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Chats_ChatId_Messages,
        Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages,
        Chats_ChatId_Messages,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class ChatListMessagesResponse : RestApiResponse<ChatMessage>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListMessagesResponse> ChatListMessagesAsync()
    {
        var p = new ChatListMessagesParameter();
        return await this.SendAsync<ChatListMessagesParameter, ChatListMessagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListMessagesResponse> ChatListMessagesAsync(CancellationToken cancellationToken)
    {
        var p = new ChatListMessagesParameter();
        return await this.SendAsync<ChatListMessagesParameter, ChatListMessagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListMessagesResponse> ChatListMessagesAsync(ChatListMessagesParameter parameter)
    {
        return await this.SendAsync<ChatListMessagesParameter, ChatListMessagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListMessagesResponse> ChatListMessagesAsync(ChatListMessagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ChatListMessagesParameter, ChatListMessagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ChatMessage> ChatListMessagesEnumerateAsync(ChatListMessagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ChatListMessagesParameter, ChatListMessagesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ChatMessage>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
