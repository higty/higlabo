using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationdevicestatusGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceStatuses_DeviceConfigurationDeviceStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceStatuses_DeviceConfigurationDeviceStatusId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/deviceStatuses/{DeviceConfigurationDeviceStatusId}";
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
        public string DeviceConfigurationDeviceStatusId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationdevicestatusGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusGetResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusGetAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdevicestatusGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusGetParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusGetResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdevicestatusGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusGetParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusGetResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusGetAsync(IntuneDeviceconfigDeviceconfigurationdevicestatusGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusGetParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusGetResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusGetAsync(IntuneDeviceconfigDeviceconfigurationdevicestatusGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusGetParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusGetResponse>(parameter, cancellationToken);
        }
    }
}
