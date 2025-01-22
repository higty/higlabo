using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
/// </summary>
public partial class ChatListTabsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ChatId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Chats_ChatId_Tabs: return $"/chats/{ChatId}/tabs";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Chats_ChatId_Tabs,
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
public partial class ChatListTabsResponse : RestApiResponse<TeamsTab>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListTabsResponse> ChatListTabsAsync()
    {
        var p = new ChatListTabsParameter();
        return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListTabsResponse> ChatListTabsAsync(CancellationToken cancellationToken)
    {
        var p = new ChatListTabsParameter();
        return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListTabsResponse> ChatListTabsAsync(ChatListTabsParameter parameter)
    {
        return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChatListTabsResponse> ChatListTabsAsync(ChatListTabsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<TeamsTab> ChatListTabsEnumerateAsync(ChatListTabsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<TeamsTab>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
