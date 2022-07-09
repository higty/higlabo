using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageAssignmentrequestCancelParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackageAssignmentRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId_Cancel: return $"/identityGovernance/entitlementManagement/assignmentRequests/{AccessPackageAssignmentRequestId}/cancel";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId_Cancel,
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
    }
    public partial class AccesspackageAssignmentrequestCancelResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestCancelResponse> AccesspackageAssignmentrequestCancelAsync()
        {
            var p = new AccesspackageAssignmentrequestCancelParameter();
            return await this.SendAsync<AccesspackageAssignmentrequestCancelParameter, AccesspackageAssignmentrequestCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestCancelResponse> AccesspackageAssignmentrequestCancelAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageAssignmentrequestCancelParameter();
            return await this.SendAsync<AccesspackageAssignmentrequestCancelParameter, AccesspackageAssignmentrequestCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestCancelResponse> AccesspackageAssignmentrequestCancelAsync(AccesspackageAssignmentrequestCancelParameter parameter)
        {
            return await this.SendAsync<AccesspackageAssignmentrequestCancelParameter, AccesspackageAssignmentrequestCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestCancelResponse> AccesspackageAssignmentrequestCancelAsync(AccesspackageAssignmentrequestCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageAssignmentrequestCancelParameter, AccesspackageAssignmentrequestCancelResponse>(parameter, cancellationToken);
        }
    }
}
