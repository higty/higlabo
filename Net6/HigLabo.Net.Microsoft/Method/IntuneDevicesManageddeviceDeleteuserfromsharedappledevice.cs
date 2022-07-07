using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_DeleteUserFromSharedAppleDevice,
            DeviceManagement_ManagedDevices_ManagedDeviceId_DeleteUserFromSharedAppleDevice,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_DeleteUserFromSharedAppleDevice,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_DeleteUserFromSharedAppleDevice: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/deleteUserFromSharedAppleDevice";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_DeleteUserFromSharedAppleDevice: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/deleteUserFromSharedAppleDevice";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_DeleteUserFromSharedAppleDevice: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/deleteUserFromSharedAppleDevice";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? UserPrincipalName { get; set; }
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-deleteuserfromsharedappledevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceResponse> IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceAsync()
        {
            var p = new IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceParameter, IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-deleteuserfromsharedappledevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceResponse> IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceParameter, IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-deleteuserfromsharedappledevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceResponse> IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceAsync(IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceParameter, IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-deleteuserfromsharedappledevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceResponse> IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceAsync(IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceParameter, IntuneDevicesManageddeviceDeleteuserfromsharedappledeviceResponse>(parameter, cancellationToken);
        }
    }
}
