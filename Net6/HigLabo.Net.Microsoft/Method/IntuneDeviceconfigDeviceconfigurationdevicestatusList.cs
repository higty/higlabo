using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationdevicestatusListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceStatuses: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/deviceStatuses";
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
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationdevicestatusListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-deviceconfigurationdevicestatus?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceConfigurationDeviceStatus
        {
            public enum DeviceConfigurationDeviceStatusComplianceStatus
            {
                Unknown,
                NotApplicable,
                Compliant,
                Remediated,
                NonCompliant,
                Error,
                Conflict,
                NotAssigned,
            }

            public string? Id { get; set; }
            public string? DeviceDisplayName { get; set; }
            public string? UserName { get; set; }
            public string? DeviceModel { get; set; }
            public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
            public ComplianceStatus? Status { get; set; }
            public DateTimeOffset? LastReportedDateTime { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public DeviceConfigurationDeviceStatus[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusListResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusListAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdevicestatusListParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusListParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusListResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdevicestatusListParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusListParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusListResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusListAsync(IntuneDeviceconfigDeviceconfigurationdevicestatusListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusListParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusListResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusListAsync(IntuneDeviceconfigDeviceconfigurationdevicestatusListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusListParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusListResponse>(parameter, cancellationToken);
        }
    }
}
