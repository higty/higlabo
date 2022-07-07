using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamWindowsinformationprotectionpolicyDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId: return $"/deviceAppManagement/windowsInformationProtectionPolicies/{WindowsInformationProtectionPolicyId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string WindowsInformationProtectionPolicyId { get; set; }
    }
    public partial class IntuneMamWindowsinformationprotectionpolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyDeleteResponse> IntuneMamWindowsinformationprotectionpolicyDeleteAsync()
        {
            var p = new IntuneMamWindowsinformationprotectionpolicyDeleteParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyDeleteParameter, IntuneMamWindowsinformationprotectionpolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyDeleteResponse> IntuneMamWindowsinformationprotectionpolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamWindowsinformationprotectionpolicyDeleteParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyDeleteParameter, IntuneMamWindowsinformationprotectionpolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyDeleteResponse> IntuneMamWindowsinformationprotectionpolicyDeleteAsync(IntuneMamWindowsinformationprotectionpolicyDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyDeleteParameter, IntuneMamWindowsinformationprotectionpolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyDeleteResponse> IntuneMamWindowsinformationprotectionpolicyDeleteAsync(IntuneMamWindowsinformationprotectionpolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyDeleteParameter, IntuneMamWindowsinformationprotectionpolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
