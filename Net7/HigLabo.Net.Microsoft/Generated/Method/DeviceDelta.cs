using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices_Delta: return $"/devices/delta";
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
            DeviceCategory,
            DeviceId,
            DeviceMetadata,
            DeviceOwnership,
            DeviceVersion,
            DisplayName,
            EnrollmentProfileName,
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
            RegistrationDateTime,
            SystemLabels,
            TrustType,
            Extensions,
            MemberOf,
            RegisteredOwners,
            RegisteredUsers,
            TransitiveMemberOf,
        }
        public enum ApiPath
        {
            Devices_Delta,
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
    public partial class DeviceDeltaResponse : RestApiResponse
    {
        public Device[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeltaResponse> DeviceDeltaAsync()
        {
            var p = new DeviceDeltaParameter();
            return await this.SendAsync<DeviceDeltaParameter, DeviceDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeltaResponse> DeviceDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceDeltaParameter();
            return await this.SendAsync<DeviceDeltaParameter, DeviceDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeltaResponse> DeviceDeltaAsync(DeviceDeltaParameter parameter)
        {
            return await this.SendAsync<DeviceDeltaParameter, DeviceDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeltaResponse> DeviceDeltaAsync(DeviceDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceDeltaParameter, DeviceDeltaResponse>(parameter, cancellationToken);
        }
    }
}
