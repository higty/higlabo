using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancesettingstateCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigDevicecompliancesettingstateCreateParameterComplianceStatus
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
            DeviceManagement_DeviceCompliancePolicySettingStateSummaries_DeviceCompliancePolicySettingStateSummaryId_DeviceComplianceSettingStates,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicySettingStateSummaries_DeviceCompliancePolicySettingStateSummaryId_DeviceComplianceSettingStates: return $"/deviceManagement/deviceCompliancePolicySettingStateSummaries/{DeviceCompliancePolicySettingStateSummaryId}/deviceComplianceSettingStates";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? Setting { get; set; }
        public string? SettingName { get; set; }
        public string? DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public string? UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? UserName { get; set; }
        public string? UserPrincipalName { get; set; }
        public string? DeviceModel { get; set; }
        public IntuneDeviceconfigDevicecompliancesettingstateCreateParameterComplianceStatus State { get; set; }
        public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
        public string DeviceCompliancePolicySettingStateSummaryId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancesettingstateCreateResponse : RestApiResponse
    {
        public enum DeviceComplianceSettingStateComplianceStatus
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
        public string? Setting { get; set; }
        public string? SettingName { get; set; }
        public string? DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public string? UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? UserName { get; set; }
        public string? UserPrincipalName { get; set; }
        public string? DeviceModel { get; set; }
        public ComplianceStatus? State { get; set; }
        public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateCreateResponse> IntuneDeviceconfigDevicecompliancesettingstateCreateAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancesettingstateCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateCreateParameter, IntuneDeviceconfigDevicecompliancesettingstateCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateCreateResponse> IntuneDeviceconfigDevicecompliancesettingstateCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancesettingstateCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateCreateParameter, IntuneDeviceconfigDevicecompliancesettingstateCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateCreateResponse> IntuneDeviceconfigDevicecompliancesettingstateCreateAsync(IntuneDeviceconfigDevicecompliancesettingstateCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateCreateParameter, IntuneDeviceconfigDevicecompliancesettingstateCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateCreateResponse> IntuneDeviceconfigDevicecompliancesettingstateCreateAsync(IntuneDeviceconfigDevicecompliancesettingstateCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateCreateParameter, IntuneDeviceconfigDevicecompliancesettingstateCreateResponse>(parameter, cancellationToken);
        }
    }
}
