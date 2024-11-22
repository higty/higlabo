using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-update?view=graph-rest-1.0
/// </summary>
public partial class TemporaryAccesspassauthenticationmethodConfigurationUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_TemporaryAccessPass: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/TemporaryAccessPass";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_TemporaryAccessPass,
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
}
public partial class TemporaryAccesspassauthenticationmethodConfigurationUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TemporaryAccesspassauthenticationmethodConfigurationUpdateResponse> TemporaryAccesspassauthenticationmethodConfigurationUpdateAsync()
    {
        var p = new TemporaryAccesspassauthenticationmethodConfigurationUpdateParameter();
        return await this.SendAsync<TemporaryAccesspassauthenticationmethodConfigurationUpdateParameter, TemporaryAccesspassauthenticationmethodConfigurationUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TemporaryAccesspassauthenticationmethodConfigurationUpdateResponse> TemporaryAccesspassauthenticationmethodConfigurationUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new TemporaryAccesspassauthenticationmethodConfigurationUpdateParameter();
        return await this.SendAsync<TemporaryAccesspassauthenticationmethodConfigurationUpdateParameter, TemporaryAccesspassauthenticationmethodConfigurationUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TemporaryAccesspassauthenticationmethodConfigurationUpdateResponse> TemporaryAccesspassauthenticationmethodConfigurationUpdateAsync(TemporaryAccesspassauthenticationmethodConfigurationUpdateParameter parameter)
    {
        return await this.SendAsync<TemporaryAccesspassauthenticationmethodConfigurationUpdateParameter, TemporaryAccesspassauthenticationmethodConfigurationUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TemporaryAccesspassauthenticationmethodConfigurationUpdateResponse> TemporaryAccesspassauthenticationmethodConfigurationUpdateAsync(TemporaryAccesspassauthenticationmethodConfigurationUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TemporaryAccesspassauthenticationmethodConfigurationUpdateParameter, TemporaryAccesspassauthenticationmethodConfigurationUpdateResponse>(parameter, cancellationToken);
    }
}
