using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamTargetedmanagedapppolicyassignmentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId_Assignments,
            DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId_Assignments,
            DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_Assignments,
            DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_Assignments,
            DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId_Assignments: return $"/deviceAppManagement/iosManagedAppProtections/{IosManagedAppProtectionId}/assignments";
                    case ApiPath.DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId_Assignments: return $"/deviceAppManagement/androidManagedAppProtections/{AndroidManagedAppProtectionId}/assignments";
                    case ApiPath.DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_Assignments: return $"/deviceAppManagement/targetedManagedAppConfigurations/{TargetedManagedAppConfigurationId}/assignments";
                    case ApiPath.DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_Assignments: return $"/deviceAppManagement/windowsInformationProtectionPolicies/{WindowsInformationProtectionPolicyId}/assignments";
                    case ApiPath.DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_Assignments: return $"/deviceAppManagement/mdmWindowsInformationProtectionPolicies/{MdmWindowsInformationProtectionPolicyId}/assignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string IosManagedAppProtectionId { get; set; }
        public string AndroidManagedAppProtectionId { get; set; }
        public string TargetedManagedAppConfigurationId { get; set; }
        public string WindowsInformationProtectionPolicyId { get; set; }
        public string MdmWindowsInformationProtectionPolicyId { get; set; }
    }
    public partial class IntuneMamTargetedmanagedapppolicyassignmentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-targetedmanagedapppolicyassignment?view=graph-rest-1.0
        /// </summary>
        public partial class TargetedManagedAppPolicyAssignment
        {
            public string? Id { get; set; }
            public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        }

        public TargetedManagedAppPolicyAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedapppolicyassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedapppolicyassignmentListResponse> IntuneMamTargetedmanagedapppolicyassignmentListAsync()
        {
            var p = new IntuneMamTargetedmanagedapppolicyassignmentListParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedapppolicyassignmentListParameter, IntuneMamTargetedmanagedapppolicyassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedapppolicyassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedapppolicyassignmentListResponse> IntuneMamTargetedmanagedapppolicyassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamTargetedmanagedapppolicyassignmentListParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedapppolicyassignmentListParameter, IntuneMamTargetedmanagedapppolicyassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedapppolicyassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedapppolicyassignmentListResponse> IntuneMamTargetedmanagedapppolicyassignmentListAsync(IntuneMamTargetedmanagedapppolicyassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedapppolicyassignmentListParameter, IntuneMamTargetedmanagedapppolicyassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedapppolicyassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedapppolicyassignmentListResponse> IntuneMamTargetedmanagedapppolicyassignmentListAsync(IntuneMamTargetedmanagedapppolicyassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedapppolicyassignmentListParameter, IntuneMamTargetedmanagedapppolicyassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
