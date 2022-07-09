using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageAssignmentPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackageAssignmentPolicyId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentPolicies_AccessPackageAssignmentPolicyId: return $"/identityGovernance/entitlementManagement/assignmentPolicies/{AccessPackageAssignmentPolicyId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum AccesspackageAssignmentPolicyUpdateParameterAllowedTargetScope
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

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public AccesspackageAssignmentPolicyUpdateParameterAllowedTargetScope AllowedTargetScope { get; set; }
        public SubjectSet[]? SpecificAllowedTargets { get; set; }
        public ExpirationPattern? Expiration { get; set; }
        public AccessPackageAssignmentRequestorSettings? RequestorSettings { get; set; }
        public AccessPackageAssignmentApprovalSettings? RequestApprovalSettings { get; set; }
        public AccessPackageAssignmentReviewSettings? ReviewSettings { get; set; }
    }
    public partial class AccesspackageAssignmentPolicyUpdateResponse : RestApiResponse
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
        public AccessPackage? AccessPackage { get; set; }
        public AccessPackageCatalog? Catalog { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentPolicyUpdateResponse> AccesspackageAssignmentPolicyUpdateAsync()
        {
            var p = new AccesspackageAssignmentPolicyUpdateParameter();
            return await this.SendAsync<AccesspackageAssignmentPolicyUpdateParameter, AccesspackageAssignmentPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentPolicyUpdateResponse> AccesspackageAssignmentPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageAssignmentPolicyUpdateParameter();
            return await this.SendAsync<AccesspackageAssignmentPolicyUpdateParameter, AccesspackageAssignmentPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentPolicyUpdateResponse> AccesspackageAssignmentPolicyUpdateAsync(AccesspackageAssignmentPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<AccesspackageAssignmentPolicyUpdateParameter, AccesspackageAssignmentPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentPolicyUpdateResponse> AccesspackageAssignmentPolicyUpdateAsync(AccesspackageAssignmentPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageAssignmentPolicyUpdateParameter, AccesspackageAssignmentPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
