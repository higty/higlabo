using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamWindowsinformationprotectionapplockerfileDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_ExemptAppLockerFiles_WindowsInformationProtectionAppLockerFileId,
            DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_ProtectedAppLockerFiles_WindowsInformationProtectionAppLockerFileId,
            DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_ExemptAppLockerFiles_WindowsInformationProtectionAppLockerFileId,
            DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_ProtectedAppLockerFiles_WindowsInformationProtectionAppLockerFileId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_ExemptAppLockerFiles_WindowsInformationProtectionAppLockerFileId: return $"/deviceAppManagement/windowsInformationProtectionPolicies/{WindowsInformationProtectionPolicyId}/exemptAppLockerFiles/{WindowsInformationProtectionAppLockerFileId}";
                    case ApiPath.DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_ProtectedAppLockerFiles_WindowsInformationProtectionAppLockerFileId: return $"/deviceAppManagement/windowsInformationProtectionPolicies/{WindowsInformationProtectionPolicyId}/protectedAppLockerFiles/{WindowsInformationProtectionAppLockerFileId}";
                    case ApiPath.DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_ExemptAppLockerFiles_WindowsInformationProtectionAppLockerFileId: return $"/deviceAppManagement/mdmWindowsInformationProtectionPolicies/{MdmWindowsInformationProtectionPolicyId}/exemptAppLockerFiles/{WindowsInformationProtectionAppLockerFileId}";
                    case ApiPath.DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_ProtectedAppLockerFiles_WindowsInformationProtectionAppLockerFileId: return $"/deviceAppManagement/mdmWindowsInformationProtectionPolicies/{MdmWindowsInformationProtectionPolicyId}/protectedAppLockerFiles/{WindowsInformationProtectionAppLockerFileId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string WindowsInformationProtectionPolicyId { get; set; }
        public string WindowsInformationProtectionAppLockerFileId { get; set; }
        public string MdmWindowsInformationProtectionPolicyId { get; set; }
    }
    public partial class IntuneMamWindowsinformationprotectionapplockerfileDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileDeleteResponse> IntuneMamWindowsinformationprotectionapplockerfileDeleteAsync()
        {
            var p = new IntuneMamWindowsinformationprotectionapplockerfileDeleteParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileDeleteParameter, IntuneMamWindowsinformationprotectionapplockerfileDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileDeleteResponse> IntuneMamWindowsinformationprotectionapplockerfileDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamWindowsinformationprotectionapplockerfileDeleteParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileDeleteParameter, IntuneMamWindowsinformationprotectionapplockerfileDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileDeleteResponse> IntuneMamWindowsinformationprotectionapplockerfileDeleteAsync(IntuneMamWindowsinformationprotectionapplockerfileDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileDeleteParameter, IntuneMamWindowsinformationprotectionapplockerfileDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileDeleteResponse> IntuneMamWindowsinformationprotectionapplockerfileDeleteAsync(IntuneMamWindowsinformationprotectionapplockerfileDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileDeleteParameter, IntuneMamWindowsinformationprotectionapplockerfileDeleteResponse>(parameter, cancellationToken);
        }
    }
}
