using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedmobileappDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId_Apps_ManagedMobileAppId,
            DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId_Apps_ManagedMobileAppId,
            DeviceAppManagement_DefaultManagedAppProtections_DefaultManagedAppProtectionId_Apps_ManagedMobileAppId,
            DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_Apps_ManagedMobileAppId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId_Apps_ManagedMobileAppId: return $"/deviceAppManagement/iosManagedAppProtections/{IosManagedAppProtectionId}/apps/{ManagedMobileAppId}";
                    case ApiPath.DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId_Apps_ManagedMobileAppId: return $"/deviceAppManagement/androidManagedAppProtections/{AndroidManagedAppProtectionId}/apps/{ManagedMobileAppId}";
                    case ApiPath.DeviceAppManagement_DefaultManagedAppProtections_DefaultManagedAppProtectionId_Apps_ManagedMobileAppId: return $"/deviceAppManagement/defaultManagedAppProtections/{DefaultManagedAppProtectionId}/apps/{ManagedMobileAppId}";
                    case ApiPath.DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_Apps_ManagedMobileAppId: return $"/deviceAppManagement/targetedManagedAppConfigurations/{TargetedManagedAppConfigurationId}/apps/{ManagedMobileAppId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string IosManagedAppProtectionId { get; set; }
        public string ManagedMobileAppId { get; set; }
        public string AndroidManagedAppProtectionId { get; set; }
        public string DefaultManagedAppProtectionId { get; set; }
        public string TargetedManagedAppConfigurationId { get; set; }
    }
    public partial class IntuneMamManagedmobileappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappDeleteResponse> IntuneMamManagedmobileappDeleteAsync()
        {
            var p = new IntuneMamManagedmobileappDeleteParameter();
            return await this.SendAsync<IntuneMamManagedmobileappDeleteParameter, IntuneMamManagedmobileappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappDeleteResponse> IntuneMamManagedmobileappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedmobileappDeleteParameter();
            return await this.SendAsync<IntuneMamManagedmobileappDeleteParameter, IntuneMamManagedmobileappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappDeleteResponse> IntuneMamManagedmobileappDeleteAsync(IntuneMamManagedmobileappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedmobileappDeleteParameter, IntuneMamManagedmobileappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappDeleteResponse> IntuneMamManagedmobileappDeleteAsync(IntuneMamManagedmobileappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedmobileappDeleteParameter, IntuneMamManagedmobileappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
