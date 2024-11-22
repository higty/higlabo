using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-get?view=graph-rest-1.0
/// </summary>
public partial class EmailauthenticationmethodConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Email: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/email";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Email,
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
public partial class EmailauthenticationmethodConfigurationGetResponse : RestApiResponse
{
    public enum EmailAuthenticationMethodConfigurationExternalEmailOtpState
    {
        Default,
        Enabled,
        Disabled,
        UnknownFutureValue,
    }
    public enum EmailAuthenticationMethodConfigurationAuthenticationMethodState
    {
        Enabled,
        Disabled,
    }

    public EmailAuthenticationMethodConfigurationExternalEmailOtpState AllowExternalIdToUseEmailOtp { get; set; }
    public ExcludeTarget[]? ExcludeTargets { get; set; }
    public string? Id { get; set; }
    public EmailAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
    public AuthenticationMethodTarget[]? IncludeTargets { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmailauthenticationmethodConfigurationGetResponse> EmailauthenticationmethodConfigurationGetAsync()
    {
        var p = new EmailauthenticationmethodConfigurationGetParameter();
        return await this.SendAsync<EmailauthenticationmethodConfigurationGetParameter, EmailauthenticationmethodConfigurationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmailauthenticationmethodConfigurationGetResponse> EmailauthenticationmethodConfigurationGetAsync(CancellationToken cancellationToken)
    {
        var p = new EmailauthenticationmethodConfigurationGetParameter();
        return await this.SendAsync<EmailauthenticationmethodConfigurationGetParameter, EmailauthenticationmethodConfigurationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmailauthenticationmethodConfigurationGetResponse> EmailauthenticationmethodConfigurationGetAsync(EmailauthenticationmethodConfigurationGetParameter parameter)
    {
        return await this.SendAsync<EmailauthenticationmethodConfigurationGetParameter, EmailauthenticationmethodConfigurationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EmailauthenticationmethodConfigurationGetResponse> EmailauthenticationmethodConfigurationGetAsync(EmailauthenticationmethodConfigurationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EmailauthenticationmethodConfigurationGetParameter, EmailauthenticationmethodConfigurationGetResponse>(parameter, cancellationToken);
    }
}
