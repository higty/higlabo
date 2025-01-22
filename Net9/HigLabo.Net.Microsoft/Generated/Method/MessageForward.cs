using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/message-forward?view=graph-rest-1.0
/// </summary>
public partial class MessageForwardParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? MailFoldersId { get; set; }
        public string? MessagesId { get; set; }
        public string? UsersIdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Messages_Id_Forward: return $"/me/messages/{Id}/forward";
                case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Forward: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/forward";
                case ApiPath.Me_MailFolders_Id_Messages_Id_Forward: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/forward";
                case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Forward: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/forward";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Messages_Id_Forward,
        Users_IdOrUserPrincipalName_Messages_Id_Forward,
        Me_MailFolders_Id_Messages_Id_Forward,
        Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Forward,
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
    public string? Comment { get; set; }
    public Recipient[]? ToRecipients { get; set; }
}
public partial class MessageForwardResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/message-forward?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-forward?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageForwardResponse> MessageForwardAsync()
    {
        var p = new MessageForwardParameter();
        return await this.SendAsync<MessageForwardParameter, MessageForwardResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-forward?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageForwardResponse> MessageForwardAsync(CancellationToken cancellationToken)
    {
        var p = new MessageForwardParameter();
        return await this.SendAsync<MessageForwardParameter, MessageForwardResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-forward?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageForwardResponse> MessageForwardAsync(MessageForwardParameter parameter)
    {
        return await this.SendAsync<MessageForwardParameter, MessageForwardResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-forward?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageForwardResponse> MessageForwardAsync(MessageForwardParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<MessageForwardParameter, MessageForwardResponse>(parameter, cancellationToken);
    }
}
