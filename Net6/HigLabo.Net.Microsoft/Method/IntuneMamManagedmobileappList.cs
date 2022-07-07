using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedmobileappListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string DefaultManagedAppProtectionId { get; set; }
        public string TargetedManagedAppConfigurationId { get; set; }
    }
    public partial class IntuneMamManagedmobileappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedmobileapp?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedMobileApp
        {
            public MobileAppIdentifier? MobileAppIdentifier { get; set; }
            public string? Id { get; set; }
            public string? Version { get; set; }
        }

        public ManagedMobileApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappListResponse> IntuneMamManagedmobileappListAsync()
        {
            var p = new IntuneMamManagedmobileappListParameter();
            return await this.SendAsync<IntuneMamManagedmobileappListParameter, IntuneMamManagedmobileappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappListResponse> IntuneMamManagedmobileappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedmobileappListParameter();
            return await this.SendAsync<IntuneMamManagedmobileappListParameter, IntuneMamManagedmobileappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappListResponse> IntuneMamManagedmobileappListAsync(IntuneMamManagedmobileappListParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedmobileappListParameter, IntuneMamManagedmobileappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedmobileapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedmobileappListResponse> IntuneMamManagedmobileappListAsync(IntuneMamManagedmobileappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedmobileappListParameter, IntuneMamManagedmobileappListResponse>(parameter, cancellationToken);
        }
    }
}
