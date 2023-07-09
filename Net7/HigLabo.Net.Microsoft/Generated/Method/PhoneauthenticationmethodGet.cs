using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class PhoneauthenticationmethodGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PhoneMethodId { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_PhoneMethods_PhoneMethodId: return $"/me/authentication/phoneMethods/{PhoneMethodId}";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Authentication_PhoneMethods_PhoneMethodId: return $"/users/{UserIdOrUserPrincipalName}/authentication/phoneMethods/{PhoneMethodId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_PhoneMethods_PhoneMethodId,
            Users_UserIdOrUserPrincipalName_Authentication_PhoneMethods_PhoneMethodId,
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
    public partial class PhoneauthenticationmethodGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodGetResponse> PhoneauthenticationmethodGetAsync()
        {
            var p = new PhoneauthenticationmethodGetParameter();
            return await this.SendAsync<PhoneauthenticationmethodGetParameter, PhoneauthenticationmethodGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodGetResponse> PhoneauthenticationmethodGetAsync(CancellationToken cancellationToken)
        {
            var p = new PhoneauthenticationmethodGetParameter();
            return await this.SendAsync<PhoneauthenticationmethodGetParameter, PhoneauthenticationmethodGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodGetResponse> PhoneauthenticationmethodGetAsync(PhoneauthenticationmethodGetParameter parameter)
        {
            return await this.SendAsync<PhoneauthenticationmethodGetParameter, PhoneauthenticationmethodGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodGetResponse> PhoneauthenticationmethodGetAsync(PhoneauthenticationmethodGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PhoneauthenticationmethodGetParameter, PhoneauthenticationmethodGetResponse>(parameter, cancellationToken);
        }
    }
}
