using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamIosmanagedappregistrationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneMamIosmanagedappregistrationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-iosmanagedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamIosmanagedappregistrationGetResponse> IntuneMamIosmanagedappregistrationGetAsync()
        {
            var p = new IntuneMamIosmanagedappregistrationGetParameter();
            return await this.SendAsync<IntuneMamIosmanagedappregistrationGetParameter, IntuneMamIosmanagedappregistrationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-iosmanagedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamIosmanagedappregistrationGetResponse> IntuneMamIosmanagedappregistrationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamIosmanagedappregistrationGetParameter();
            return await this.SendAsync<IntuneMamIosmanagedappregistrationGetParameter, IntuneMamIosmanagedappregistrationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-iosmanagedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamIosmanagedappregistrationGetResponse> IntuneMamIosmanagedappregistrationGetAsync(IntuneMamIosmanagedappregistrationGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamIosmanagedappregistrationGetParameter, IntuneMamIosmanagedappregistrationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-iosmanagedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamIosmanagedappregistrationGetResponse> IntuneMamIosmanagedappregistrationGetAsync(IntuneMamIosmanagedappregistrationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamIosmanagedappregistrationGetParameter, IntuneMamIosmanagedappregistrationGetResponse>(parameter, cancellationToken);
        }
    }
}
