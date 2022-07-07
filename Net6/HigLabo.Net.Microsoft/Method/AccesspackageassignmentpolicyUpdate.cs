using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageassignmentpolicyUpdateParameter : IRestApiParameter
    {
        public enum AccesspackageassignmentpolicyUpdateParameterAllowedTargetScope
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
            IdentityGovernance_EntitlementManagement_AssignmentPolicies_AccessPackageAssignmentPolicyId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentPolicies_AccessPackageAssignmentPolicyId: return $"/identityGovernance/entitlementManagement/assignmentPolicies/{AccessPackageAssignmentPolicyId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public AccesspackageassignmentpolicyUpdateParameterAllowedTargetScope AllowedTargetScope { get; set; }
        public SubjectSet[]? SpecificAllowedTargets { get; set; }
        public ExpirationPattern? Expiration { get; set; }
        public AccessPackageAssignmentRequestorSettings? RequestorSettings { get; set; }
        public AccessPackageAssignmentApprovalSettings? RequestApprovalSettings { get; set; }
        public AccessPackageAssignmentReviewSettings? ReviewSettings { get; set; }
        public string AccessPackageAssignmentPolicyId { get; set; }
    }
    public partial class AccesspackageassignmentpolicyUpdateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyUpdateResponse> AccesspackageassignmentpolicyUpdateAsync()
        {
            var p = new AccesspackageassignmentpolicyUpdateParameter();
            return await this.SendAsync<AccesspackageassignmentpolicyUpdateParameter, AccesspackageassignmentpolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyUpdateResponse> AccesspackageassignmentpolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageassignmentpolicyUpdateParameter();
            return await this.SendAsync<AccesspackageassignmentpolicyUpdateParameter, AccesspackageassignmentpolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyUpdateResponse> AccesspackageassignmentpolicyUpdateAsync(AccesspackageassignmentpolicyUpdateParameter parameter)
        {
            return await this.SendAsync<AccesspackageassignmentpolicyUpdateParameter, AccesspackageassignmentpolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyUpdateResponse> AccesspackageassignmentpolicyUpdateAsync(AccesspackageassignmentpolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageassignmentpolicyUpdateParameter, AccesspackageassignmentpolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
