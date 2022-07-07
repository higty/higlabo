using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10compliancepolicyDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindows10compliancepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10compliancepolicyDeleteResponse> IntuneDeviceconfigWindows10compliancepolicyDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindows10compliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10compliancepolicyDeleteParameter, IntuneDeviceconfigWindows10compliancepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10compliancepolicyDeleteResponse> IntuneDeviceconfigWindows10compliancepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10compliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10compliancepolicyDeleteParameter, IntuneDeviceconfigWindows10compliancepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10compliancepolicyDeleteResponse> IntuneDeviceconfigWindows10compliancepolicyDeleteAsync(IntuneDeviceconfigWindows10compliancepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10compliancepolicyDeleteParameter, IntuneDeviceconfigWindows10compliancepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10compliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10compliancepolicyDeleteResponse> IntuneDeviceconfigWindows10compliancepolicyDeleteAsync(IntuneDeviceconfigWindows10compliancepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10compliancepolicyDeleteParameter, IntuneDeviceconfigWindows10compliancepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
