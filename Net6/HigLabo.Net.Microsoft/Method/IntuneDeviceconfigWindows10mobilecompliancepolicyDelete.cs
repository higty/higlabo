using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10mobilecompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteResponse> IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteParameter, IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10mobilecompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteResponse> IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteParameter, IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10mobilecompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteResponse> IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteAsync(IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteParameter, IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10mobilecompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteResponse> IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteAsync(IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteParameter, IntuneDeviceconfigWindows10mobilecompliancepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
