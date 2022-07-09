using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EmailauthenticationmethodConfigurationUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class EmailauthenticationmethodConfigurationUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodConfigurationUpdateResponse> EmailauthenticationmethodConfigurationUpdateAsync()
        {
            var p = new EmailauthenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<EmailauthenticationmethodConfigurationUpdateParameter, EmailauthenticationmethodConfigurationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodConfigurationUpdateResponse> EmailauthenticationmethodConfigurationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new EmailauthenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<EmailauthenticationmethodConfigurationUpdateParameter, EmailauthenticationmethodConfigurationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodConfigurationUpdateResponse> EmailauthenticationmethodConfigurationUpdateAsync(EmailauthenticationmethodConfigurationUpdateParameter parameter)
        {
            return await this.SendAsync<EmailauthenticationmethodConfigurationUpdateParameter, EmailauthenticationmethodConfigurationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodConfigurationUpdateResponse> EmailauthenticationmethodConfigurationUpdateAsync(EmailauthenticationmethodConfigurationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmailauthenticationmethodConfigurationUpdateParameter, EmailauthenticationmethodConfigurationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
