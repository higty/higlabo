using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId: return $"/deviceManagement/deviceEnrollmentConfigurations/{DeviceEnrollmentConfigurationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceEnrollmentConfigurationId { get; set; }
    }
    public partial class IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteAsync(IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteAsync(IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentwindowshelloforbusinessconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
