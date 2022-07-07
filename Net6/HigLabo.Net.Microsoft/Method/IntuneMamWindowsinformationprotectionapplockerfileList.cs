using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamWindowsinformationprotectionapplockerfileListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string MdmWindowsInformationProtectionPolicyId { get; set; }
    }
    public partial class IntuneMamWindowsinformationprotectionapplockerfileListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-windowsinformationprotectionapplockerfile?view=graph-rest-1.0
        /// </summary>
        public partial class WindowsInformationProtectionAppLockerFile
        {
            public string? DisplayName { get; set; }
            public string? FileHash { get; set; }
            public string? File { get; set; }
            public string? Id { get; set; }
            public string? Version { get; set; }
        }

        public WindowsInformationProtectionAppLockerFile[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileListResponse> IntuneMamWindowsinformationprotectionapplockerfileListAsync()
        {
            var p = new IntuneMamWindowsinformationprotectionapplockerfileListParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileListParameter, IntuneMamWindowsinformationprotectionapplockerfileListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileListResponse> IntuneMamWindowsinformationprotectionapplockerfileListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamWindowsinformationprotectionapplockerfileListParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileListParameter, IntuneMamWindowsinformationprotectionapplockerfileListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileListResponse> IntuneMamWindowsinformationprotectionapplockerfileListAsync(IntuneMamWindowsinformationprotectionapplockerfileListParameter parameter)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileListParameter, IntuneMamWindowsinformationprotectionapplockerfileListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionapplockerfile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionapplockerfileListResponse> IntuneMamWindowsinformationprotectionapplockerfileListAsync(IntuneMamWindowsinformationprotectionapplockerfileListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionapplockerfileListParameter, IntuneMamWindowsinformationprotectionapplockerfileListResponse>(parameter, cancellationToken);
        }
    }
}
