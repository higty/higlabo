using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-get-conversation?view=graph-rest-1.0
/// </summary>
public partial class GroupGetConversationParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? GroupsId { get; set; }
        public string? ConversationsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Groups_Id_Conversations_Id: return $"/groups/{GroupsId}/conversations/{ConversationsId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Groups_Id_Conversations_Id,
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
public partial class GroupGetConversationResponse : RestApiResponse
{
    public bool? HasAttachments { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastDeliveredDateTime { get; set; }
    public string? Preview { get; set; }
    public string? Topic { get; set; }
    public String[]? UniqueSenders { get; set; }
    public ConversationThread[]? Threads { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-get-conversation?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-get-conversation?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupGetConversationResponse> GroupGetConversationAsync()
    {
        var p = new GroupGetConversationParameter();
        return await this.SendAsync<GroupGetConversationParameter, GroupGetConversationResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-get-conversation?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupGetConversationResponse> GroupGetConversationAsync(CancellationToken cancellationToken)
    {
        var p = new GroupGetConversationParameter();
        return await this.SendAsync<GroupGetConversationParameter, GroupGetConversationResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-get-conversation?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupGetConversationResponse> GroupGetConversationAsync(GroupGetConversationParameter parameter)
    {
        return await this.SendAsync<GroupGetConversationParameter, GroupGetConversationResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-get-conversation?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupGetConversationResponse> GroupGetConversationAsync(GroupGetConversationParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupGetConversationParameter, GroupGetConversationResponse>(parameter, cancellationToken);
    }
}
