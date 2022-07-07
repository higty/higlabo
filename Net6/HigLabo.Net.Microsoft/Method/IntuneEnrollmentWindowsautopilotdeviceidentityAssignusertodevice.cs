using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_WindowsAutopilotDeviceIdentities_WindowsAutopilotDeviceIdentityId_AssignUserToDevice,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_WindowsAutopilotDeviceIdentities_WindowsAutopilotDeviceIdentityId_AssignUserToDevice: return $"/deviceManagement/windowsAutopilotDeviceIdentities/{WindowsAutopilotDeviceIdentityId}/assignUserToDevice";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? UserPrincipalName { get; set; }
        public string? AddressableUserName { get; set; }
        public string WindowsAutopilotDeviceIdentityId { get; set; }
    }
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-assignusertodevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceResponse> IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceAsync()
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceParameter, IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-assignusertodevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceResponse> IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceParameter, IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-assignusertodevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceResponse> IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceAsync(IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceParameter, IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-assignusertodevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceResponse> IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceAsync(IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceParameter, IntuneEnrollmentWindowsautopilotdeviceidentityAssignusertodeviceResponse>(parameter, cancellationToken);
        }
    }
}
