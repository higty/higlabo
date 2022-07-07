using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsphone81compliancepolicyDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindowsphone81compliancepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyDeleteResponse> IntuneDeviceconfigWindowsphone81compliancepolicyDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindowsphone81compliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyDeleteParameter, IntuneDeviceconfigWindowsphone81compliancepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyDeleteResponse> IntuneDeviceconfigWindowsphone81compliancepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsphone81compliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyDeleteParameter, IntuneDeviceconfigWindowsphone81compliancepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyDeleteResponse> IntuneDeviceconfigWindowsphone81compliancepolicyDeleteAsync(IntuneDeviceconfigWindowsphone81compliancepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyDeleteParameter, IntuneDeviceconfigWindowsphone81compliancepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81compliancepolicyDeleteResponse> IntuneDeviceconfigWindowsphone81compliancepolicyDeleteAsync(IntuneDeviceconfigWindowsphone81compliancepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81compliancepolicyDeleteParameter, IntuneDeviceconfigWindowsphone81compliancepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
