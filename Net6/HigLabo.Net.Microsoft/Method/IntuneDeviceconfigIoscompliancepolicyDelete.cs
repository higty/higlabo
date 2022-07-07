using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIoscompliancepolicyDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigIoscompliancepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyDeleteResponse> IntuneDeviceconfigIoscompliancepolicyDeleteAsync()
        {
            var p = new IntuneDeviceconfigIoscompliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyDeleteParameter, IntuneDeviceconfigIoscompliancepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyDeleteResponse> IntuneDeviceconfigIoscompliancepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIoscompliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyDeleteParameter, IntuneDeviceconfigIoscompliancepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyDeleteResponse> IntuneDeviceconfigIoscompliancepolicyDeleteAsync(IntuneDeviceconfigIoscompliancepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyDeleteParameter, IntuneDeviceconfigIoscompliancepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscompliancepolicyDeleteResponse> IntuneDeviceconfigIoscompliancepolicyDeleteAsync(IntuneDeviceconfigIoscompliancepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscompliancepolicyDeleteParameter, IntuneDeviceconfigIoscompliancepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
