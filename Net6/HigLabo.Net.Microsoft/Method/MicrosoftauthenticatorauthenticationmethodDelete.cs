using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MicrosoftauthenticatorauthenticationmethodDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId,
            Users_IdOrUserPrincipalName_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId: return $"/me/authentication/microsoftAuthenticatorMethods/{MicrosoftAuthenticatorAuthenticationMethodId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId: return $"/users/{IdOrUserPrincipalName}/authentication/microsoftAuthenticatorMethods/{MicrosoftAuthenticatorAuthenticationMethodId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MicrosoftAuthenticatorAuthenticationMethodId { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class MicrosoftauthenticatorauthenticationmethodDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodDeleteResponse> MicrosoftauthenticatorauthenticationmethodDeleteAsync()
        {
            var p = new MicrosoftauthenticatorauthenticationmethodDeleteParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodDeleteParameter, MicrosoftauthenticatorauthenticationmethodDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodDeleteResponse> MicrosoftauthenticatorauthenticationmethodDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new MicrosoftauthenticatorauthenticationmethodDeleteParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodDeleteParameter, MicrosoftauthenticatorauthenticationmethodDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodDeleteResponse> MicrosoftauthenticatorauthenticationmethodDeleteAsync(MicrosoftauthenticatorauthenticationmethodDeleteParameter parameter)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodDeleteParameter, MicrosoftauthenticatorauthenticationmethodDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodDeleteResponse> MicrosoftauthenticatorauthenticationmethodDeleteAsync(MicrosoftauthenticatorauthenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodDeleteParameter, MicrosoftauthenticatorauthenticationmethodDeleteResponse>(parameter, cancellationToken);
        }
    }
}
