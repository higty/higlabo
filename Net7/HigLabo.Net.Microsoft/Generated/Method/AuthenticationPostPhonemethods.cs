using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-post-phonemethods?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationPostPhonemethodsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_PhoneMethods: return $"/me/authentication/phoneMethods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_PhoneMethods: return $"/users/{IdOrUserPrincipalName}/authentication/phoneMethods";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum PhoneAuthenticationMethodAuthenticationPhoneType
        {
            Mobile,
            AlternateMobile,
            Office,
        }
        public enum PhoneAuthenticationMethodAuthenticationMethodSignInState
        {
            NotSupported,
            NotAllowedByPolicy,
            NotEnabled,
            PhoneNumberNotUnique,
            Ready,
            NotConfigured,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            Me_Authentication_PhoneMethods,
            Users_IdOrUserPrincipalName_Authentication_PhoneMethods,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? PhoneNumber { get; set; }
        public string? PhoneType { get; set; }
        public string? Id { get; set; }
        public PhoneAuthenticationMethodAuthenticationMethodSignInState SmsSignInState { get; set; }
    }
    public partial class AuthenticationPostPhonemethodsResponse : RestApiResponse
    {
        public enum PhoneAuthenticationMethodAuthenticationPhoneType
        {
            Mobile,
            AlternateMobile,
            Office,
        }
        public enum PhoneAuthenticationMethodAuthenticationMethodSignInState
        {
            NotSupported,
            NotAllowedByPolicy,
            NotEnabled,
            PhoneNumberNotUnique,
            Ready,
            NotConfigured,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public string? PhoneNumber { get; set; }
        public PhoneAuthenticationMethodAuthenticationPhoneType PhoneType { get; set; }
        public PhoneAuthenticationMethodAuthenticationMethodSignInState SmsSignInState { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-post-phonemethods?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-post-phonemethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationPostPhonemethodsResponse> AuthenticationPostPhonemethodsAsync()
        {
            var p = new AuthenticationPostPhonemethodsParameter();
            return await this.SendAsync<AuthenticationPostPhonemethodsParameter, AuthenticationPostPhonemethodsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-post-phonemethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationPostPhonemethodsResponse> AuthenticationPostPhonemethodsAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationPostPhonemethodsParameter();
            return await this.SendAsync<AuthenticationPostPhonemethodsParameter, AuthenticationPostPhonemethodsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-post-phonemethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationPostPhonemethodsResponse> AuthenticationPostPhonemethodsAsync(AuthenticationPostPhonemethodsParameter parameter)
        {
            return await this.SendAsync<AuthenticationPostPhonemethodsParameter, AuthenticationPostPhonemethodsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-post-phonemethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationPostPhonemethodsResponse> AuthenticationPostPhonemethodsAsync(AuthenticationPostPhonemethodsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationPostPhonemethodsParameter, AuthenticationPostPhonemethodsResponse>(parameter, cancellationToken);
        }
    }
}
