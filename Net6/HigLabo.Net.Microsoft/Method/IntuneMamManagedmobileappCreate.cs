using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedmobileappCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId_Apps,
            DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId_Apps,
            DeviceAppManagement_DefaultManagedAppProtections_DefaultManagedAppProtectionId_Apps,
            DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_Apps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId_Apps: return $"/deviceAppManagement/iosManagedAppProtections/{IosManagedAppProtectionId}/apps";
                    case ApiPath.DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId_Apps: return $"/deviceAppManagement/androidManagedAppProtections/{AndroidManagedAppProtectionId}/apps";
                    case ApiPath.DeviceAppManagement_DefaultManagedAppProtections_DefaultManagedAppProtectionId_Apps: return $"/deviceAppManagement/defaultManagedAppProtections/{DefaultManagedAppProtectionId}/apps";
                    case ApiPath.DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_Apps: return $"/deviceAppManagement/targetedManagedAppConfigurations/{TargetedManagedAppConfigurationId}/apps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public MobileAppIdentifier? MobileAppIdentifier { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public string IosManagedAppProtectionId { get; set; }
        public string AndroidManagedAppProtectionId { get; set; }
        public string DefaultManagedAppProtectionId { get; set; }
        public string TargetedManagedAppConfigurationId { get; set; }
    }
    public partial class IntuneMamManagedmobileappCreateResponse : RestApiResponse
    {
        public MobileAppIdentifier? MobileAppIdentifier { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappCreateResponse> IntuneMamManagedmobileappCreateAsync()
        {
            var p = new IntuneMamManagedmobileappCreateParameter();
            return await this.SendAsync<IntuneMamManagedmobileappCreateParameter, IntuneMamManagedmobileappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappCreateResponse> IntuneMamManagedmobileappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedmobileappCreateParameter();
            return await this.SendAsync<IntuneMamManagedmobileappCreateParameter, IntuneMamManagedmobileappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappCreateResponse> IntuneMamManagedmobileappCreateAsync(IntuneMamManagedmobileappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedmobileappCreateParameter, IntuneMamManagedmobileappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappCreateResponse> IntuneMamManagedmobileappCreateAsync(IntuneMamManagedmobileappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedmobileappCreateParameter, IntuneMamManagedmobileappCreateResponse>(parameter, cancellationToken);
        }
    }
}
