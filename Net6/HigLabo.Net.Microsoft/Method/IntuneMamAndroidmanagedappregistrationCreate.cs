using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamAndroidmanagedappregistrationCreateParameter : IRestApiParameter
    {
        public enum IntuneMamAndroidmanagedappregistrationCreateParameterManagedAppFlaggedReason
        {
            None,
            RootedDevice,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastSyncDateTime { get; set; }
        public string? ApplicationVersion { get; set; }
        public string? ManagementSdkVersion { get; set; }
        public string? PlatformVersion { get; set; }
        public string? DeviceType { get; set; }
        public string? DeviceTag { get; set; }
        public string? DeviceName { get; set; }
        public IntuneMamAndroidmanagedappregistrationCreateParameterManagedAppFlaggedReason FlaggedReasons { get; set; }
        public string? UserId { get; set; }
        public MobileAppIdentifier? AppIdentifier { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
    }
    public partial class IntuneMamAndroidmanagedappregistrationCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappregistration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappregistrationCreateResponse> IntuneMamAndroidmanagedappregistrationCreateAsync()
        {
            var p = new IntuneMamAndroidmanagedappregistrationCreateParameter();
            return await this.SendAsync<IntuneMamAndroidmanagedappregistrationCreateParameter, IntuneMamAndroidmanagedappregistrationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappregistration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappregistrationCreateResponse> IntuneMamAndroidmanagedappregistrationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamAndroidmanagedappregistrationCreateParameter();
            return await this.SendAsync<IntuneMamAndroidmanagedappregistrationCreateParameter, IntuneMamAndroidmanagedappregistrationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappregistration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappregistrationCreateResponse> IntuneMamAndroidmanagedappregistrationCreateAsync(IntuneMamAndroidmanagedappregistrationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneMamAndroidmanagedappregistrationCreateParameter, IntuneMamAndroidmanagedappregistrationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappregistration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappregistrationCreateResponse> IntuneMamAndroidmanagedappregistrationCreateAsync(IntuneMamAndroidmanagedappregistrationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamAndroidmanagedappregistrationCreateParameter, IntuneMamAndroidmanagedappregistrationCreateResponse>(parameter, cancellationToken);
        }
    }
}
