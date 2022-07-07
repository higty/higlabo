using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_WindowsAutopilotDeviceIdentities_WindowsAutopilotDeviceIdentityId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_WindowsAutopilotDeviceIdentities_WindowsAutopilotDeviceIdentityId: return $"/deviceManagement/windowsAutopilotDeviceIdentities/{WindowsAutopilotDeviceIdentityId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string WindowsAutopilotDeviceIdentityId { get; set; }
    }
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityDeleteResponse> IntuneEnrollmentWindowsautopilotdeviceidentityDeleteAsync()
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityDeleteParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityDeleteParameter, IntuneEnrollmentWindowsautopilotdeviceidentityDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityDeleteResponse> IntuneEnrollmentWindowsautopilotdeviceidentityDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityDeleteParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityDeleteParameter, IntuneEnrollmentWindowsautopilotdeviceidentityDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityDeleteResponse> IntuneEnrollmentWindowsautopilotdeviceidentityDeleteAsync(IntuneEnrollmentWindowsautopilotdeviceidentityDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityDeleteParameter, IntuneEnrollmentWindowsautopilotdeviceidentityDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityDeleteResponse> IntuneEnrollmentWindowsautopilotdeviceidentityDeleteAsync(IntuneEnrollmentWindowsautopilotdeviceidentityDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityDeleteParameter, IntuneEnrollmentWindowsautopilotdeviceidentityDeleteResponse>(parameter, cancellationToken);
        }
    }
}
