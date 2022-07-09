using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices_Id: return $"/devices/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AccountEnabled,
            AlternativeSecurityIds,
            ApproximateLastSignInDateTime,
            ComplianceExpirationDateTime,
            DeviceId,
            DeviceMetadata,
            DeviceVersion,
            DisplayName,
            ExtensionAttributes,
            Id,
            IsCompliant,
            IsManaged,
            Manufacturer,
            MdmAppId,
            Model,
            OnPremisesLastSyncDateTime,
            OnPremisesSyncEnabled,
            OperatingSystem,
            OperatingSystemVersion,
            PhysicalIds,
            ProfileType,
            SystemLabels,
            TrustType,
            Extensions,
            MemberOf,
            TransitiveMemberOf,
            RegisteredOwners,
            RegisteredUsers,
        }
        public enum ApiPath
        {
            Devices_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class DeviceGetResponse : RestApiResponse
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
        public Extension[]? Extensions { get; set; }
        public DirectoryObject[]? MemberOf { get; set; }
        public DirectoryObject[]? TransitiveMemberOf { get; set; }
        public DirectoryObject[]? RegisteredOwners { get; set; }
        public DirectoryObject[]? RegisteredUsers { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceGetResponse> DeviceGetAsync()
        {
            var p = new DeviceGetParameter();
            return await this.SendAsync<DeviceGetParameter, DeviceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceGetResponse> DeviceGetAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceGetParameter();
            return await this.SendAsync<DeviceGetParameter, DeviceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceGetResponse> DeviceGetAsync(DeviceGetParameter parameter)
        {
            return await this.SendAsync<DeviceGetParameter, DeviceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceGetResponse> DeviceGetAsync(DeviceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceGetParameter, DeviceGetResponse>(parameter, cancellationToken);
        }
    }
}
