using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-messagerules?view=graph-rest-1.0
/// </summary>
public partial class MailFolderPostMessagerulesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_MailFolders_Inbox_MessageRules: return $"/me/mailFolders/inbox/messageRules";
                case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Inbox_MessageRules: return $"/users/{IdOrUserPrincipalName}/mailFolders/inbox/messageRules";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_MailFolders_Inbox_MessageRules,
        Users_IdOrUserPrincipalName_MailFolders_Inbox_MessageRules,
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
    public MessageRuleActions? Actions { get; set; }
    public MessageRulePredicates? Conditions { get; set; }
    public string? DisplayName { get; set; }
    public MessageRulePredicates? Exceptions { get; set; }
    public bool? IsEnabled { get; set; }
    public Int32? Sequence { get; set; }
}
public partial class MailFolderPostMessagerulesResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-messagerules?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-messagerules?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderPostMessagerulesResponse> MailFolderPostMessagerulesAsync()
    {
        var p = new MailFolderPostMessagerulesParameter();
        return await this.SendAsync<MailFolderPostMessagerulesParameter, MailFolderPostMessagerulesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-messagerules?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderPostMessagerulesResponse> MailFolderPostMessagerulesAsync(CancellationToken cancellationToken)
    {
        var p = new MailFolderPostMessagerulesParameter();
        return await this.SendAsync<MailFolderPostMessagerulesParameter, MailFolderPostMessagerulesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-messagerules?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderPostMessagerulesResponse> MailFolderPostMessagerulesAsync(MailFolderPostMessagerulesParameter parameter)
    {
        return await this.SendAsync<MailFolderPostMessagerulesParameter, MailFolderPostMessagerulesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-messagerules?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MailFolderPostMessagerulesResponse> MailFolderPostMessagerulesAsync(MailFolderPostMessagerulesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<MailFolderPostMessagerulesParameter, MailFolderPostMessagerulesResponse>(parameter, cancellationToken);
    }
}
