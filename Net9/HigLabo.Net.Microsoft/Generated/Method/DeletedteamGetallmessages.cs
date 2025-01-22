using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/deletedteam-getallmessages?view=graph-rest-1.0
/// </summary>
public partial class DeletedteamGetallmessagesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DeletedTeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teamwork_DeletedTeams_DeletedTeamId_Channels_GetAllMessages: return $"/teamwork/deletedTeams/{DeletedTeamId}/channels/getAllMessages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
        Attachments,
        Body,
        ChatId,
        ChannelIdentity,
        CreatedDateTime,
        DeletedDateTime,
        Etag,
        EventDetail,
        From,
        Id,
        Importance,
        LastModifiedDateTime,
        LastEditedDateTime,
        Locale,
        Mentions,
        MessageHistory,
        MessageType,
        PolicyViolation,
        Reactions,
        ReplyToId,
        Subject,
        Summary,
        WebUrl,
        HostedContents,
        Replies,
    }
    public enum ApiPath
    {
        Teamwork_DeletedTeams_DeletedTeamId_Channels_GetAllMessages,
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
public partial class DeletedteamGetallmessagesResponse : RestApiResponse
{
    public ChatMessage[]? Value { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/deletedteam-getallmessages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/deletedteam-getallmessages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeletedteamGetallmessagesResponse> DeletedteamGetallmessagesAsync()
    {
        var p = new DeletedteamGetallmessagesParameter();
        return await this.SendAsync<DeletedteamGetallmessagesParameter, DeletedteamGetallmessagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/deletedteam-getallmessages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeletedteamGetallmessagesResponse> DeletedteamGetallmessagesAsync(CancellationToken cancellationToken)
    {
        var p = new DeletedteamGetallmessagesParameter();
        return await this.SendAsync<DeletedteamGetallmessagesParameter, DeletedteamGetallmessagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/deletedteam-getallmessages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeletedteamGetallmessagesResponse> DeletedteamGetallmessagesAsync(DeletedteamGetallmessagesParameter parameter)
    {
        return await this.SendAsync<DeletedteamGetallmessagesParameter, DeletedteamGetallmessagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/deletedteam-getallmessages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeletedteamGetallmessagesResponse> DeletedteamGetallmessagesAsync(DeletedteamGetallmessagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DeletedteamGetallmessagesParameter, DeletedteamGetallmessagesResponse>(parameter, cancellationToken);
    }
}
