using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class X509certificateauthenticationmethodConfigurationUpdateParameter : IRestApiParameter
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

        public enum X509certificateauthenticationmethodConfigurationUpdateParameterAuthenticationMethodState
        {
            Enabled,
            Disabled,
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public X509certificateauthenticationmethodConfigurationUpdateParameterAuthenticationMethodState State { get; set; }
        public X509CertificateUserBinding[]? CertificateUserBindings { get; set; }
        public X509CertificateAuthenticationModeConfiguration? AuthenticationModeConfiguration { get; set; }
    }
    public partial class X509certificateauthenticationmethodConfigurationUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async Task<X509certificateauthenticationmethodConfigurationUpdateResponse> X509certificateauthenticationmethodConfigurationUpdateAsync()
        {
            var p = new X509certificateauthenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<X509certificateauthenticationmethodConfigurationUpdateParameter, X509certificateauthenticationmethodConfigurationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async Task<X509certificateauthenticationmethodConfigurationUpdateResponse> X509certificateauthenticationmethodConfigurationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new X509certificateauthenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<X509certificateauthenticationmethodConfigurationUpdateParameter, X509certificateauthenticationmethodConfigurationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async Task<X509certificateauthenticationmethodConfigurationUpdateResponse> X509certificateauthenticationmethodConfigurationUpdateAsync(X509certificateauthenticationmethodConfigurationUpdateParameter parameter)
        {
            return await this.SendAsync<X509certificateauthenticationmethodConfigurationUpdateParameter, X509certificateauthenticationmethodConfigurationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async Task<X509certificateauthenticationmethodConfigurationUpdateResponse> X509certificateauthenticationmethodConfigurationUpdateAsync(X509certificateauthenticationmethodConfigurationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<X509certificateauthenticationmethodConfigurationUpdateParameter, X509certificateauthenticationmethodConfigurationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
