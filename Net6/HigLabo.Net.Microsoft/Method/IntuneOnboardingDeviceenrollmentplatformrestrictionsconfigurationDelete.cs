using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteAsync(IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteAsync(IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
