using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteResponse> IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteAsync()
        {
            var p = new IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteParameter, IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteResponse> IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteParameter, IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteResponse> IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteAsync(IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteParameter, IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecompliancepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteResponse> IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteAsync(IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteParameter, IntuneDeviceconfigAndroidworkprofilecompliancepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
