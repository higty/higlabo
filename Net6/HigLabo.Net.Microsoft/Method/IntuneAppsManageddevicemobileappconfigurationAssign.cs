using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationAssignParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_Assign,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_Assign: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/assign";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ManagedDeviceMobileAppConfigurationAssignment[]? Assignments { get; set; }
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationAssignResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationAssignResponse> IntuneAppsManageddevicemobileappconfigurationAssignAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationAssignParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationAssignParameter, IntuneAppsManageddevicemobileappconfigurationAssignResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationAssignResponse> IntuneAppsManageddevicemobileappconfigurationAssignAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationAssignParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationAssignParameter, IntuneAppsManageddevicemobileappconfigurationAssignResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationAssignResponse> IntuneAppsManageddevicemobileappconfigurationAssignAsync(IntuneAppsManageddevicemobileappconfigurationAssignParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationAssignParameter, IntuneAppsManageddevicemobileappconfigurationAssignResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationAssignResponse> IntuneAppsManageddevicemobileappconfigurationAssignAsync(IntuneAppsManageddevicemobileappconfigurationAssignParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationAssignParameter, IntuneAppsManageddevicemobileappconfigurationAssignResponse>(parameter, cancellationToken);
        }
    }
}
