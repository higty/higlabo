using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecomplianceuserstatusListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_UserStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_UserStatuses: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/userStatuses";
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
    }
    public partial class IntuneDeviceconfigDevicecomplianceuserstatusListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecomplianceuserstatus?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceComplianceUserStatus
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

        public DeviceComplianceUserStatus[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusListResponse> IntuneDeviceconfigDevicecomplianceuserstatusListAsync()
        {
            var p = new IntuneDeviceconfigDevicecomplianceuserstatusListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusListParameter, IntuneDeviceconfigDevicecomplianceuserstatusListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusListResponse> IntuneDeviceconfigDevicecomplianceuserstatusListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecomplianceuserstatusListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusListParameter, IntuneDeviceconfigDevicecomplianceuserstatusListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusListResponse> IntuneDeviceconfigDevicecomplianceuserstatusListAsync(IntuneDeviceconfigDevicecomplianceuserstatusListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusListParameter, IntuneDeviceconfigDevicecomplianceuserstatusListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuserstatusListResponse> IntuneDeviceconfigDevicecomplianceuserstatusListAsync(IntuneDeviceconfigDevicecomplianceuserstatusListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuserstatusListParameter, IntuneDeviceconfigDevicecomplianceuserstatusListResponse>(parameter, cancellationToken);
        }
    }
}
