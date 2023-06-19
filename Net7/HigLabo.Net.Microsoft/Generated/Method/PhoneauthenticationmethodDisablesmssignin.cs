using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-disablesmssignin?view=graph-rest-1.0
    /// </summary>
    public partial class PhoneauthenticationmethodDisablesmssigninParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? MobilePhoneMethodId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_PhoneMethods_MobilePhoneMethodId_DisableSmsSignIn: return $"/me/authentication/phoneMethods/{MobilePhoneMethodId}/disableSmsSignIn";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_PhoneMethods_MobilePhoneMethodId_DisableSmsSignIn: return $"/users/{IdOrUserPrincipalName}/authentication/phoneMethods/{MobilePhoneMethodId}/disableSmsSignIn";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Authentication_PhoneMethods_MobilePhoneMethodId_DisableSmsSignIn,
            Users_IdOrUserPrincipalName_Authentication_PhoneMethods_MobilePhoneMethodId_DisableSmsSignIn,
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
    }
    public partial class PhoneauthenticationmethodDisablesmssigninResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-disablesmssignin?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-disablesmssignin?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodDisablesmssigninResponse> PhoneauthenticationmethodDisablesmssigninAsync()
        {
            var p = new PhoneauthenticationmethodDisablesmssigninParameter();
            return await this.SendAsync<PhoneauthenticationmethodDisablesmssigninParameter, PhoneauthenticationmethodDisablesmssigninResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-disablesmssignin?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodDisablesmssigninResponse> PhoneauthenticationmethodDisablesmssigninAsync(CancellationToken cancellationToken)
        {
            var p = new PhoneauthenticationmethodDisablesmssigninParameter();
            return await this.SendAsync<PhoneauthenticationmethodDisablesmssigninParameter, PhoneauthenticationmethodDisablesmssigninResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-disablesmssignin?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodDisablesmssigninResponse> PhoneauthenticationmethodDisablesmssigninAsync(PhoneauthenticationmethodDisablesmssigninParameter parameter)
        {
            return await this.SendAsync<PhoneauthenticationmethodDisablesmssigninParameter, PhoneauthenticationmethodDisablesmssigninResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-disablesmssignin?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PhoneauthenticationmethodDisablesmssigninResponse> PhoneauthenticationmethodDisablesmssigninAsync(PhoneauthenticationmethodDisablesmssigninParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PhoneauthenticationmethodDisablesmssigninParameter, PhoneauthenticationmethodDisablesmssigninResponse>(parameter, cancellationToken);
        }
    }
}
