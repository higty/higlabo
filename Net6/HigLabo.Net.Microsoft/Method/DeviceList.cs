using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices: return $"/devices";
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
            Devices,
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
    public partial class DeviceListResponse : RestApiResponse
    {
        public Device[]? Value { get; set; }
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
