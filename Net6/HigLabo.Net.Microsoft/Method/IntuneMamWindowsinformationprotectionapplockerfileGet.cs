using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamWindowsinformationprotectionapplockerfileGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string WindowsInformationProtectionPolicyId { get; set; }
        public string WindowsInformationProtectionAppLockerFileId { get; set; }
        public string MdmWindowsInformationProtectionPolicyId { get; set; }
    }
    public partial class IntuneMamWindowsinformationprotectionapplockerfileGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileGetResponse> IntuneMamWindowsinformationprotectionapplockerfileGetAsync()
        {
            var p = new IntuneMamWindowsinformationprotectionapplockerfileGetParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileGetParameter, IntuneMamWindowsinformationprotectionapplockerfileGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileGetResponse> IntuneMamWindowsinformationprotectionapplockerfileGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamWindowsinformationprotectionapplockerfileGetParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileGetParameter, IntuneMamWindowsinformationprotectionapplockerfileGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileGetResponse> IntuneMamWindowsinformationprotectionapplockerfileGetAsync(IntuneMamWindowsinformationprotectionapplockerfileGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileGetParameter, IntuneMamWindowsinformationprotectionapplockerfileGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileGetResponse> IntuneMamWindowsinformationprotectionapplockerfileGetAsync(IntuneMamWindowsinformationprotectionapplockerfileGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileGetParameter, IntuneMamWindowsinformationprotectionapplockerfileGetResponse>(parameter, cancellationToken);
        }
    }
}
