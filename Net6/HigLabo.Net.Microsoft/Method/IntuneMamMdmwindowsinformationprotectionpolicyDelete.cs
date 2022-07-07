using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamMdmwindowsinformationprotectionpolicyDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId: return $"/deviceAppManagement/mdmWindowsInformationProtectionPolicies/{MdmWindowsInformationProtectionPolicyId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MdmWindowsInformationProtectionPolicyId { get; set; }
    }
    public partial class IntuneMamMdmwindowsinformationprotectionpolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-mdmwindowsinformationprotectionpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamMdmwindowsinformationprotectionpolicyDeleteResponse> IntuneMamMdmwindowsinformationprotectionpolicyDeleteAsync()
        {
            var p = new IntuneMamMdmwindowsinformationprotectionpolicyDeleteParameter();
            return await this.SendAsync<IntuneMamMdmwindowsinformationprotectionpolicyDeleteParameter, IntuneMamMdmwindowsinformationprotectionpolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-mdmwindowsinformationprotectionpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamMdmwindowsinformationprotectionpolicyDeleteResponse> IntuneMamMdmwindowsinformationprotectionpolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamMdmwindowsinformationprotectionpolicyDeleteParameter();
            return await this.SendAsync<IntuneMamMdmwindowsinformationprotectionpolicyDeleteParameter, IntuneMamMdmwindowsinformationprotectionpolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-mdmwindowsinformationprotectionpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamMdmwindowsinformationprotectionpolicyDeleteResponse> IntuneMamMdmwindowsinformationprotectionpolicyDeleteAsync(IntuneMamMdmwindowsinformationprotectionpolicyDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamMdmwindowsinformationprotectionpolicyDeleteParameter, IntuneMamMdmwindowsinformationprotectionpolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-mdmwindowsinformationprotectionpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamMdmwindowsinformationprotectionpolicyDeleteResponse> IntuneMamMdmwindowsinformationprotectionpolicyDeleteAsync(IntuneMamMdmwindowsinformationprotectionpolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamMdmwindowsinformationprotectionpolicyDeleteParameter, IntuneMamMdmwindowsinformationprotectionpolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
