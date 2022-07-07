using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancedevicestatusGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceStatuses_DeviceComplianceDeviceStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceStatuses_DeviceComplianceDeviceStatusId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/deviceStatuses/{DeviceComplianceDeviceStatusId}";
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
        public string DeviceComplianceDeviceStatusId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancedevicestatusGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusGetResponse> IntuneDeviceconfigDevicecompliancedevicestatusGetAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancedevicestatusGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusGetParameter, IntuneDeviceconfigDevicecompliancedevicestatusGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusGetResponse> IntuneDeviceconfigDevicecompliancedevicestatusGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancedevicestatusGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusGetParameter, IntuneDeviceconfigDevicecompliancedevicestatusGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusGetResponse> IntuneDeviceconfigDevicecompliancedevicestatusGetAsync(IntuneDeviceconfigDevicecompliancedevicestatusGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusGetParameter, IntuneDeviceconfigDevicecompliancedevicestatusGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusGetResponse> IntuneDeviceconfigDevicecompliancedevicestatusGetAsync(IntuneDeviceconfigDevicecompliancedevicestatusGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusGetParameter, IntuneDeviceconfigDevicecompliancedevicestatusGetResponse>(parameter, cancellationToken);
        }
    }
}
