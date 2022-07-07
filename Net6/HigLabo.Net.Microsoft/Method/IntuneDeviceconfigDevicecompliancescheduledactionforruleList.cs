using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancescheduledactionforruleListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/scheduledActionsForRule";
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
    public partial class IntuneDeviceconfigDevicecompliancescheduledactionforruleListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancescheduledactionforrule?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceComplianceScheduledActionForRule
        {
            public string? Id { get; set; }
            public string? RuleName { get; set; }
        }

        public DeviceComplianceScheduledActionForRule[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleListResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleListAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancescheduledactionforruleListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleListParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleListResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancescheduledactionforruleListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleListParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleListResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleListAsync(IntuneDeviceconfigDevicecompliancescheduledactionforruleListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleListParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleListResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleListAsync(IntuneDeviceconfigDevicecompliancescheduledactionforruleListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleListParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleListResponse>(parameter, cancellationToken);
        }
    }
}
