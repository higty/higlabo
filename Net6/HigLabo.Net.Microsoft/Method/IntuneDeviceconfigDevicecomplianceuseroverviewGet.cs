using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecomplianceuseroverviewGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_UserStatusOverview,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_UserStatusOverview: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/userStatusOverview";
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
    public partial class IntuneDeviceconfigDevicecomplianceuseroverviewGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public Int32? PendingCount { get; set; }
        public Int32? NotApplicableCount { get; set; }
        public Int32? SuccessCount { get; set; }
        public Int32? ErrorCount { get; set; }
        public Int32? FailedCount { get; set; }
        public DateTimeOffset? LastUpdateDateTime { get; set; }
        public Int32? ConfigurationVersion { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuseroverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuseroverviewGetResponse> IntuneDeviceconfigDevicecomplianceuseroverviewGetAsync()
        {
            var p = new IntuneDeviceconfigDevicecomplianceuseroverviewGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuseroverviewGetParameter, IntuneDeviceconfigDevicecomplianceuseroverviewGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuseroverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuseroverviewGetResponse> IntuneDeviceconfigDevicecomplianceuseroverviewGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecomplianceuseroverviewGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuseroverviewGetParameter, IntuneDeviceconfigDevicecomplianceuseroverviewGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuseroverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuseroverviewGetResponse> IntuneDeviceconfigDevicecomplianceuseroverviewGetAsync(IntuneDeviceconfigDevicecomplianceuseroverviewGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuseroverviewGetParameter, IntuneDeviceconfigDevicecomplianceuseroverviewGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceuseroverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceuseroverviewGetResponse> IntuneDeviceconfigDevicecomplianceuseroverviewGetAsync(IntuneDeviceconfigDevicecomplianceuseroverviewGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceuseroverviewGetParameter, IntuneDeviceconfigDevicecomplianceuseroverviewGetResponse>(parameter, cancellationToken);
        }
    }
}
