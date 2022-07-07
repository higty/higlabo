using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedmobileappGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string ManagedMobileAppId { get; set; }
        public string AndroidManagedAppProtectionId { get; set; }
        public string DefaultManagedAppProtectionId { get; set; }
        public string TargetedManagedAppConfigurationId { get; set; }
    }
    public partial class IntuneMamManagedmobileappGetResponse : RestApiResponse
    {
        public MobileAppIdentifier? MobileAppIdentifier { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappGetResponse> IntuneMamManagedmobileappGetAsync()
        {
            var p = new IntuneMamManagedmobileappGetParameter();
            return await this.SendAsync<IntuneMamManagedmobileappGetParameter, IntuneMamManagedmobileappGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappGetResponse> IntuneMamManagedmobileappGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedmobileappGetParameter();
            return await this.SendAsync<IntuneMamManagedmobileappGetParameter, IntuneMamManagedmobileappGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappGetResponse> IntuneMamManagedmobileappGetAsync(IntuneMamManagedmobileappGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedmobileappGetParameter, IntuneMamManagedmobileappGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappGetResponse> IntuneMamManagedmobileappGetAsync(IntuneMamManagedmobileappGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedmobileappGetParameter, IntuneMamManagedmobileappGetResponse>(parameter, cancellationToken);
        }
    }
}
