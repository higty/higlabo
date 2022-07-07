using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceWipeParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_Wipe,
            DeviceManagement_ManagedDevices_ManagedDeviceId_Wipe,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_Wipe,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_Wipe: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/wipe";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_Wipe: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/wipe";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_Wipe: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/wipe";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public bool? KeepEnrollmentData { get; set; }
        public bool? KeepUserData { get; set; }
        public string? MacOsUnlockCode { get; set; }
        public bool? PersistEsimDataPlan { get; set; }
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceWipeResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-wipe?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWipeResponse> IntuneDevicesManageddeviceWipeAsync()
        {
            var p = new IntuneDevicesManageddeviceWipeParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceWipeParameter, IntuneDevicesManageddeviceWipeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-wipe?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWipeResponse> IntuneDevicesManageddeviceWipeAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceWipeParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceWipeParameter, IntuneDevicesManageddeviceWipeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-wipe?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWipeResponse> IntuneDevicesManageddeviceWipeAsync(IntuneDevicesManageddeviceWipeParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceWipeParameter, IntuneDevicesManageddeviceWipeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-wipe?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWipeResponse> IntuneDevicesManageddeviceWipeAsync(IntuneDevicesManageddeviceWipeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceWipeParameter, IntuneDevicesManageddeviceWipeResponse>(parameter, cancellationToken);
        }
    }
}
