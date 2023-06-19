using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class VoiceauthenticationmethodConfigurationUpdateParameter : IRestApiParameter
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

        public enum VoiceauthenticationmethodConfigurationUpdateParameterAuthenticationMethodState
        {
            Enabled,
            Disabled,
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public ExcludeTarget[]? ExcludeTargets { get; set; }
        public bool? IsOfficePhoneAllowed { get; set; }
        public VoiceauthenticationmethodConfigurationUpdateParameterAuthenticationMethodState State { get; set; }
    }
    public partial class VoiceauthenticationmethodConfigurationUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<VoiceauthenticationmethodConfigurationUpdateResponse> VoiceauthenticationmethodConfigurationUpdateAsync()
        {
            var p = new VoiceauthenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<VoiceauthenticationmethodConfigurationUpdateParameter, VoiceauthenticationmethodConfigurationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<VoiceauthenticationmethodConfigurationUpdateResponse> VoiceauthenticationmethodConfigurationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new VoiceauthenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<VoiceauthenticationmethodConfigurationUpdateParameter, VoiceauthenticationmethodConfigurationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<VoiceauthenticationmethodConfigurationUpdateResponse> VoiceauthenticationmethodConfigurationUpdateAsync(VoiceauthenticationmethodConfigurationUpdateParameter parameter)
        {
            return await this.SendAsync<VoiceauthenticationmethodConfigurationUpdateParameter, VoiceauthenticationmethodConfigurationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<VoiceauthenticationmethodConfigurationUpdateResponse> VoiceauthenticationmethodConfigurationUpdateAsync(VoiceauthenticationmethodConfigurationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<VoiceauthenticationmethodConfigurationUpdateParameter, VoiceauthenticationmethodConfigurationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
