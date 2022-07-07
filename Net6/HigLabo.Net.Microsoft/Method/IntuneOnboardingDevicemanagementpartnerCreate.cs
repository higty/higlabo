using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicemanagementpartnerCreateParameter : IRestApiParameter
    {
        public enum IntuneOnboardingDevicemanagementpartnerCreateParameterDeviceManagementPartnerTenantState
        {
            Unknown,
            Unavailable,
            Enabled,
            Terminated,
            Rejected,
            Unresponsive,
        }
        public enum IntuneOnboardingDevicemanagementpartnerCreateParameterDeviceManagementPartnerAppType
        {
            Unknown,
            SingleTenantApp,
            MultiTenantApp,
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceManagementPartners,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceManagementPartners: return $"/deviceManagement/deviceManagementPartners";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastHeartbeatDateTime { get; set; }
        public IntuneOnboardingDevicemanagementpartnerCreateParameterDeviceManagementPartnerTenantState PartnerState { get; set; }
        public IntuneOnboardingDevicemanagementpartnerCreateParameterDeviceManagementPartnerAppType PartnerAppType { get; set; }
        public string? SingleTenantAppId { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsConfigured { get; set; }
        public DateTimeOffset? WhenPartnerDevicesWillBeRemovedDateTime { get; set; }
        public DateTimeOffset? WhenPartnerDevicesWillBeMarkedAsNonCompliantDateTime { get; set; }
    }
    public partial class IntuneOnboardingDevicemanagementpartnerCreateResponse : RestApiResponse
    {
        public enum DeviceManagementPartnerDeviceManagementPartnerTenantState
        {
            Unknown,
            Unavailable,
            Enabled,
            Terminated,
            Rejected,
            Unresponsive,
        }
        public enum DeviceManagementPartnerDeviceManagementPartnerAppType
        {
            Unknown,
            SingleTenantApp,
            MultiTenantApp,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastHeartbeatDateTime { get; set; }
        public DeviceManagementPartnerTenantState? PartnerState { get; set; }
        public DeviceManagementPartnerAppType? PartnerAppType { get; set; }
        public string? SingleTenantAppId { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsConfigured { get; set; }
        public DateTimeOffset? WhenPartnerDevicesWillBeRemovedDateTime { get; set; }
        public DateTimeOffset? WhenPartnerDevicesWillBeMarkedAsNonCompliantDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerCreateResponse> IntuneOnboardingDevicemanagementpartnerCreateAsync()
        {
            var p = new IntuneOnboardingDevicemanagementpartnerCreateParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerCreateParameter, IntuneOnboardingDevicemanagementpartnerCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerCreateResponse> IntuneOnboardingDevicemanagementpartnerCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicemanagementpartnerCreateParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerCreateParameter, IntuneOnboardingDevicemanagementpartnerCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerCreateResponse> IntuneOnboardingDevicemanagementpartnerCreateAsync(IntuneOnboardingDevicemanagementpartnerCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerCreateParameter, IntuneOnboardingDevicemanagementpartnerCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerCreateResponse> IntuneOnboardingDevicemanagementpartnerCreateAsync(IntuneOnboardingDevicemanagementpartnerCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerCreateParameter, IntuneOnboardingDevicemanagementpartnerCreateResponse>(parameter, cancellationToken);
        }
    }
}
