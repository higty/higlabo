using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationuserstatusGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_UserStatuses_ManagedDeviceMobileAppConfigurationUserStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId_UserStatuses_ManagedDeviceMobileAppConfigurationUserStatusId: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}/userStatuses/{ManagedDeviceMobileAppConfigurationUserStatusId}";
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
        public string ManagedDeviceMobileAppConfigurationUserStatusId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationuserstatusGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusGetResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusGetAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationuserstatusGetParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusGetParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusGetResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationuserstatusGetParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusGetParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusGetResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusGetAsync(IntuneAppsManageddevicemobileappconfigurationuserstatusGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusGetParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusGetResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusGetAsync(IntuneAppsManageddevicemobileappconfigurationuserstatusGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusGetParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusGetResponse>(parameter, cancellationToken);
        }
    }
}
