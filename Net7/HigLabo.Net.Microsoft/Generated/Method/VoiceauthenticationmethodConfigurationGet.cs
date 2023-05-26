using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public partial class VoiceauthenticationmethodConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class VoiceauthenticationmethodConfigurationGetResponse : RestApiResponse
    {
        public enum VoiceAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public ExcludeTarget[]? ExcludeTargets { get; set; }
        public string? Id { get; set; }
        public bool? IsOfficePhoneAllowed { get; set; }
        public VoiceAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public VoiceAuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<VoiceauthenticationmethodConfigurationGetResponse> VoiceauthenticationmethodConfigurationGetAsync()
        {
            var p = new VoiceauthenticationmethodConfigurationGetParameter();
            return await this.SendAsync<VoiceauthenticationmethodConfigurationGetParameter, VoiceauthenticationmethodConfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<VoiceauthenticationmethodConfigurationGetResponse> VoiceauthenticationmethodConfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new VoiceauthenticationmethodConfigurationGetParameter();
            return await this.SendAsync<VoiceauthenticationmethodConfigurationGetParameter, VoiceauthenticationmethodConfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<VoiceauthenticationmethodConfigurationGetResponse> VoiceauthenticationmethodConfigurationGetAsync(VoiceauthenticationmethodConfigurationGetParameter parameter)
        {
            return await this.SendAsync<VoiceauthenticationmethodConfigurationGetParameter, VoiceauthenticationmethodConfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/voiceauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<VoiceauthenticationmethodConfigurationGetResponse> VoiceauthenticationmethodConfigurationGetAsync(VoiceauthenticationmethodConfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<VoiceauthenticationmethodConfigurationGetParameter, VoiceauthenticationmethodConfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
