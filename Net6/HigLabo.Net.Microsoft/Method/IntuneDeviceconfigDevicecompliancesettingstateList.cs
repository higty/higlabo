using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancesettingstateListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicySettingStateSummaries_DeviceCompliancePolicySettingStateSummaryId_DeviceComplianceSettingStates,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicySettingStateSummaries_DeviceCompliancePolicySettingStateSummaryId_DeviceComplianceSettingStates: return $"/deviceManagement/deviceCompliancePolicySettingStateSummaries/{DeviceCompliancePolicySettingStateSummaryId}/deviceComplianceSettingStates";
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
        public string DeviceCompliancePolicySettingStateSummaryId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancesettingstateListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancesettingstate?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceComplianceSettingState
        {
            public enum DeviceComplianceSettingStateComplianceStatus
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
            public string? Setting { get; set; }
            public string? SettingName { get; set; }
            public string? DeviceId { get; set; }
            public string? DeviceName { get; set; }
            public string? UserId { get; set; }
            public string? UserEmail { get; set; }
            public string? UserName { get; set; }
            public string? UserPrincipalName { get; set; }
            public string? DeviceModel { get; set; }
            public ComplianceStatus? State { get; set; }
            public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
        }

        public DeviceComplianceSettingState[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateListResponse> IntuneDeviceconfigDevicecompliancesettingstateListAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancesettingstateListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateListParameter, IntuneDeviceconfigDevicecompliancesettingstateListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateListResponse> IntuneDeviceconfigDevicecompliancesettingstateListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancesettingstateListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateListParameter, IntuneDeviceconfigDevicecompliancesettingstateListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateListResponse> IntuneDeviceconfigDevicecompliancesettingstateListAsync(IntuneDeviceconfigDevicecompliancesettingstateListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateListParameter, IntuneDeviceconfigDevicecompliancesettingstateListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateListResponse> IntuneDeviceconfigDevicecompliancesettingstateListAsync(IntuneDeviceconfigDevicecompliancesettingstateListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateListParameter, IntuneDeviceconfigDevicecompliancesettingstateListResponse>(parameter, cancellationToken);
        }
    }
}
