using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamAndroidmanagedappregistrationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneMamAndroidmanagedappregistrationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappregistrationGetResponse> IntuneMamAndroidmanagedappregistrationGetAsync()
        {
            var p = new IntuneMamAndroidmanagedappregistrationGetParameter();
            return await this.SendAsync<IntuneMamAndroidmanagedappregistrationGetParameter, IntuneMamAndroidmanagedappregistrationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappregistrationGetResponse> IntuneMamAndroidmanagedappregistrationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamAndroidmanagedappregistrationGetParameter();
            return await this.SendAsync<IntuneMamAndroidmanagedappregistrationGetParameter, IntuneMamAndroidmanagedappregistrationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappregistrationGetResponse> IntuneMamAndroidmanagedappregistrationGetAsync(IntuneMamAndroidmanagedappregistrationGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamAndroidmanagedappregistrationGetParameter, IntuneMamAndroidmanagedappregistrationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappregistration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappregistrationGetResponse> IntuneMamAndroidmanagedappregistrationGetAsync(IntuneMamAndroidmanagedappregistrationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamAndroidmanagedappregistrationGetParameter, IntuneMamAndroidmanagedappregistrationGetResponse>(parameter, cancellationToken);
        }
    }
}
