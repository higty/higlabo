using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/message-send?view=graph-rest-1.0
/// </summary>
public partial class MessageSendParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Messages_Id_Send: return $"/me/messages/{Id}/send";
                case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Send: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/send";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Messages_Id_Send,
        Users_IdOrUserPrincipalName_Messages_Id_Send,
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
}
public partial class MessageSendResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/message-send?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-send?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageSendResponse> MessageSendAsync()
    {
        var p = new MessageSendParameter();
        return await this.SendAsync<MessageSendParameter, MessageSendResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-send?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageSendResponse> MessageSendAsync(CancellationToken cancellationToken)
    {
        var p = new MessageSendParameter();
        return await this.SendAsync<MessageSendParameter, MessageSendResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-send?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageSendResponse> MessageSendAsync(MessageSendParameter parameter)
    {
        return await this.SendAsync<MessageSendParameter, MessageSendResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-send?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageSendResponse> MessageSendAsync(MessageSendParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<MessageSendParameter, MessageSendResponse>(parameter, cancellationToken);
    }
}
