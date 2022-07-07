using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentconfigurationSetpriorityParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId_SetPriority,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId_SetPriority: return $"/deviceManagement/deviceEnrollmentConfigurations/{DeviceEnrollmentConfigurationId}/setPriority";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Int32? Priority { get; set; }
        public string DeviceEnrollmentConfigurationId { get; set; }
    }
    public partial class IntuneOnboardingDeviceenrollmentconfigurationSetpriorityResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-setpriority?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationSetpriorityResponse> IntuneOnboardingDeviceenrollmentconfigurationSetpriorityAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentconfigurationSetpriorityParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationSetpriorityParameter, IntuneOnboardingDeviceenrollmentconfigurationSetpriorityResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-setpriority?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationSetpriorityResponse> IntuneOnboardingDeviceenrollmentconfigurationSetpriorityAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentconfigurationSetpriorityParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationSetpriorityParameter, IntuneOnboardingDeviceenrollmentconfigurationSetpriorityResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-setpriority?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationSetpriorityResponse> IntuneOnboardingDeviceenrollmentconfigurationSetpriorityAsync(IntuneOnboardingDeviceenrollmentconfigurationSetpriorityParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationSetpriorityParameter, IntuneOnboardingDeviceenrollmentconfigurationSetpriorityResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-setpriority?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationSetpriorityResponse> IntuneOnboardingDeviceenrollmentconfigurationSetpriorityAsync(IntuneOnboardingDeviceenrollmentconfigurationSetpriorityParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationSetpriorityParameter, IntuneOnboardingDeviceenrollmentconfigurationSetpriorityResponse>(parameter, cancellationToken);
        }
    }
}
