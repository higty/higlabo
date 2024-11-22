using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-update?view=graph-rest-1.0
/// </summary>
public partial class EmailauthenticationmethodUpdateParameter : IRestApiParameter
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
                case ApiPath.Me_Authentication_EmailMethods_Id: return $"/me/authentication/emailMethods/{Id}";
                case ApiPath.Users_IdOrUserPrincipalName_Authentication_EmailMethods_Id: return $"/users/{IdOrUserPrincipalName}/authentication/emailMethods/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Authentication_EmailMethods_Id,
        Users_IdOrUserPrincipalName_Authentication_EmailMethods_Id,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public string? EmailAddress { get; set; }
}
public partial class EmailauthenticationmethodUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmailauthenticationmethodUpdateResponse> EmailauthenticationmethodUpdateAsync()
    {
        var p = new EmailauthenticationmethodUpdateParameter();
        return await this.SendAsync<EmailauthenticationmethodUpdateParameter, EmailauthenticationmethodUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmailauthenticationmethodUpdateResponse> EmailauthenticationmethodUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new EmailauthenticationmethodUpdateParameter();
        return await this.SendAsync<EmailauthenticationmethodUpdateParameter, EmailauthenticationmethodUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmailauthenticationmethodUpdateResponse> EmailauthenticationmethodUpdateAsync(EmailauthenticationmethodUpdateParameter parameter)
    {
        return await this.SendAsync<EmailauthenticationmethodUpdateParameter, EmailauthenticationmethodUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethod-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmailauthenticationmethodUpdateResponse> EmailauthenticationmethodUpdateAsync(EmailauthenticationmethodUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EmailauthenticationmethodUpdateParameter, EmailauthenticationmethodUpdateResponse>(parameter, cancellationToken);
    }
}
