using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameterComplianceStatus
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DeviceDisplayName { get; set; }
        public string? UserName { get; set; }
        public string? DeviceModel { get; set; }
        public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
        public IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameterComplianceStatus Status { get; set; }
        public DateTimeOffset? LastReportedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationdevicestatusCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusCreateResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusCreateAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusCreateResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusCreateResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusCreateAsync(IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusCreateResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusCreateAsync(IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusCreateParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusCreateResponse>(parameter, cancellationToken);
        }
    }
}
