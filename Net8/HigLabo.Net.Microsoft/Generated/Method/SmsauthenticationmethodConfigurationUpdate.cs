using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-update?view=graph-rest-1.0
/// </summary>
public partial class SmsauthenticationmethodConfigurationUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Sms: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/sms";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum SmsauthenticationmethodConfigurationUpdateParameterAuthenticationMethodState
    {
        Enabled,
        Disabled,
    }
    public enum ApiPath
    {
        Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Sms,
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
    public ExcludeTarget[]? ExcludeTargets { get; set; }
    public SmsauthenticationmethodConfigurationUpdateParameterAuthenticationMethodState State { get; set; }
}
public partial class SmsauthenticationmethodConfigurationUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SmsauthenticationmethodConfigurationUpdateResponse> SmsauthenticationmethodConfigurationUpdateAsync()
    {
        var p = new SmsauthenticationmethodConfigurationUpdateParameter();
        return await this.SendAsync<SmsauthenticationmethodConfigurationUpdateParameter, SmsauthenticationmethodConfigurationUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SmsauthenticationmethodConfigurationUpdateResponse> SmsauthenticationmethodConfigurationUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new SmsauthenticationmethodConfigurationUpdateParameter();
        return await this.SendAsync<SmsauthenticationmethodConfigurationUpdateParameter, SmsauthenticationmethodConfigurationUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SmsauthenticationmethodConfigurationUpdateResponse> SmsauthenticationmethodConfigurationUpdateAsync(SmsauthenticationmethodConfigurationUpdateParameter parameter)
    {
        return await this.SendAsync<SmsauthenticationmethodConfigurationUpdateParameter, SmsauthenticationmethodConfigurationUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SmsauthenticationmethodConfigurationUpdateResponse> SmsauthenticationmethodConfigurationUpdateAsync(SmsauthenticationmethodConfigurationUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SmsauthenticationmethodConfigurationUpdateParameter, SmsauthenticationmethodConfigurationUpdateResponse>(parameter, cancellationToken);
    }
}
