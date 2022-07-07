using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EmailauthenticationmethodconfigurationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Email,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Email: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/email";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class EmailauthenticationmethodconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodconfigurationDeleteResponse> EmailauthenticationmethodconfigurationDeleteAsync()
        {
            var p = new EmailauthenticationmethodconfigurationDeleteParameter();
            return await this.SendAsync<EmailauthenticationmethodconfigurationDeleteParameter, EmailauthenticationmethodconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodconfigurationDeleteResponse> EmailauthenticationmethodconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EmailauthenticationmethodconfigurationDeleteParameter();
            return await this.SendAsync<EmailauthenticationmethodconfigurationDeleteParameter, EmailauthenticationmethodconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodconfigurationDeleteResponse> EmailauthenticationmethodconfigurationDeleteAsync(EmailauthenticationmethodconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<EmailauthenticationmethodconfigurationDeleteParameter, EmailauthenticationmethodconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodconfigurationDeleteResponse> EmailauthenticationmethodconfigurationDeleteAsync(EmailauthenticationmethodconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmailauthenticationmethodconfigurationDeleteParameter, EmailauthenticationmethodconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
