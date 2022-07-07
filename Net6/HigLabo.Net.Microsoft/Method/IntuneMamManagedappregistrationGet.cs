using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappregistrationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}";
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
        public string ManagedAppRegistrationId { get; set; }
    }
    public partial class IntuneMamManagedappregistrationGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappregistrationGetResponse> IntuneMamManagedappregistrationGetAsync()
        {
            var p = new IntuneMamManagedappregistrationGetParameter();
            return await this.SendAsync<IntuneMamManagedappregistrationGetParameter, IntuneMamManagedappregistrationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappregistrationGetResponse> IntuneMamManagedappregistrationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappregistrationGetParameter();
            return await this.SendAsync<IntuneMamManagedappregistrationGetParameter, IntuneMamManagedappregistrationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappregistrationGetResponse> IntuneMamManagedappregistrationGetAsync(IntuneMamManagedappregistrationGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappregistrationGetParameter, IntuneMamManagedappregistrationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappregistrationGetResponse> IntuneMamManagedappregistrationGetAsync(IntuneMamManagedappregistrationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappregistrationGetParameter, IntuneMamManagedappregistrationGetResponse>(parameter, cancellationToken);
        }
    }
}
