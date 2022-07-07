using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameterComplianceStatus
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
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_DeviceStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_DeviceStatuses: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/deviceStatuses";
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
        public IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameterComplianceStatus Status { get; set; }
        public DateTimeOffset? LastReportedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateResponse : RestApiResponse
    {
        public enum ManagedDeviceMobileAppConfigurationDeviceStatusComplianceStatus
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateAsync(IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateAsync(IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusCreateResponse>(parameter, cancellationToken);
        }
    }
}
