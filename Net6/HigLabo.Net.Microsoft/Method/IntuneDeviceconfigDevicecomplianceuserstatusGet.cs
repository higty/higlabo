using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecomplianceuserstatusGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_UserStatuses_DeviceComplianceUserStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_UserStatuses_DeviceComplianceUserStatusId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/userStatuses/{DeviceComplianceUserStatusId}";
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
        public string DeviceCompliancePolicyId { get; set; }
        public string DeviceComplianceUserStatusId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecomplianceuserstatusGetResponse : RestApiResponse
    {
        public enum DeviceComplianceUserStatusComplianceStatus
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusGetResponse> IntuneDeviceconfigDevicecomplianceuserstatusGetAsync()
        {
            var p = new IntuneDeviceconfigDevicecomplianceuserstatusGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusGetParameter, IntuneDeviceconfigDevicecomplianceuserstatusGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusGetResponse> IntuneDeviceconfigDevicecomplianceuserstatusGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecomplianceuserstatusGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusGetParameter, IntuneDeviceconfigDevicecomplianceuserstatusGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusGetResponse> IntuneDeviceconfigDevicecomplianceuserstatusGetAsync(IntuneDeviceconfigDevicecomplianceuserstatusGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusGetParameter, IntuneDeviceconfigDevicecomplianceuserstatusGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusGetResponse> IntuneDeviceconfigDevicecomplianceuserstatusGetAsync(IntuneDeviceconfigDevicecomplianceuserstatusGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusGetParameter, IntuneDeviceconfigDevicecomplianceuserstatusGetResponse>(parameter, cancellationToken);
        }
    }
}
