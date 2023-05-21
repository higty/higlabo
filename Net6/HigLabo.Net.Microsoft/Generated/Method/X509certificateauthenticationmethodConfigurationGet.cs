using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public partial class X509certificateauthenticationmethodConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class X509certificateauthenticationmethodConfigurationGetResponse : RestApiResponse
    {
        public enum X509CertificateAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public X509CertificateAuthenticationModeConfiguration? AuthenticationModeConfiguration { get; set; }
        public X509CertificateUserBinding[]? CertificateUserBindings { get; set; }
        public ExcludeTarget[]? ExcludeTargets { get; set; }
        public string? Id { get; set; }
        public X509CertificateAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public AuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<X509certificateauthenticationmethodConfigurationGetResponse> X509certificateauthenticationmethodConfigurationGetAsync()
        {
            var p = new X509certificateauthenticationmethodConfigurationGetParameter();
            return await this.SendAsync<X509certificateauthenticationmethodConfigurationGetParameter, X509certificateauthenticationmethodConfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<X509certificateauthenticationmethodConfigurationGetResponse> X509certificateauthenticationmethodConfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new X509certificateauthenticationmethodConfigurationGetParameter();
            return await this.SendAsync<X509certificateauthenticationmethodConfigurationGetParameter, X509certificateauthenticationmethodConfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<X509certificateauthenticationmethodConfigurationGetResponse> X509certificateauthenticationmethodConfigurationGetAsync(X509certificateauthenticationmethodConfigurationGetParameter parameter)
        {
            return await this.SendAsync<X509certificateauthenticationmethodConfigurationGetParameter, X509certificateauthenticationmethodConfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/x509certificateauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<X509certificateauthenticationmethodConfigurationGetResponse> X509certificateauthenticationmethodConfigurationGetAsync(X509certificateauthenticationmethodConfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<X509certificateauthenticationmethodConfigurationGetParameter, X509certificateauthenticationmethodConfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
