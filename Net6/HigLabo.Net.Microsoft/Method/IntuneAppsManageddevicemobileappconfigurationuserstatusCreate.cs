using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameterComplianceStatus
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? UserDisplayName { get; set; }
        public Int32? DevicesCount { get; set; }
        public IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameterComplianceStatus Status { get; set; }
        public DateTimeOffset? LastReportedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
    }
    public partial class IntuneAppsManageddevicemobileappconfigurationuserstatusCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusCreateResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusCreateAsync()
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusCreateResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameter();
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusCreateResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusCreateAsync(IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-manageddevicemobileappconfigurationuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManageddevicemobileappconfigurationuserstatusCreateResponse> IntuneAppsManageddevicemobileappconfigurationuserstatusCreateAsync(IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManageddevicemobileappconfigurationuserstatusCreateParameter, IntuneAppsManageddevicemobileappconfigurationuserstatusCreateResponse>(parameter, cancellationToken);
        }
    }
}
