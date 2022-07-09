using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MicrosoftauthenticatorauthenticationmethodConfigurationDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_MicrosoftAuthenticator: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/microsoftAuthenticator";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_MicrosoftAuthenticator,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class MicrosoftauthenticatorauthenticationmethodConfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodConfigurationDeleteResponse> MicrosoftauthenticatorauthenticationmethodConfigurationDeleteAsync()
        {
            var p = new MicrosoftauthenticatorauthenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationDeleteParameter, MicrosoftauthenticatorauthenticationmethodConfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodConfigurationDeleteResponse> MicrosoftauthenticatorauthenticationmethodConfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new MicrosoftauthenticatorauthenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationDeleteParameter, MicrosoftauthenticatorauthenticationmethodConfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodConfigurationDeleteResponse> MicrosoftauthenticatorauthenticationmethodConfigurationDeleteAsync(MicrosoftauthenticatorauthenticationmethodConfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationDeleteParameter, MicrosoftauthenticatorauthenticationmethodConfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodConfigurationDeleteResponse> MicrosoftauthenticatorauthenticationmethodConfigurationDeleteAsync(MicrosoftauthenticatorauthenticationmethodConfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationDeleteParameter, MicrosoftauthenticatorauthenticationmethodConfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
