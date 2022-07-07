using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageGetapplicablepolicyrequirementsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_AccessPackageId_GetApplicablePolicyRequirements,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_AccessPackageId_GetApplicablePolicyRequirements: return $"/identityGovernance/entitlementManagement/accessPackages/{AccessPackageId}/getApplicablePolicyRequirements";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string AccessPackageId { get; set; }
    }
    public partial class AccesspackageGetapplicablepolicyrequirementsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accesspackageassignmentrequestrequirements?view=graph-rest-1.0
        /// </summary>
        public partial class AccessPackageAssignmentRequestRequirements
        {
            public bool? AllowCustomAssignmentSchedule { get; set; }
            public bool? IsApprovalRequiredForAdd { get; set; }
            public bool? IsApprovalRequiredForUpdate { get; set; }
            public string? PolicyDescription { get; set; }
            public string? PolicyDisplayName { get; set; }
            public string? PolicyId { get; set; }
            public EntitlementManagementSchedule? Schedule { get; set; }
        }

        public AccessPackageAssignmentRequestRequirements[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageGetapplicablepolicyrequirementsResponse> AccesspackageGetapplicablepolicyrequirementsAsync()
        {
            var p = new AccesspackageGetapplicablepolicyrequirementsParameter();
            return await this.SendAsync<AccesspackageGetapplicablepolicyrequirementsParameter, AccesspackageGetapplicablepolicyrequirementsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageGetapplicablepolicyrequirementsResponse> AccesspackageGetapplicablepolicyrequirementsAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageGetapplicablepolicyrequirementsParameter();
            return await this.SendAsync<AccesspackageGetapplicablepolicyrequirementsParameter, AccesspackageGetapplicablepolicyrequirementsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageGetapplicablepolicyrequirementsResponse> AccesspackageGetapplicablepolicyrequirementsAsync(AccesspackageGetapplicablepolicyrequirementsParameter parameter)
        {
            return await this.SendAsync<AccesspackageGetapplicablepolicyrequirementsParameter, AccesspackageGetapplicablepolicyrequirementsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageGetapplicablepolicyrequirementsResponse> AccesspackageGetapplicablepolicyrequirementsAsync(AccesspackageGetapplicablepolicyrequirementsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageGetapplicablepolicyrequirementsParameter, AccesspackageGetapplicablepolicyrequirementsResponse>(parameter, cancellationToken);
        }
    }
}
