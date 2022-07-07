using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_UserStatuses_ManagedDeviceMobileAppConfigurationUserStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_UserStatuses_ManagedDeviceMobileAppConfigurationUserStatusId: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/userStatuses/{ManagedDeviceMobileAppConfigurationUserStatusId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
        public string ManagedDeviceMobileAppConfigurationUserStatusId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteAsync(IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteAsync(IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusDeleteResponse>(parameter, cancellationToken);
        }
    }
}
