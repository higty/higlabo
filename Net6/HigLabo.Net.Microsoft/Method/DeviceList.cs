using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class DeviceListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/device?view=graph-rest-1.0
        /// </summary>
        public partial class Device
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

        public Device[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListResponse> DeviceListAsync()
        {
            var p = new DeviceListParameter();
            return await this.SendAsync<DeviceListParameter, DeviceListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListResponse> DeviceListAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceListParameter();
            return await this.SendAsync<DeviceListParameter, DeviceListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListResponse> DeviceListAsync(DeviceListParameter parameter)
        {
            return await this.SendAsync<DeviceListParameter, DeviceListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListResponse> DeviceListAsync(DeviceListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceListParameter, DeviceListResponse>(parameter, cancellationToken);
        }
    }
}
