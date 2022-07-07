using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementPostAssignmentpoliciesParameter : IRestApiParameter
    {
        public enum EntitlementmanagementPostAssignmentpoliciesParameterAllowedTargetScope
        {
            NotSpecified,
            SpecificDirectoryUsers,
            SpecificConnectedOrganizationUsers,
            SpecificDirectoryServicePrincipals,
            AllMemberUsers,
            AllDirectoryUsers,
            AllDirectoryServicePrincipals,
            AllConfiguredConnectedOrganizationUsers,
            AllExternalUsers,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentPolicies: return $"/identityGovernance/entitlementManagement/assignmentPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public EntitlementmanagementPostAssignmentpoliciesParameterAllowedTargetScope AllowedTargetScope { get; set; }
        public ExpirationPattern? Expiration { get; set; }
        public AccessPackageAssignmentApprovalSettings? RequestApprovalSettings { get; set; }
        public AccessPackageAssignmentRequestorSettings? RequestorSettings { get; set; }
        public AccessPackageAssignmentReviewSettings? ReviewSettings { get; set; }
        public SubjectSet[]? SpecificAllowedTargets { get; set; }
        public AccessPackage? AccessPackage { get; set; }
    }
    public partial class EntitlementmanagementPostAssignmentpoliciesResponse : RestApiResponse
    {
        public enum AccessPackageAssignmentPolicyAllowedTargetScope
        {
            NotSpecified,
            SpecificDirectoryUsers,
            SpecificConnectedOrganizationUsers,
            SpecificDirectoryServicePrincipals,
            AllMemberUsers,
            AllDirectoryUsers,
            AllDirectoryServicePrincipals,
            AllConfiguredConnectedOrganizationUsers,
            AllExternalUsers,
            UnknownFutureValue,
        }

        public AccessPackageAssignmentPolicyAllowedTargetScope AllowedTargetScope { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public ExpirationPattern? Expiration { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public AccessPackageAssignmentApprovalSettings? RequestApprovalSettings { get; set; }
        public AccessPackageAssignmentRequestorSettings? RequestorSettings { get; set; }
        public AccessPackageAssignmentReviewSettings? ReviewSettings { get; set; }
        public SubjectSet[]? SpecificAllowedTargets { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAssignmentpoliciesResponse> EntitlementmanagementPostAssignmentpoliciesAsync()
        {
            var p = new EntitlementmanagementPostAssignmentpoliciesParameter();
            return await this.SendAsync<EntitlementmanagementPostAssignmentpoliciesParameter, EntitlementmanagementPostAssignmentpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAssignmentpoliciesResponse> EntitlementmanagementPostAssignmentpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementPostAssignmentpoliciesParameter();
            return await this.SendAsync<EntitlementmanagementPostAssignmentpoliciesParameter, EntitlementmanagementPostAssignmentpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAssignmentpoliciesResponse> EntitlementmanagementPostAssignmentpoliciesAsync(EntitlementmanagementPostAssignmentpoliciesParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementPostAssignmentpoliciesParameter, EntitlementmanagementPostAssignmentpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAssignmentpoliciesResponse> EntitlementmanagementPostAssignmentpoliciesAsync(EntitlementmanagementPostAssignmentpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementPostAssignmentpoliciesParameter, EntitlementmanagementPostAssignmentpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
