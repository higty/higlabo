using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappprotectionTargetappsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppPolicies_ManagedAppPolicyId_TargetApps,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies_ManagedAppPolicyId_TargetApps,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies_ManagedAppPolicyId_TargetApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppPolicies_ManagedAppPolicyId_TargetApps: return $"/deviceAppManagement/managedAppPolicies/{ManagedAppPolicyId}/targetApps";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies_ManagedAppPolicyId_TargetApps: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/appliedPolicies/{ManagedAppPolicyId}/targetApps";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies_ManagedAppPolicyId_TargetApps: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/intendedPolicies/{ManagedAppPolicyId}/targetApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ManagedMobileApp[]? Apps { get; set; }
        public string ManagedAppPolicyId { get; set; }
        public string ManagedAppRegistrationId { get; set; }
    }
    public partial class IntuneMamManagedappprotectionTargetappsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappprotection-targetapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappprotectionTargetappsResponse> IntuneMamManagedappprotectionTargetappsAsync()
        {
            var p = new IntuneMamManagedappprotectionTargetappsParameter();
            return await this.SendAsync<IntuneMamManagedappprotectionTargetappsParameter, IntuneMamManagedappprotectionTargetappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappprotection-targetapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappprotectionTargetappsResponse> IntuneMamManagedappprotectionTargetappsAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappprotectionTargetappsParameter();
            return await this.SendAsync<IntuneMamManagedappprotectionTargetappsParameter, IntuneMamManagedappprotectionTargetappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappprotection-targetapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappprotectionTargetappsResponse> IntuneMamManagedappprotectionTargetappsAsync(IntuneMamManagedappprotectionTargetappsParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappprotectionTargetappsParameter, IntuneMamManagedappprotectionTargetappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappprotection-targetapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappprotectionTargetappsResponse> IntuneMamManagedappprotectionTargetappsAsync(IntuneMamManagedappprotectionTargetappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappprotectionTargetappsParameter, IntuneMamManagedappprotectionTargetappsResponse>(parameter, cancellationToken);
        }
    }
}
