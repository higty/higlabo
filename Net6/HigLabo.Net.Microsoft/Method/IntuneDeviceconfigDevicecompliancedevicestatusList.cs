using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancedevicestatusListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceStatuses: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/deviceStatuses";
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
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancedevicestatusListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancedevicestatus?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceComplianceDeviceStatus
        {
            public enum DeviceComplianceDeviceStatusComplianceStatus
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

        public DeviceComplianceDeviceStatus[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusListResponse> IntuneDeviceconfigDevicecompliancedevicestatusListAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancedevicestatusListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusListParameter, IntuneDeviceconfigDevicecompliancedevicestatusListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusListResponse> IntuneDeviceconfigDevicecompliancedevicestatusListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancedevicestatusListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusListParameter, IntuneDeviceconfigDevicecompliancedevicestatusListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusListResponse> IntuneDeviceconfigDevicecompliancedevicestatusListAsync(IntuneDeviceconfigDevicecompliancedevicestatusListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusListParameter, IntuneDeviceconfigDevicecompliancedevicestatusListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusListResponse> IntuneDeviceconfigDevicecompliancedevicestatusListAsync(IntuneDeviceconfigDevicecompliancedevicestatusListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusListParameter, IntuneDeviceconfigDevicecompliancedevicestatusListResponse>(parameter, cancellationToken);
        }
    }
}
