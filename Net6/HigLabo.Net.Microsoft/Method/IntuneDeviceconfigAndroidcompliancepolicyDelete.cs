using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidcompliancepolicyDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigAndroidcompliancepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcompliancepolicyDeleteResponse> IntuneDeviceconfigAndroidcompliancepolicyDeleteAsync()
        {
            var p = new IntuneDeviceconfigAndroidcompliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidcompliancepolicyDeleteParameter, IntuneDeviceconfigAndroidcompliancepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcompliancepolicyDeleteResponse> IntuneDeviceconfigAndroidcompliancepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidcompliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidcompliancepolicyDeleteParameter, IntuneDeviceconfigAndroidcompliancepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcompliancepolicyDeleteResponse> IntuneDeviceconfigAndroidcompliancepolicyDeleteAsync(IntuneDeviceconfigAndroidcompliancepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidcompliancepolicyDeleteParameter, IntuneDeviceconfigAndroidcompliancepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcompliancepolicyDeleteResponse> IntuneDeviceconfigAndroidcompliancepolicyDeleteAsync(IntuneDeviceconfigAndroidcompliancepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidcompliancepolicyDeleteParameter, IntuneDeviceconfigAndroidcompliancepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
