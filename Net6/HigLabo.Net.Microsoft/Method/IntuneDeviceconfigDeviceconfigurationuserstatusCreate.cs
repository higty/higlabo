using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameterComplianceStatus
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
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_UserStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_UserStatuses: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/userStatuses";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? UserDisplayName { get; set; }
        public Int32? DevicesCount { get; set; }
        public IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameterComplianceStatus Status { get; set; }
        public DateTimeOffset? LastReportedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationuserstatusCreateResponse : RestApiResponse
    {
        public enum DeviceConfigurationUserStatusComplianceStatus
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusCreateResponse> IntuneDeviceconfigDeviceconfigurationuserstatusCreateAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameter, IntuneDeviceconfigDeviceconfigurationuserstatusCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusCreateResponse> IntuneDeviceconfigDeviceconfigurationuserstatusCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameter, IntuneDeviceconfigDeviceconfigurationuserstatusCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusCreateResponse> IntuneDeviceconfigDeviceconfigurationuserstatusCreateAsync(IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameter, IntuneDeviceconfigDeviceconfigurationuserstatusCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusCreateResponse> IntuneDeviceconfigDeviceconfigurationuserstatusCreateAsync(IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusCreateParameter, IntuneDeviceconfigDeviceconfigurationuserstatusCreateResponse>(parameter, cancellationToken);
        }
    }
}
