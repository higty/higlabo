using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementPostAssignmentpoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentPolicies: return $"/identityGovernance/entitlementManagement/assignmentPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EntitlementManagementPostAssignmentpoliciesParameterAllowedTargetScope
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
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentPolicies,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public EntitlementManagementPostAssignmentpoliciesParameterAllowedTargetScope AllowedTargetScope { get; set; }
        public ExpirationPattern? Expiration { get; set; }
        public AccessPackageAssignmentApprovalSettings? RequestApprovalSettings { get; set; }
        public AccessPackageAssignmentRequestorSettings? RequestorSettings { get; set; }
        public AccessPackageAssignmentReviewSettings? ReviewSettings { get; set; }
        public SubjectSet[]? SpecificAllowedTargets { get; set; }
        public AccessPackageAutomaticRequestSettings? AutomaticRequestSettings { get; set; }
        public AccessPackage? AccessPackage { get; set; }
        public AccessPackageQuestion[]? Questions { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public AccessPackageCatalog? Catalog { get; set; }
    }
    public partial class EntitlementManagementPostAssignmentpoliciesResponse : RestApiResponse
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
        public AccessPackageAutomaticRequestSettings? AutomaticRequestSettings { get; set; }
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
        public AccessPackageQuestion[]? Questions { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAssignmentpoliciesResponse> EntitlementManagementPostAssignmentpoliciesAsync()
        {
            var p = new EntitlementManagementPostAssignmentpoliciesParameter();
            return await this.SendAsync<EntitlementManagementPostAssignmentpoliciesParameter, EntitlementManagementPostAssignmentpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAssignmentpoliciesResponse> EntitlementManagementPostAssignmentpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementPostAssignmentpoliciesParameter();
            return await this.SendAsync<EntitlementManagementPostAssignmentpoliciesParameter, EntitlementManagementPostAssignmentpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAssignmentpoliciesResponse> EntitlementManagementPostAssignmentpoliciesAsync(EntitlementManagementPostAssignmentpoliciesParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementPostAssignmentpoliciesParameter, EntitlementManagementPostAssignmentpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAssignmentpoliciesResponse> EntitlementManagementPostAssignmentpoliciesAsync(EntitlementManagementPostAssignmentpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementPostAssignmentpoliciesParameter, EntitlementManagementPostAssignmentpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
