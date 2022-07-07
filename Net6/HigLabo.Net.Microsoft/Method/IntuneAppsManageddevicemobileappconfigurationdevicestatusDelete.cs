using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_DeviceStatuses_ManagedDeviceMobileAppConfigurationDeviceStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_DeviceStatuses_ManagedDeviceMobileAppConfigurationDeviceStatusId: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/deviceStatuses/{ManagedDeviceMobileAppConfigurationDeviceStatusId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
        public string ManagedDeviceMobileAppConfigurationDeviceStatusId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteAsync(IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteAsync(IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusDeleteResponse>(parameter, cancellationToken);
        }
    }
}
