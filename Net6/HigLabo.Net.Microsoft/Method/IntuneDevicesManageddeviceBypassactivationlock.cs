using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceBypassactivationlockParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_BypassActivationLock,
            DeviceManagement_ManagedDevices_ManagedDeviceId_BypassActivationLock,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_BypassActivationLock,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_BypassActivationLock: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/bypassActivationLock";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_BypassActivationLock: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/bypassActivationLock";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_BypassActivationLock: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/bypassActivationLock";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceBypassactivationlockResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-bypassactivationlock?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceBypassactivationlockResponse> IntuneDevicesManageddeviceBypassactivationlockAsync()
        {
            var p = new IntuneDevicesManageddeviceBypassactivationlockParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceBypassactivationlockParameter, IntuneDevicesManageddeviceBypassactivationlockResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-bypassactivationlock?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceBypassactivationlockResponse> IntuneDevicesManageddeviceBypassactivationlockAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceBypassactivationlockParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceBypassactivationlockParameter, IntuneDevicesManageddeviceBypassactivationlockResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-bypassactivationlock?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceBypassactivationlockResponse> IntuneDevicesManageddeviceBypassactivationlockAsync(IntuneDevicesManageddeviceBypassactivationlockParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceBypassactivationlockParameter, IntuneDevicesManageddeviceBypassactivationlockResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-bypassactivationlock?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceBypassactivationlockResponse> IntuneDevicesManageddeviceBypassactivationlockAsync(IntuneDevicesManageddeviceBypassactivationlockParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceBypassactivationlockParameter, IntuneDevicesManageddeviceBypassactivationlockResponse>(parameter, cancellationToken);
        }
    }
}
