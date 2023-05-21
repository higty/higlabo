using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public partial class VoiceauthenticationmethodConfigurationDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Voice: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/voice";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Voice,
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
    public partial class VoiceauthenticationmethodConfigurationDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<VoiceauthenticationmethodConfigurationDeleteResponse> VoiceauthenticationmethodConfigurationDeleteAsync()
        {
            var p = new VoiceauthenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<VoiceauthenticationmethodConfigurationDeleteParameter, VoiceauthenticationmethodConfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<VoiceauthenticationmethodConfigurationDeleteResponse> VoiceauthenticationmethodConfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new VoiceauthenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<VoiceauthenticationmethodConfigurationDeleteParameter, VoiceauthenticationmethodConfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<VoiceauthenticationmethodConfigurationDeleteResponse> VoiceauthenticationmethodConfigurationDeleteAsync(VoiceauthenticationmethodConfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<VoiceauthenticationmethodConfigurationDeleteParameter, VoiceauthenticationmethodConfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<VoiceauthenticationmethodConfigurationDeleteResponse> VoiceauthenticationmethodConfigurationDeleteAsync(VoiceauthenticationmethodConfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<VoiceauthenticationmethodConfigurationDeleteParameter, VoiceauthenticationmethodConfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
