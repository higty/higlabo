using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DevicePostDevicesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Devices,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Devices: return $"/devices";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class DevicePostDevicesResponse : RestApiResponse
    {
        public enum DeviceDeviceProfileType
        {
            RegisteredDevice,
            SecureVM,
            Printer,
            Shared,
            IoT,
        }

        public bool? AccountEnabled { get; set; }
        public AlternativeSecurityId[]? AlternativeSecurityIds { get; set; }
        public DateTimeOffset? ApproximateLastSignInDateTime { get; set; }
        public DateTimeOffset? ComplianceExpirationDateTime { get; set; }
        public string? DeviceId { get; set; }
        public string? DeviceMetadata { get; set; }
        public Int32? DeviceVersion { get; set; }
        public string? DisplayName { get; set; }
        public OnPremisesExtensionAttributes? ExtensionAttributes { get; set; }
        public string? Id { get; set; }
        public bool? IsCompliant { get; set; }
        public bool? IsManaged { get; set; }
        public string? Manufacturer { get; set; }
        public string? MdmAppId { get; set; }
        public string? Model { get; set; }
        public DateTimeOffset? OnPremisesLastSyncDateTime { get; set; }
        public bool? OnPremisesSyncEnabled { get; set; }
        public string? OperatingSystem { get; set; }
        public string? OperatingSystemVersion { get; set; }
        public String[]? PhysicalIds { get; set; }
        public DeviceDeviceProfileType ProfileType { get; set; }
        public String[]? SystemLabels { get; set; }
        public string? TrustType { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-devices?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostDevicesResponse> DevicePostDevicesAsync()
        {
            var p = new DevicePostDevicesParameter();
            return await this.SendAsync<DevicePostDevicesParameter, DevicePostDevicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-devices?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostDevicesResponse> DevicePostDevicesAsync(CancellationToken cancellationToken)
        {
            var p = new DevicePostDevicesParameter();
            return await this.SendAsync<DevicePostDevicesParameter, DevicePostDevicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-devices?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostDevicesResponse> DevicePostDevicesAsync(DevicePostDevicesParameter parameter)
        {
            return await this.SendAsync<DevicePostDevicesParameter, DevicePostDevicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-devices?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostDevicesResponse> DevicePostDevicesAsync(DevicePostDevicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DevicePostDevicesParameter, DevicePostDevicesResponse>(parameter, cancellationToken);
        }
    }
}
