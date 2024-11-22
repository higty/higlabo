using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-get?view=graph-rest-1.0
/// </summary>
public partial class SmsauthenticationmethodConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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

    public enum Field
    {
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
public partial class SmsauthenticationmethodConfigurationGetResponse : RestApiResponse
{
    public enum SmsAuthenticationMethodConfigurationAuthenticationMethodState
    {
        Enabled,
        Disabled,
    }

    public ExcludeTarget[]? ExcludeTargets { get; set; }
    public string? Id { get; set; }
    public SmsAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
    public SmsAuthenticationMethodTarget[]? IncludeTargets { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SmsauthenticationmethodConfigurationGetResponse> SmsauthenticationmethodConfigurationGetAsync()
    {
        var p = new SmsauthenticationmethodConfigurationGetParameter();
        return await this.SendAsync<SmsauthenticationmethodConfigurationGetParameter, SmsauthenticationmethodConfigurationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SmsauthenticationmethodConfigurationGetResponse> SmsauthenticationmethodConfigurationGetAsync(CancellationToken cancellationToken)
    {
        var p = new SmsauthenticationmethodConfigurationGetParameter();
        return await this.SendAsync<SmsauthenticationmethodConfigurationGetParameter, SmsauthenticationmethodConfigurationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SmsauthenticationmethodConfigurationGetResponse> SmsauthenticationmethodConfigurationGetAsync(SmsauthenticationmethodConfigurationGetParameter parameter)
    {
        return await this.SendAsync<SmsauthenticationmethodConfigurationGetParameter, SmsauthenticationmethodConfigurationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SmsauthenticationmethodConfigurationGetResponse> SmsauthenticationmethodConfigurationGetAsync(SmsauthenticationmethodConfigurationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SmsauthenticationmethodConfigurationGetParameter, SmsauthenticationmethodConfigurationGetResponse>(parameter, cancellationToken);
    }
}
