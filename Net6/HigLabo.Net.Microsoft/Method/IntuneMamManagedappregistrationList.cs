using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappregistrationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppRegistrations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations: return $"/deviceAppManagement/managedAppRegistrations";
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
    }
    public partial class IntuneMamManagedappregistrationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedappregistration?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedAppRegistration
        {
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? LastSyncDateTime { get; set; }
            public string? ApplicationVersion { get; set; }
            public string? ManagementSdkVersion { get; set; }
            public string? PlatformVersion { get; set; }
            public string? DeviceType { get; set; }
            public string? DeviceTag { get; set; }
            public string? DeviceName { get; set; }
            public ManagedAppFlaggedReason[]? FlaggedReasons { get; set; }
            public string? UserId { get; set; }
            public MobileAppIdentifier? AppIdentifier { get; set; }
            public string? Id { get; set; }
            public string? Version { get; set; }
        }

        public ManagedAppRegistration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappregistration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappregistrationListResponse> IntuneMamManagedappregistrationListAsync()
        {
            var p = new IntuneMamManagedappregistrationListParameter();
            return await this.SendAsync<IntuneMamManagedappregistrationListParameter, IntuneMamManagedappregistrationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappregistration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappregistrationListResponse> IntuneMamManagedappregistrationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappregistrationListParameter();
            return await this.SendAsync<IntuneMamManagedappregistrationListParameter, IntuneMamManagedappregistrationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappregistration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappregistrationListResponse> IntuneMamManagedappregistrationListAsync(IntuneMamManagedappregistrationListParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappregistrationListParameter, IntuneMamManagedappregistrationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappregistration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappregistrationListResponse> IntuneMamManagedappregistrationListAsync(IntuneMamManagedappregistrationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappregistrationListParameter, IntuneMamManagedappregistrationListResponse>(parameter, cancellationToken);
        }
    }
}
