using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentconfigurationAssignParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId_Assign,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId_Assign: return $"/deviceManagement/deviceEnrollmentConfigurations/{DeviceEnrollmentConfigurationId}/assign";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public EnrollmentConfigurationAssignment[]? EnrollmentConfigurationAssignments { get; set; }
        public string DeviceEnrollmentConfigurationId { get; set; }
    }
    public partial class IntuneOnboardingDeviceenrollmentconfigurationAssignResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationAssignResponse> IntuneOnboardingDeviceenrollmentconfigurationAssignAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentconfigurationAssignParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationAssignParameter, IntuneOnboardingDeviceenrollmentconfigurationAssignResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationAssignResponse> IntuneOnboardingDeviceenrollmentconfigurationAssignAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentconfigurationAssignParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationAssignParameter, IntuneOnboardingDeviceenrollmentconfigurationAssignResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationAssignResponse> IntuneOnboardingDeviceenrollmentconfigurationAssignAsync(IntuneOnboardingDeviceenrollmentconfigurationAssignParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationAssignParameter, IntuneOnboardingDeviceenrollmentconfigurationAssignResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationAssignResponse> IntuneOnboardingDeviceenrollmentconfigurationAssignAsync(IntuneOnboardingDeviceenrollmentconfigurationAssignParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationAssignParameter, IntuneOnboardingDeviceenrollmentconfigurationAssignResponse>(parameter, cancellationToken);
        }
    }
}
