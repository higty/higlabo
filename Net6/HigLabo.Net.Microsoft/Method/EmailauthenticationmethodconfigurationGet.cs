using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EmailauthenticationmethodconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ttps__Graphmicrosoftcom_V10_Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Email,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Email: return $"/ttps://graph.microsoft.com/v1.0/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/email";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class EmailauthenticationmethodconfigurationGetResponse : RestApiResponse
    {
        public enum EmailAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }
        public enum EmailAuthenticationMethodConfigurationExternalEmailOtpState
        {
            Default,
            Enabled,
            Disabled,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public EmailAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public EmailAuthenticationMethodConfigurationExternalEmailOtpState AllowExternalIdToUseEmailOtp { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodconfigurationGetResponse> EmailauthenticationmethodconfigurationGetAsync()
        {
            var p = new EmailauthenticationmethodconfigurationGetParameter();
            return await this.SendAsync<EmailauthenticationmethodconfigurationGetParameter, EmailauthenticationmethodconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodconfigurationGetResponse> EmailauthenticationmethodconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new EmailauthenticationmethodconfigurationGetParameter();
            return await this.SendAsync<EmailauthenticationmethodconfigurationGetParameter, EmailauthenticationmethodconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodconfigurationGetResponse> EmailauthenticationmethodconfigurationGetAsync(EmailauthenticationmethodconfigurationGetParameter parameter)
        {
            return await this.SendAsync<EmailauthenticationmethodconfigurationGetParameter, EmailauthenticationmethodconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/emailauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EmailauthenticationmethodconfigurationGetResponse> EmailauthenticationmethodconfigurationGetAsync(EmailauthenticationmethodconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmailauthenticationmethodconfigurationGetParameter, EmailauthenticationmethodconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
