using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicemanagementpartnerGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceManagementPartners_DeviceManagementPartnerId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceManagementPartners_DeviceManagementPartnerId: return $"/deviceManagement/deviceManagementPartners/{DeviceManagementPartnerId}";
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
        public string DeviceManagementPartnerId { get; set; }
    }
    public partial class IntuneOnboardingDevicemanagementpartnerGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerGetResponse> IntuneOnboardingDevicemanagementpartnerGetAsync()
        {
            var p = new IntuneOnboardingDevicemanagementpartnerGetParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerGetParameter, IntuneOnboardingDevicemanagementpartnerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerGetResponse> IntuneOnboardingDevicemanagementpartnerGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicemanagementpartnerGetParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerGetParameter, IntuneOnboardingDevicemanagementpartnerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerGetResponse> IntuneOnboardingDevicemanagementpartnerGetAsync(IntuneOnboardingDevicemanagementpartnerGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerGetParameter, IntuneOnboardingDevicemanagementpartnerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerGetResponse> IntuneOnboardingDevicemanagementpartnerGetAsync(IntuneOnboardingDevicemanagementpartnerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerGetParameter, IntuneOnboardingDevicemanagementpartnerGetResponse>(parameter, cancellationToken);
        }
    }
}
