using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamWindowsinformationprotectionapplockerfileCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_ExemptAppLockerFiles,
            DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_ProtectedAppLockerFiles,
            DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_ExemptAppLockerFiles,
            DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_ProtectedAppLockerFiles,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_ExemptAppLockerFiles: return $"/deviceAppManagement/windowsInformationProtectionPolicies/{WindowsInformationProtectionPolicyId}/exemptAppLockerFiles";
                    case ApiPath.DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId_ProtectedAppLockerFiles: return $"/deviceAppManagement/windowsInformationProtectionPolicies/{WindowsInformationProtectionPolicyId}/protectedAppLockerFiles";
                    case ApiPath.DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_ExemptAppLockerFiles: return $"/deviceAppManagement/mdmWindowsInformationProtectionPolicies/{MdmWindowsInformationProtectionPolicyId}/exemptAppLockerFiles";
                    case ApiPath.DeviceAppManagement_MdmWindowsInformationProtectionPolicies_MdmWindowsInformationProtectionPolicyId_ProtectedAppLockerFiles: return $"/deviceAppManagement/mdmWindowsInformationProtectionPolicies/{MdmWindowsInformationProtectionPolicyId}/protectedAppLockerFiles";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? FileHash { get; set; }
        public string? File { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public string WindowsInformationProtectionPolicyId { get; set; }
        public string MdmWindowsInformationProtectionPolicyId { get; set; }
    }
    public partial class IntuneMamWindowsinformationprotectionapplockerfileCreateResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? FileHash { get; set; }
        public string? File { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileCreateResponse> IntuneMamWindowsinformationprotectionapplockerfileCreateAsync()
        {
            var p = new IntuneMamWindowsinformationprotectionapplockerfileCreateParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileCreateParameter, IntuneMamWindowsinformationprotectionapplockerfileCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileCreateResponse> IntuneMamWindowsinformationprotectionapplockerfileCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamWindowsinformationprotectionapplockerfileCreateParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileCreateParameter, IntuneMamWindowsinformationprotectionapplockerfileCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileCreateResponse> IntuneMamWindowsinformationprotectionapplockerfileCreateAsync(IntuneMamWindowsinformationprotectionapplockerfileCreateParameter parameter)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileCreateParameter, IntuneMamWindowsinformationprotectionapplockerfileCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileCreateResponse> IntuneMamWindowsinformationprotectionapplockerfileCreateAsync(IntuneMamWindowsinformationprotectionapplockerfileCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileCreateParameter, IntuneMamWindowsinformationprotectionapplockerfileCreateResponse>(parameter, cancellationToken);
        }
    }
}
