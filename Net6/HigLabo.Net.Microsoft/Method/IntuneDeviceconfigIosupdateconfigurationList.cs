using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosupdateconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations: return $"/deviceManagement/deviceConfigurations";
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
    public partial class IntuneDeviceconfigIosupdateconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-iosupdateconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class IosUpdateConfiguration
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
            public TimeOnly? ActiveHoursStart { get; set; }
            public TimeOnly? ActiveHoursEnd { get; set; }
            public DayOfWeek[]? ScheduledInstallDays { get; set; }
            public Int32? UtcTimeOffsetInMinutes { get; set; }
        }

        public IosUpdateConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationListResponse> IntuneDeviceconfigIosupdateconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigIosupdateconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationListParameter, IntuneDeviceconfigIosupdateconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationListResponse> IntuneDeviceconfigIosupdateconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosupdateconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationListParameter, IntuneDeviceconfigIosupdateconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationListResponse> IntuneDeviceconfigIosupdateconfigurationListAsync(IntuneDeviceconfigIosupdateconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationListParameter, IntuneDeviceconfigIosupdateconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationListResponse> IntuneDeviceconfigIosupdateconfigurationListAsync(IntuneDeviceconfigIosupdateconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationListParameter, IntuneDeviceconfigIosupdateconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
