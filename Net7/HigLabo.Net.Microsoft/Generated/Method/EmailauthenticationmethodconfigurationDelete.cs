using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public partial class EmailauthenticationmethodConfigurationDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class EmailauthenticationmethodConfigurationDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmailauthenticationmethodConfigurationDeleteResponse> EmailauthenticationmethodConfigurationDeleteAsync()
        {
            var p = new EmailauthenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<EmailauthenticationmethodConfigurationDeleteParameter, EmailauthenticationmethodConfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmailauthenticationmethodConfigurationDeleteResponse> EmailauthenticationmethodConfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EmailauthenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<EmailauthenticationmethodConfigurationDeleteParameter, EmailauthenticationmethodConfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmailauthenticationmethodConfigurationDeleteResponse> EmailauthenticationmethodConfigurationDeleteAsync(EmailauthenticationmethodConfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<EmailauthenticationmethodConfigurationDeleteParameter, EmailauthenticationmethodConfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmailauthenticationmethodConfigurationDeleteResponse> EmailauthenticationmethodConfigurationDeleteAsync(EmailauthenticationmethodConfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmailauthenticationmethodConfigurationDeleteParameter, EmailauthenticationmethodConfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
