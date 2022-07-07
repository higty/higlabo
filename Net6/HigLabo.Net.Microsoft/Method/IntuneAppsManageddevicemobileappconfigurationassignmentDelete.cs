using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationassignmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_Assignments_ManagedDeviceMobileAppConfigurationAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_Assignments_ManagedDeviceMobileAppConfigurationAssignmentId: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/assignments/{ManagedDeviceMobileAppConfigurationAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
        public string ManagedDeviceMobileAppConfigurationAssignmentId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentDeleteResponse> IntuneAppsManageddevicemobileappconfigurationassignmentDeleteAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationassignmentDeleteParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentDeleteParameter, IntuneAppsManageddevicemobileappconfigurationassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentDeleteResponse> IntuneAppsManageddevicemobileappconfigurationassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationassignmentDeleteParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentDeleteParameter, IntuneAppsManageddevicemobileappconfigurationassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentDeleteResponse> IntuneAppsManageddevicemobileappconfigurationassignmentDeleteAsync(IntuneAppsManageddevicemobileappconfigurationassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentDeleteParameter, IntuneAppsManageddevicemobileappconfigurationassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentDeleteResponse> IntuneAppsManageddevicemobileappconfigurationassignmentDeleteAsync(IntuneAppsManageddevicemobileappconfigurationassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentDeleteParameter, IntuneAppsManageddevicemobileappconfigurationassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
