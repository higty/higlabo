using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_LogoutSharedAppleDeviceActiveUser,
            DeviceManagement_ManagedDevices_ManagedDeviceId_LogoutSharedAppleDeviceActiveUser,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_LogoutSharedAppleDeviceActiveUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_LogoutSharedAppleDeviceActiveUser: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/logoutSharedAppleDeviceActiveUser";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_LogoutSharedAppleDeviceActiveUser: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/logoutSharedAppleDeviceActiveUser";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_LogoutSharedAppleDeviceActiveUser: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/logoutSharedAppleDeviceActiveUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-logoutsharedappledeviceactiveuser?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserResponse> IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserAsync()
        {
            var p = new IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserParameter, IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-logoutsharedappledeviceactiveuser?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserResponse> IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserParameter, IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-logoutsharedappledeviceactiveuser?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserResponse> IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserAsync(IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserParameter, IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-logoutsharedappledeviceactiveuser?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserResponse> IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserAsync(IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserParameter, IntuneDevicesManageddeviceLogoutsharedappledeviceactiveuserResponse>(parameter, cancellationToken);
        }
    }
}
