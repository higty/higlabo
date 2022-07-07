using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancedevicestatusCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigDevicecompliancedevicestatusCreateParameterComplianceStatus
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DeviceDisplayName { get; set; }
        public string? UserName { get; set; }
        public string? DeviceModel { get; set; }
        public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
        public IntuneDeviceconfigDevicecompliancedevicestatusCreateParameterComplianceStatus Status { get; set; }
        public DateTimeOffset? LastReportedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancedevicestatusCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusCreateResponse> IntuneDeviceconfigDevicecompliancedevicestatusCreateAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancedevicestatusCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusCreateParameter, IntuneDeviceconfigDevicecompliancedevicestatusCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusCreateResponse> IntuneDeviceconfigDevicecompliancedevicestatusCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancedevicestatusCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusCreateParameter, IntuneDeviceconfigDevicecompliancedevicestatusCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusCreateResponse> IntuneDeviceconfigDevicecompliancedevicestatusCreateAsync(IntuneDeviceconfigDevicecompliancedevicestatusCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusCreateParameter, IntuneDeviceconfigDevicecompliancedevicestatusCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedevicestatusCreateResponse> IntuneDeviceconfigDevicecompliancedevicestatusCreateAsync(IntuneDeviceconfigDevicecompliancedevicestatusCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedevicestatusCreateParameter, IntuneDeviceconfigDevicecompliancedevicestatusCreateResponse>(parameter, cancellationToken);
        }
    }
}
