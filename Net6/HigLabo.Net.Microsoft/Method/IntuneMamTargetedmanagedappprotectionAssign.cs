using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamTargetedmanagedappprotectionAssignParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppPolicies_ManagedAppPolicyId_Assign,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies_ManagedAppPolicyId_Assign,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies_ManagedAppPolicyId_Assign,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppPolicies_ManagedAppPolicyId_Assign: return $"/deviceAppManagement/managedAppPolicies/{ManagedAppPolicyId}/assign";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies_ManagedAppPolicyId_Assign: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/appliedPolicies/{ManagedAppPolicyId}/assign";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies_ManagedAppPolicyId_Assign: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/intendedPolicies/{ManagedAppPolicyId}/assign";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public TargetedManagedAppPolicyAssignment[]? Assignments { get; set; }
        public string ManagedAppPolicyId { get; set; }
        public string ManagedAppRegistrationId { get; set; }
    }
    public partial class IntuneMamTargetedmanagedappprotectionAssignResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappprotection-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappprotectionAssignResponse> IntuneMamTargetedmanagedappprotectionAssignAsync()
        {
            var p = new IntuneMamTargetedmanagedappprotectionAssignParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappprotectionAssignParameter, IntuneMamTargetedmanagedappprotectionAssignResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappprotection-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappprotectionAssignResponse> IntuneMamTargetedmanagedappprotectionAssignAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamTargetedmanagedappprotectionAssignParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappprotectionAssignParameter, IntuneMamTargetedmanagedappprotectionAssignResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappprotection-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappprotectionAssignResponse> IntuneMamTargetedmanagedappprotectionAssignAsync(IntuneMamTargetedmanagedappprotectionAssignParameter parameter)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappprotectionAssignParameter, IntuneMamTargetedmanagedappprotectionAssignResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappprotection-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappprotectionAssignResponse> IntuneMamTargetedmanagedappprotectionAssignAsync(IntuneMamTargetedmanagedappprotectionAssignParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappprotectionAssignParameter, IntuneMamTargetedmanagedappprotectionAssignResponse>(parameter, cancellationToken);
        }
    }
}
