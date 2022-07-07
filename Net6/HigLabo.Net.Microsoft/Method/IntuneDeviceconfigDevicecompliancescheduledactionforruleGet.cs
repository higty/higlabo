using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancescheduledactionforruleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule_DeviceComplianceScheduledActionForRuleId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule_DeviceComplianceScheduledActionForRuleId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/scheduledActionsForRule/{DeviceComplianceScheduledActionForRuleId}";
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
        public string DeviceComplianceScheduledActionForRuleId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancescheduledactionforruleGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? RuleName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleGetResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleGetAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancescheduledactionforruleGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleGetParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleGetResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancescheduledactionforruleGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleGetParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleGetResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleGetAsync(IntuneDeviceconfigDevicecompliancescheduledactionforruleGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleGetParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleGetResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleGetAsync(IntuneDeviceconfigDevicecompliancescheduledactionforruleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleGetParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleGetResponse>(parameter, cancellationToken);
        }
    }
}
