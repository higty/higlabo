using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamTargetedmanagedapppolicyassignmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId_Assignments_TargetedManagedAppPolicyAssignmentId,
            DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId_Assignments_TargetedManagedAppPolicyAssignmentId,
            DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_Assignments_TargetedManagedAppPolicyAssignmentId,
            DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_Assignments_TargetedManagedAppPolicyAssignmentId,
            DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_Assignments_TargetedManagedAppPolicyAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId_Assignments_TargetedManagedAppPolicyAssignmentId: return $"/deviceAppManagement/iosManagedAppProtections/{IosManagedAppProtectionId}/assignments/{TargetedManagedAppPolicyAssignmentId}";
                    case ApiPath.DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId_Assignments_TargetedManagedAppPolicyAssignmentId: return $"/deviceAppManagement/androidManagedAppProtections/{AndroidManagedAppProtectionId}/assignments/{TargetedManagedAppPolicyAssignmentId}";
                    case ApiPath.DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_Assignments_TargetedManagedAppPolicyAssignmentId: return $"/deviceAppManagement/targetedManagedAppConfigurations/{TargetedManagedAppConfigurationId}/assignments/{TargetedManagedAppPolicyAssignmentId}";
                    case ApiPath.DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_Assignments_TargetedManagedAppPolicyAssignmentId: return $"/deviceAppManagement/windowsInformationProtectionPolicies/{WindowsInformationProtectionPolicyId}/assignments/{TargetedManagedAppPolicyAssignmentId}";
                    case ApiPath.DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_Assignments_TargetedManagedAppPolicyAssignmentId: return $"/deviceAppManagement/mdmWindowsInformationProtectionPolicies/{MdmWindowsInformationProtectionPolicyId}/assignments/{TargetedManagedAppPolicyAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string IosManagedAppProtectionId { get; set; }
        public string TargetedManagedAppPolicyAssignmentId { get; set; }
        public string AndroidManagedAppProtectionId { get; set; }
        public string TargetedManagedAppConfigurationId { get; set; }
        public string WindowsInformationProtectionPolicyId { get; set; }
        public string MdmWindowsInformationProtectionPolicyId { get; set; }
    }
    public partial class IntuneMamTargetedmanagedapppolicyassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedapppolicyassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedapppolicyassignmentDeleteResponse> IntuneMamTargetedmanagedapppolicyassignmentDeleteAsync()
        {
            var p = new IntuneMamTargetedmanagedapppolicyassignmentDeleteParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedapppolicyassignmentDeleteParameter, IntuneMamTargetedmanagedapppolicyassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedapppolicyassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedapppolicyassignmentDeleteResponse> IntuneMamTargetedmanagedapppolicyassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamTargetedmanagedapppolicyassignmentDeleteParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedapppolicyassignmentDeleteParameter, IntuneMamTargetedmanagedapppolicyassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedapppolicyassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedapppolicyassignmentDeleteResponse> IntuneMamTargetedmanagedapppolicyassignmentDeleteAsync(IntuneMamTargetedmanagedapppolicyassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedapppolicyassignmentDeleteParameter, IntuneMamTargetedmanagedapppolicyassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedapppolicyassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedapppolicyassignmentDeleteResponse> IntuneMamTargetedmanagedapppolicyassignmentDeleteAsync(IntuneMamTargetedmanagedapppolicyassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedapppolicyassignmentDeleteParameter, IntuneMamTargetedmanagedapppolicyassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
