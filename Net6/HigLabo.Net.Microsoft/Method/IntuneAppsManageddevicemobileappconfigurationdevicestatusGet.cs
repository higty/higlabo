using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationdevicestatusGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_DeviceStatuses_ManagedDeviceMobileAppConfigurationDeviceStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_DeviceStatuses_ManagedDeviceMobileAppConfigurationDeviceStatusId: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/deviceStatuses/{ManagedDeviceMobileAppConfigurationDeviceStatusId}";
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
        public string ManagedDeviceMobileAppConfigurationDeviceStatusId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationdevicestatusGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusGetResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusGetAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationdevicestatusGetParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusGetParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusGetResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationdevicestatusGetParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusGetParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusGetResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusGetAsync(IntuneAppsManageddevicemobileappconfigurationdevicestatusGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusGetParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationdevicestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationdevicestatusGetResponse> IntuneAppsManageddevicemobileappconfigurationdevicestatusGetAsync(IntuneAppsManageddevicemobileappconfigurationdevicestatusGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationdevicestatusGetParameter, IntuneAppsManageddevicemobileappconfigurationdevicestatusGetResponse>(parameter, cancellationToken);
        }
    }
}
