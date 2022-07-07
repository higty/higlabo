using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceResetpasscodeParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_ResetPasscode,
            DeviceManagement_ManagedDevices_ManagedDeviceId_ResetPasscode,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_ResetPasscode,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_ResetPasscode: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/resetPasscode";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_ResetPasscode: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/resetPasscode";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_ResetPasscode: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/resetPasscode";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceResetpasscodeResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-resetpasscode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceResetpasscodeResponse> IntuneDevicesManageddeviceResetpasscodeAsync()
        {
            var p = new IntuneDevicesManageddeviceResetpasscodeParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceResetpasscodeParameter, IntuneDevicesManageddeviceResetpasscodeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-resetpasscode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceResetpasscodeResponse> IntuneDevicesManageddeviceResetpasscodeAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceResetpasscodeParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceResetpasscodeParameter, IntuneDevicesManageddeviceResetpasscodeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-resetpasscode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceResetpasscodeResponse> IntuneDevicesManageddeviceResetpasscodeAsync(IntuneDevicesManageddeviceResetpasscodeParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceResetpasscodeParameter, IntuneDevicesManageddeviceResetpasscodeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-resetpasscode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceResetpasscodeResponse> IntuneDevicesManageddeviceResetpasscodeAsync(IntuneDevicesManageddeviceResetpasscodeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceResetpasscodeParameter, IntuneDevicesManageddeviceResetpasscodeResponse>(parameter, cancellationToken);
        }
    }
}
