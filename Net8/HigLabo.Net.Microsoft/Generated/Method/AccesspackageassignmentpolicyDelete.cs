using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackageAssignmentPolicyDeleteParameter : IRestApiParameter
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
    public partial class AccesspackageAssignmentPolicyDeleteResponse : RestApiResponse
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
        public async ValueTask<AccesspackageAssignmentPolicyDeleteResponse> AccesspackageAssignmentPolicyDeleteAsync()
        {
            var p = new AccesspackageAssignmentPolicyDeleteParameter();
            return await this.SendAsync<AccesspackageAssignmentPolicyDeleteParameter, AccesspackageAssignmentPolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageAssignmentPolicyDeleteResponse> AccesspackageAssignmentPolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageAssignmentPolicyDeleteParameter();
            return await this.SendAsync<AccesspackageAssignmentPolicyDeleteParameter, AccesspackageAssignmentPolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageAssignmentPolicyDeleteResponse> AccesspackageAssignmentPolicyDeleteAsync(AccesspackageAssignmentPolicyDeleteParameter parameter)
        {
            return await this.SendAsync<AccesspackageAssignmentPolicyDeleteParameter, AccesspackageAssignmentPolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageAssignmentPolicyDeleteResponse> AccesspackageAssignmentPolicyDeleteAsync(AccesspackageAssignmentPolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageAssignmentPolicyDeleteParameter, AccesspackageAssignmentPolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
