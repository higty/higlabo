using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows81compliancepolicyDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigWindows81compliancepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81compliancepolicyDeleteResponse> IntuneDeviceconfigWindows81compliancepolicyDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindows81compliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows81compliancepolicyDeleteParameter, IntuneDeviceconfigWindows81compliancepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81compliancepolicyDeleteResponse> IntuneDeviceconfigWindows81compliancepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows81compliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows81compliancepolicyDeleteParameter, IntuneDeviceconfigWindows81compliancepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81compliancepolicyDeleteResponse> IntuneDeviceconfigWindows81compliancepolicyDeleteAsync(IntuneDeviceconfigWindows81compliancepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows81compliancepolicyDeleteParameter, IntuneDeviceconfigWindows81compliancepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81compliancepolicyDeleteResponse> IntuneDeviceconfigWindows81compliancepolicyDeleteAsync(IntuneDeviceconfigWindows81compliancepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows81compliancepolicyDeleteParameter, IntuneDeviceconfigWindows81compliancepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
