using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chat-list-members?view=graph-rest-1.0
/// </summary>
public partial class ChatListMembersParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Chats_ChatId_Members: return $"/chats/{ChatId}/members";
                case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId_Members: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}/members";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Chats_ChatId_Members,
        Users_UserIdOrUserPrincipalName_Chats_ChatId_Members,
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
public partial class ChatListMembersResponse : RestApiResponse
{
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string[]? Roles { get; set; }
    public DateTimeOffset? VisibleHistoryStartDateTime { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chat-list-members?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListMembersResponse> ChatListMembersAsync()
    {
        var p = new ChatListMembersParameter();
        return await this.SendAsync<ChatListMembersParameter, ChatListMembersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListMembersResponse> ChatListMembersAsync(CancellationToken cancellationToken)
    {
        var p = new ChatListMembersParameter();
        return await this.SendAsync<ChatListMembersParameter, ChatListMembersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListMembersResponse> ChatListMembersAsync(ChatListMembersParameter parameter)
    {
        return await this.SendAsync<ChatListMembersParameter, ChatListMembersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListMembersResponse> ChatListMembersAsync(ChatListMembersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ChatListMembersParameter, ChatListMembersResponse>(parameter, cancellationToken);
    }
}
