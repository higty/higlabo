using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-delete?view=graph-rest-1.0
/// </summary>
public partial class X509certificateauthenticationmethodConfigurationDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_X509Certificate: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/x509Certificate";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_X509Certificate,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class X509certificateauthenticationmethodConfigurationDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<X509certificateauthenticationmethodConfigurationDeleteResponse> X509certificateauthenticationmethodConfigurationDeleteAsync()
    {
        var p = new X509certificateauthenticationmethodConfigurationDeleteParameter();
        return await this.SendAsync<X509certificateauthenticationmethodConfigurationDeleteParameter, X509certificateauthenticationmethodConfigurationDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<X509certificateauthenticationmethodConfigurationDeleteResponse> X509certificateauthenticationmethodConfigurationDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new X509certificateauthenticationmethodConfigurationDeleteParameter();
        return await this.SendAsync<X509certificateauthenticationmethodConfigurationDeleteParameter, X509certificateauthenticationmethodConfigurationDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<X509certificateauthenticationmethodConfigurationDeleteResponse> X509certificateauthenticationmethodConfigurationDeleteAsync(X509certificateauthenticationmethodConfigurationDeleteParameter parameter)
    {
        return await this.SendAsync<X509certificateauthenticationmethodConfigurationDeleteParameter, X509certificateauthenticationmethodConfigurationDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<X509certificateauthenticationmethodConfigurationDeleteResponse> X509certificateauthenticationmethodConfigurationDeleteAsync(X509certificateauthenticationmethodConfigurationDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<X509certificateauthenticationmethodConfigurationDeleteParameter, X509certificateauthenticationmethodConfigurationDeleteResponse>(parameter, cancellationToken);
    }
}
