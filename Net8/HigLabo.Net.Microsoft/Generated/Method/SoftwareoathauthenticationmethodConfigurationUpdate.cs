using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class SoftwareoathauthenticationmethodConfigurationUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class SoftwareoathauthenticationmethodConfigurationUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationUpdateResponse> SoftwareoathauthenticationmethodConfigurationUpdateAsync()
        {
            var p = new SoftwareoathauthenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationUpdateParameter, SoftwareoathauthenticationmethodConfigurationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationUpdateResponse> SoftwareoathauthenticationmethodConfigurationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SoftwareoathauthenticationmethodConfigurationUpdateParameter();
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationUpdateParameter, SoftwareoathauthenticationmethodConfigurationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationUpdateResponse> SoftwareoathauthenticationmethodConfigurationUpdateAsync(SoftwareoathauthenticationmethodConfigurationUpdateParameter parameter)
        {
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationUpdateParameter, SoftwareoathauthenticationmethodConfigurationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethodconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodConfigurationUpdateResponse> SoftwareoathauthenticationmethodConfigurationUpdateAsync(SoftwareoathauthenticationmethodConfigurationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SoftwareoathauthenticationmethodConfigurationUpdateParameter, SoftwareoathauthenticationmethodConfigurationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
