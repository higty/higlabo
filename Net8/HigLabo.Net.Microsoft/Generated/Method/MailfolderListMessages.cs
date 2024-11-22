using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messages?view=graph-rest-1.0
/// </summary>
public partial class MailFolderListMessagesParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Me_MailFolders_Id_Messages: return $"/me/mailFolders/{Id}/messages";
                case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}/messages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_MailFolders_Id_Messages,
        Users_IdOrUserPrincipalName_MailFolders_Id_Messages,
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
public partial class MailFolderListMessagesResponse : RestApiResponse<Message>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderListMessagesResponse> MailFolderListMessagesAsync()
    {
        var p = new MailFolderListMessagesParameter();
        return await this.SendAsync<MailFolderListMessagesParameter, MailFolderListMessagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderListMessagesResponse> MailFolderListMessagesAsync(CancellationToken cancellationToken)
    {
        var p = new MailFolderListMessagesParameter();
        return await this.SendAsync<MailFolderListMessagesParameter, MailFolderListMessagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderListMessagesResponse> MailFolderListMessagesAsync(MailFolderListMessagesParameter parameter)
    {
        return await this.SendAsync<MailFolderListMessagesParameter, MailFolderListMessagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderListMessagesResponse> MailFolderListMessagesAsync(MailFolderListMessagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<MailFolderListMessagesParameter, MailFolderListMessagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Message> MailFolderListMessagesEnumerateAsync(MailFolderListMessagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<MailFolderListMessagesParameter, MailFolderListMessagesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Message>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
