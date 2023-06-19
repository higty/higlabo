using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public partial class SoftwareoathauthenticationmethodConfigurationDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_SoftwareOath: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/softwareOath";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_SoftwareOath,
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
    public partial class SoftwareoathauthenticationmethodConfigurationDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationDeleteResponse> SoftwareoathauthenticationmethodConfigurationDeleteAsync()
        {
            var p = new SoftwareoathauthenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationDeleteParameter, SoftwareoathauthenticationmethodConfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationDeleteResponse> SoftwareoathauthenticationmethodConfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SoftwareoathauthenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationDeleteParameter, SoftwareoathauthenticationmethodConfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationDeleteResponse> SoftwareoathauthenticationmethodConfigurationDeleteAsync(SoftwareoathauthenticationmethodConfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationDeleteParameter, SoftwareoathauthenticationmethodConfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationDeleteResponse> SoftwareoathauthenticationmethodConfigurationDeleteAsync(SoftwareoathauthenticationmethodConfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationDeleteParameter, SoftwareoathauthenticationmethodConfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
