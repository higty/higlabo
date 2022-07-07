using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementPostAssignmentrequestsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests: return $"/identityGovernance/entitlementManagement/assignmentRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class EntitlementmanagementPostAssignmentrequestsResponse : RestApiResponse
    {
        public enum AccessPackageAssignmentRequestAccessPackageRequestType
        {
            NotSpecified,
            UserAdd,
            UserUpdate,
            UserRemove,
            AdminAdd,
            AdminUpdate,
            AdminRemove,
            SystemAdd,
            SystemUpdate,
            SystemRemove,
            OnBehalfAdd,
            UnknownFutureValue,
        }
        public enum AccessPackageAssignmentRequestAccessPackageRequestState
        {
            Submitted,
            PendingApproval,
            Delivering,
            Delivered,
            DeliveryFailed,
            Denied,
            Scheduled,
            Canceled,
            PartiallyDelivered,
            UnknownFutureValue,
        }

        public DateTimeOffset? CompletedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public AccessPackageAssignmentRequestAccessPackageRequestType RequestType { get; set; }
        public EntitlementManagementSchedule? Schedule { get; set; }
        public AccessPackageAssignmentRequestAccessPackageRequestState State { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAssignmentrequestsResponse> EntitlementmanagementPostAssignmentrequestsAsync()
        {
            var p = new EntitlementmanagementPostAssignmentrequestsParameter();
            return await this.SendAsync<EntitlementmanagementPostAssignmentrequestsParameter, EntitlementmanagementPostAssignmentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAssignmentrequestsResponse> EntitlementmanagementPostAssignmentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementPostAssignmentrequestsParameter();
            return await this.SendAsync<EntitlementmanagementPostAssignmentrequestsParameter, EntitlementmanagementPostAssignmentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAssignmentrequestsResponse> EntitlementmanagementPostAssignmentrequestsAsync(EntitlementmanagementPostAssignmentrequestsParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementPostAssignmentrequestsParameter, EntitlementmanagementPostAssignmentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostAssignmentrequestsResponse> EntitlementmanagementPostAssignmentrequestsAsync(EntitlementmanagementPostAssignmentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementPostAssignmentrequestsParameter, EntitlementmanagementPostAssignmentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
