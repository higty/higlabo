using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-update?view=graph-rest-1.0
    /// </summary>
    public partial class PhoneauthenticationmethodUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PhoneMethodId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_PhoneMethods_PhoneMethodId: return $"/me/authentication/phoneMethods/{PhoneMethodId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_PhoneMethods_PhoneMethodId: return $"/users/{IdOrUserPrincipalName}/authentication/phoneMethods/{PhoneMethodId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum PhoneauthenticationmethodUpdateParameterstring
        {
            Mobile,
            AlternateMobile,
            Office,
        }
        public enum ApiPath
        {
            Me_Authentication_PhoneMethods_PhoneMethodId,
            Users_IdOrUserPrincipalName_Authentication_PhoneMethods_PhoneMethodId,
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
        public string? PhoneNumber { get; set; }
        public PhoneauthenticationmethodUpdateParameterstring PhoneType { get; set; }
    }
    public partial class PhoneauthenticationmethodUpdateResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodUpdateResponse> PhoneauthenticationmethodUpdateAsync()
        {
            var p = new PhoneauthenticationmethodUpdateParameter();
            return await this.SendAsync<PhoneauthenticationmethodUpdateParameter, PhoneauthenticationmethodUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodUpdateResponse> PhoneauthenticationmethodUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PhoneauthenticationmethodUpdateParameter();
            return await this.SendAsync<PhoneauthenticationmethodUpdateParameter, PhoneauthenticationmethodUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodUpdateResponse> PhoneauthenticationmethodUpdateAsync(PhoneauthenticationmethodUpdateParameter parameter)
        {
            return await this.SendAsync<PhoneauthenticationmethodUpdateParameter, PhoneauthenticationmethodUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodUpdateResponse> PhoneauthenticationmethodUpdateAsync(PhoneauthenticationmethodUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PhoneauthenticationmethodUpdateParameter, PhoneauthenticationmethodUpdateResponse>(parameter, cancellationToken);
        }
    }
}
