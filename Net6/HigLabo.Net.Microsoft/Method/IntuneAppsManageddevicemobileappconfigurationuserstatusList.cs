using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationuserstatusListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_UserStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_UserStatuses: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/userStatuses";
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
    public partial class IntuneAppsManageddevicemobileappconfigurationuserstatusListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-manageddevicemobileappconfigurationuserstatus?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedDeviceMobileAppConfigurationUserStatus
        {
            public enum ManagedDeviceMobileAppConfigurationUserStatusComplianceStatus
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

        public ManagedDeviceMobileAppConfigurationUserStatus[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusListResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusListAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationuserstatusListParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusListParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusListResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationuserstatusListParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusListParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusListResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusListAsync(IntuneAppsManageddevicemobileappconfigurationuserstatusListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusListParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusListResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusListAsync(IntuneAppsManageddevicemobileappconfigurationuserstatusListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusListParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusListResponse>(parameter, cancellationToken);
        }
    }
}
