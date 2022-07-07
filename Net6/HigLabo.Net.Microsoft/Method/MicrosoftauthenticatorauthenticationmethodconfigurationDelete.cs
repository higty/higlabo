using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MicrosoftauthenticatorauthenticationmethodconfigurationDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class MicrosoftauthenticatorauthenticationmethodconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodconfigurationDeleteResponse> MicrosoftauthenticatorauthenticationmethodconfigurationDeleteAsync()
        {
            var p = new MicrosoftauthenticatorauthenticationmethodconfigurationDeleteParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodconfigurationDeleteParameter, MicrosoftauthenticatorauthenticationmethodconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodconfigurationDeleteResponse> MicrosoftauthenticatorauthenticationmethodconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new MicrosoftauthenticatorauthenticationmethodconfigurationDeleteParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodconfigurationDeleteParameter, MicrosoftauthenticatorauthenticationmethodconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodconfigurationDeleteResponse> MicrosoftauthenticatorauthenticationmethodconfigurationDeleteAsync(MicrosoftauthenticatorauthenticationmethodconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodconfigurationDeleteParameter, MicrosoftauthenticatorauthenticationmethodconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodconfigurationDeleteResponse> MicrosoftauthenticatorauthenticationmethodconfigurationDeleteAsync(MicrosoftauthenticatorauthenticationmethodconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodconfigurationDeleteParameter, MicrosoftauthenticatorauthenticationmethodconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
