using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteAsync(IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteAsync(IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
