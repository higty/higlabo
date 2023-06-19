using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class Fido2authenticationmethodConfigurationUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Fido2: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/fido2";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Fido2,
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
    public partial class Fido2authenticationmethodConfigurationUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodConfigurationUpdateResponse> Fido2authenticationmethodConfigurationUpdateAsync()
        {
            var p = new Fido2authenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<Fido2authenticationmethodConfigurationUpdateParameter, Fido2authenticationmethodConfigurationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodConfigurationUpdateResponse> Fido2authenticationmethodConfigurationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new Fido2authenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<Fido2authenticationmethodConfigurationUpdateParameter, Fido2authenticationmethodConfigurationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodConfigurationUpdateResponse> Fido2authenticationmethodConfigurationUpdateAsync(Fido2authenticationmethodConfigurationUpdateParameter parameter)
        {
            return await this.SendAsync<Fido2authenticationmethodConfigurationUpdateParameter, Fido2authenticationmethodConfigurationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Fido2authenticationmethodConfigurationUpdateResponse> Fido2authenticationmethodConfigurationUpdateAsync(Fido2authenticationmethodConfigurationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Fido2authenticationmethodConfigurationUpdateParameter, Fido2authenticationmethodConfigurationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
