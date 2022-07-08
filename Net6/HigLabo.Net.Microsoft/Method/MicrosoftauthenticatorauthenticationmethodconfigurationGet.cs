using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MicrosoftauthenticatorauthenticationmethodConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class MicrosoftauthenticatorauthenticationmethodConfigurationGetResponse : RestApiResponse
    {
        public enum MicrosoftAuthenticatorAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public string? Id { get; set; }
        public MicrosoftAuthenticatorAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public MicrosoftAuthenticatorAuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodConfigurationGetResponse> MicrosoftauthenticatorauthenticationmethodConfigurationGetAsync()
        {
            var p = new MicrosoftauthenticatorauthenticationmethodConfigurationGetParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationGetParameter, MicrosoftauthenticatorauthenticationmethodConfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodConfigurationGetResponse> MicrosoftauthenticatorauthenticationmethodConfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new MicrosoftauthenticatorauthenticationmethodConfigurationGetParameter();
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationGetParameter, MicrosoftauthenticatorauthenticationmethodConfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodConfigurationGetResponse> MicrosoftauthenticatorauthenticationmethodConfigurationGetAsync(MicrosoftauthenticatorauthenticationmethodConfigurationGetParameter parameter)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationGetParameter, MicrosoftauthenticatorauthenticationmethodConfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethodconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MicrosoftauthenticatorauthenticationmethodConfigurationGetResponse> MicrosoftauthenticatorauthenticationmethodConfigurationGetAsync(MicrosoftauthenticatorauthenticationmethodConfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodConfigurationGetParameter, MicrosoftauthenticatorauthenticationmethodConfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
