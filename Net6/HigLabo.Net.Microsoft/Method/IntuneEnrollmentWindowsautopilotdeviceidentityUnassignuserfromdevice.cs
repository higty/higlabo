using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_WindowsAutopilotDeviceIdentities_WindowsAutopilotDeviceIdentityId_UnassignUserFromDevice,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_WindowsAutopilotDeviceIdentities_WindowsAutopilotDeviceIdentityId_UnassignUserFromDevice: return $"/deviceManagement/windowsAutopilotDeviceIdentities/{WindowsAutopilotDeviceIdentityId}/unassignUserFromDevice";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string WindowsAutopilotDeviceIdentityId { get; set; }
    }
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-unassignuserfromdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceResponse> IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceAsync()
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceParameter, IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-unassignuserfromdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceResponse> IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceParameter, IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-unassignuserfromdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceResponse> IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceAsync(IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceParameter, IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-unassignuserfromdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceResponse> IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceAsync(IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceParameter, IntuneEnrollmentWindowsautopilotdeviceidentityUnassignuserfromdeviceResponse>(parameter, cancellationToken);
        }
    }
}
