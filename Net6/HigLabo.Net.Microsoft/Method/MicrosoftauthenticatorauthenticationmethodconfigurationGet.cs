using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MicrosoftauthenticatorauthenticationmethodconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_MicrosoftAuthenticator,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_MicrosoftAuthenticator: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/microsoftAuthenticator";
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
    public partial class MicrosoftauthenticatorauthenticationmethodconfigurationGetResponse : RestApiResponse
    {
        public enum MicrosoftAuthenticatorAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public string? Id { get; set; }
        public MicrosoftAuthenticatorAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodconfigurationGetResponse> MicrosoftauthenticatorauthenticationmethodconfigurationGetAsync()
        {
            var p = new MicrosoftauthenticatorauthenticationmethodconfigurationGetParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodconfigurationGetParameter, MicrosoftauthenticatorauthenticationmethodconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodconfigurationGetResponse> MicrosoftauthenticatorauthenticationmethodconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new MicrosoftauthenticatorauthenticationmethodconfigurationGetParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodconfigurationGetParameter, MicrosoftauthenticatorauthenticationmethodconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodconfigurationGetResponse> MicrosoftauthenticatorauthenticationmethodconfigurationGetAsync(MicrosoftauthenticatorauthenticationmethodconfigurationGetParameter parameter)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodconfigurationGetParameter, MicrosoftauthenticatorauthenticationmethodconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodconfigurationGetResponse> MicrosoftauthenticatorauthenticationmethodconfigurationGetAsync(MicrosoftauthenticatorauthenticationmethodconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodconfigurationGetParameter, MicrosoftauthenticatorauthenticationmethodconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
