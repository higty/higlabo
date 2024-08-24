using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-delete?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentRequestDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackageAssignmentRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId: return $"/identityGovernance/entitlementManagement/assignmentRequests/{AccessPackageAssignmentRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId,
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
    public partial class AccessPackageAssignmentRequestDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentRequestDeleteResponse> AccessPackageAssignmentRequestDeleteAsync()
        {
            var p = new AccessPackageAssignmentRequestDeleteParameter();
            return await this.SendAsync<AccessPackageAssignmentRequestDeleteParameter, AccessPackageAssignmentRequestDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentRequestDeleteResponse> AccessPackageAssignmentRequestDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageAssignmentRequestDeleteParameter();
            return await this.SendAsync<AccessPackageAssignmentRequestDeleteParameter, AccessPackageAssignmentRequestDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentRequestDeleteResponse> AccessPackageAssignmentRequestDeleteAsync(AccessPackageAssignmentRequestDeleteParameter parameter)
        {
            return await this.SendAsync<AccessPackageAssignmentRequestDeleteParameter, AccessPackageAssignmentRequestDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentRequestDeleteResponse> AccessPackageAssignmentRequestDeleteAsync(AccessPackageAssignmentRequestDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageAssignmentRequestDeleteParameter, AccessPackageAssignmentRequestDeleteResponse>(parameter, cancellationToken);
        }
    }
}
