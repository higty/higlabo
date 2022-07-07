using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationassignmentCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_Assignments: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/assignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationassignmentCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentCreateResponse> IntuneAppsManageddevicemobileappconfigurationassignmentCreateAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationassignmentCreateParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentCreateParameter, IntuneAppsManageddevicemobileappconfigurationassignmentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentCreateResponse> IntuneAppsManageddevicemobileappconfigurationassignmentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationassignmentCreateParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentCreateParameter, IntuneAppsManageddevicemobileappconfigurationassignmentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentCreateResponse> IntuneAppsManageddevicemobileappconfigurationassignmentCreateAsync(IntuneAppsManageddevicemobileappconfigurationassignmentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentCreateParameter, IntuneAppsManageddevicemobileappconfigurationassignmentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationassignmentCreateResponse> IntuneAppsManageddevicemobileappconfigurationassignmentCreateAsync(IntuneAppsManageddevicemobileappconfigurationassignmentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationassignmentCreateParameter, IntuneAppsManageddevicemobileappconfigurationassignmentCreateResponse>(parameter, cancellationToken);
        }
    }
}
