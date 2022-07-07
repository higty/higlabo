using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_WindowsAutopilotDeviceIdentities_WindowsAutopilotDeviceIdentityId_UpdateDeviceProperties,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_WindowsAutopilotDeviceIdentities_WindowsAutopilotDeviceIdentityId_UpdateDeviceProperties: return $"/deviceManagement/windowsAutopilotDeviceIdentities/{WindowsAutopilotDeviceIdentityId}/updateDeviceProperties";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? UserPrincipalName { get; set; }
        public string? AddressableUserName { get; set; }
        public string? GroupTag { get; set; }
        public string? DisplayName { get; set; }
        public string WindowsAutopilotDeviceIdentityId { get; set; }
    }
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-updatedeviceproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesResponse> IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesAsync()
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesParameter, IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-updatedeviceproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesResponse> IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesParameter, IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-updatedeviceproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesResponse> IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesAsync(IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesParameter, IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-updatedeviceproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesResponse> IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesAsync(IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesParameter, IntuneEnrollmentWindowsautopilotdeviceidentityUpdatedevicepropertiesResponse>(parameter, cancellationToken);
        }
    }
}
