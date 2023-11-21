using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftauthenticatorauthenticationmethodConfigurationUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class MicrosoftauthenticatorauthenticationmethodConfigurationUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MicrosoftauthenticatorauthenticationmethodConfigurationUpdateResponse> MicrosoftauthenticatorauthenticationmethodConfigurationUpdateAsync()
        {
            var p = new MicrosoftauthenticatorauthenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationUpdateParameter, MicrosoftauthenticatorauthenticationmethodConfigurationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MicrosoftauthenticatorauthenticationmethodConfigurationUpdateResponse> MicrosoftauthenticatorauthenticationmethodConfigurationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new MicrosoftauthenticatorauthenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationUpdateParameter, MicrosoftauthenticatorauthenticationmethodConfigurationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MicrosoftauthenticatorauthenticationmethodConfigurationUpdateResponse> MicrosoftauthenticatorauthenticationmethodConfigurationUpdateAsync(MicrosoftauthenticatorauthenticationmethodConfigurationUpdateParameter parameter)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationUpdateParameter, MicrosoftauthenticatorauthenticationmethodConfigurationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MicrosoftauthenticatorauthenticationmethodConfigurationUpdateResponse> MicrosoftauthenticatorauthenticationmethodConfigurationUpdateAsync(MicrosoftauthenticatorauthenticationmethodConfigurationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationUpdateParameter, MicrosoftauthenticatorauthenticationmethodConfigurationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
