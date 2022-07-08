using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class Fido2authenticationmethodConfigurationDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class Fido2authenticationmethodConfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodConfigurationDeleteResponse> Fido2authenticationmethodConfigurationDeleteAsync()
        {
            var p = new Fido2authenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<Fido2authenticationmethodConfigurationDeleteParameter, Fido2authenticationmethodConfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodConfigurationDeleteResponse> Fido2authenticationmethodConfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new Fido2authenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<Fido2authenticationmethodConfigurationDeleteParameter, Fido2authenticationmethodConfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodConfigurationDeleteResponse> Fido2authenticationmethodConfigurationDeleteAsync(Fido2authenticationmethodConfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<Fido2authenticationmethodConfigurationDeleteParameter, Fido2authenticationmethodConfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/fido2authenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Fido2authenticationmethodConfigurationDeleteResponse> Fido2authenticationmethodConfigurationDeleteAsync(Fido2authenticationmethodConfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<Fido2authenticationmethodConfigurationDeleteParameter, Fido2authenticationmethodConfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
