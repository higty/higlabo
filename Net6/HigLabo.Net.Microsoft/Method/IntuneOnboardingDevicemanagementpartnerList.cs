using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicemanagementpartnerListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneOnboardingDevicemanagementpartnerListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-devicemanagementpartner?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceManagementPartner
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

        public DeviceManagementPartner[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerListResponse> IntuneOnboardingDevicemanagementpartnerListAsync()
        {
            var p = new IntuneOnboardingDevicemanagementpartnerListParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerListParameter, IntuneOnboardingDevicemanagementpartnerListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerListResponse> IntuneOnboardingDevicemanagementpartnerListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicemanagementpartnerListParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerListParameter, IntuneOnboardingDevicemanagementpartnerListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerListResponse> IntuneOnboardingDevicemanagementpartnerListAsync(IntuneOnboardingDevicemanagementpartnerListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerListParameter, IntuneOnboardingDevicemanagementpartnerListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerListResponse> IntuneOnboardingDevicemanagementpartnerListAsync(IntuneOnboardingDevicemanagementpartnerListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerListParameter, IntuneOnboardingDevicemanagementpartnerListResponse>(parameter, cancellationToken);
        }
    }
}
