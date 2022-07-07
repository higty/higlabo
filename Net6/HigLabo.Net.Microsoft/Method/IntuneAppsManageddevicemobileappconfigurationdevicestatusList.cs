using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationdevicestatusListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationdevicestatusListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-manageddevicemobileappconfigurationdevicestatus?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedDeviceMobileAppConfigurationDeviceStatus
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

        public ManagedDeviceMobileAppConfigurationDeviceStatus[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusListResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusListAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationdevicestatusListParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusListParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusListResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationdevicestatusListParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusListParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusListResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusListAsync(IntuneAppsManageddevicemobileappconfigurationdevicestatusListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusListParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusListResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusListAsync(IntuneAppsManageddevicemobileappconfigurationdevicestatusListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusListParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusListResponse>(parameter, cancellationToken);
        }
    }
}
