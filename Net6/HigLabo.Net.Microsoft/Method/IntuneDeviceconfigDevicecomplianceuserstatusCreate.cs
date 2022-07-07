using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecomplianceuserstatusCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigDevicecomplianceuserstatusCreateParameterComplianceStatus
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
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_UserStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_UserStatuses: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/userStatuses";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? UserDisplayName { get; set; }
        public Int32? DevicesCount { get; set; }
        public IntuneDeviceconfigDevicecomplianceuserstatusCreateParameterComplianceStatus Status { get; set; }
        public DateTimeOffset? LastReportedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecomplianceuserstatusCreateResponse : RestApiResponse
    {
        public enum DeviceComplianceUserStatusComplianceStatus
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
        public string? UserDisplayName { get; set; }
        public Int32? DevicesCount { get; set; }
        public ComplianceStatus? Status { get; set; }
        public DateTimeOffset? LastReportedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusCreateResponse> IntuneDeviceconfigDevicecomplianceuserstatusCreateAsync()
        {
            var p = new IntuneDeviceconfigDevicecomplianceuserstatusCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusCreateParameter, IntuneDeviceconfigDevicecomplianceuserstatusCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusCreateResponse> IntuneDeviceconfigDevicecomplianceuserstatusCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecomplianceuserstatusCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusCreateParameter, IntuneDeviceconfigDevicecomplianceuserstatusCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusCreateResponse> IntuneDeviceconfigDevicecomplianceuserstatusCreateAsync(IntuneDeviceconfigDevicecomplianceuserstatusCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusCreateParameter, IntuneDeviceconfigDevicecomplianceuserstatusCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusCreateResponse> IntuneDeviceconfigDevicecomplianceuserstatusCreateAsync(IntuneDeviceconfigDevicecomplianceuserstatusCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusCreateParameter, IntuneDeviceconfigDevicecomplianceuserstatusCreateResponse>(parameter, cancellationToken);
        }
    }
}
