using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceRecoverpasscodeParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_RecoverPasscode,
            DeviceManagement_ManagedDevices_ManagedDeviceId_RecoverPasscode,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_RecoverPasscode,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_RecoverPasscode: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/recoverPasscode";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_RecoverPasscode: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/recoverPasscode";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_RecoverPasscode: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/recoverPasscode";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceRecoverpasscodeResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-recoverpasscode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRecoverpasscodeResponse> IntuneDevicesManageddeviceRecoverpasscodeAsync()
        {
            var p = new IntuneDevicesManageddeviceRecoverpasscodeParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceRecoverpasscodeParameter, IntuneDevicesManageddeviceRecoverpasscodeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-recoverpasscode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRecoverpasscodeResponse> IntuneDevicesManageddeviceRecoverpasscodeAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceRecoverpasscodeParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceRecoverpasscodeParameter, IntuneDevicesManageddeviceRecoverpasscodeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-recoverpasscode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRecoverpasscodeResponse> IntuneDevicesManageddeviceRecoverpasscodeAsync(IntuneDevicesManageddeviceRecoverpasscodeParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceRecoverpasscodeParameter, IntuneDevicesManageddeviceRecoverpasscodeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-recoverpasscode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRecoverpasscodeResponse> IntuneDevicesManageddeviceRecoverpasscodeAsync(IntuneDevicesManageddeviceRecoverpasscodeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceRecoverpasscodeParameter, IntuneDevicesManageddeviceRecoverpasscodeResponse>(parameter, cancellationToken);
        }
    }
}
