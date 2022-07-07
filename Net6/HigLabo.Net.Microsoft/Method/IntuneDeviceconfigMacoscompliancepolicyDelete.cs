using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacoscompliancepolicyDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigMacoscompliancepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyDeleteResponse> IntuneDeviceconfigMacoscompliancepolicyDeleteAsync()
        {
            var p = new IntuneDeviceconfigMacoscompliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyDeleteParameter, IntuneDeviceconfigMacoscompliancepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyDeleteResponse> IntuneDeviceconfigMacoscompliancepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacoscompliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyDeleteParameter, IntuneDeviceconfigMacoscompliancepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyDeleteResponse> IntuneDeviceconfigMacoscompliancepolicyDeleteAsync(IntuneDeviceconfigMacoscompliancepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyDeleteParameter, IntuneDeviceconfigMacoscompliancepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscompliancepolicyDeleteResponse> IntuneDeviceconfigMacoscompliancepolicyDeleteAsync(IntuneDeviceconfigMacoscompliancepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacoscompliancepolicyDeleteParameter, IntuneDeviceconfigMacoscompliancepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
