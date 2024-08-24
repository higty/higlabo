using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentPolicyDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class AccessPackageAssignmentPolicyDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentPolicyDeleteResponse> AccessPackageAssignmentPolicyDeleteAsync()
        {
            var p = new AccessPackageAssignmentPolicyDeleteParameter();
            return await this.SendAsync<AccessPackageAssignmentPolicyDeleteParameter, AccessPackageAssignmentPolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentPolicyDeleteResponse> AccessPackageAssignmentPolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageAssignmentPolicyDeleteParameter();
            return await this.SendAsync<AccessPackageAssignmentPolicyDeleteParameter, AccessPackageAssignmentPolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentPolicyDeleteResponse> AccessPackageAssignmentPolicyDeleteAsync(AccessPackageAssignmentPolicyDeleteParameter parameter)
        {
            return await this.SendAsync<AccessPackageAssignmentPolicyDeleteParameter, AccessPackageAssignmentPolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentPolicyDeleteResponse> AccessPackageAssignmentPolicyDeleteAsync(AccessPackageAssignmentPolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageAssignmentPolicyDeleteParameter, AccessPackageAssignmentPolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
