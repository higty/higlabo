using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementPostAssignmentrequestsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests: return $"/identityGovernance/entitlementManagement/assignmentRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum AccessPackageAssignmentRequestAccessPackageRequestType
        {
            NotSpecified,
            UserAdd,
            UserExtend,
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
            Eq,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests,
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
        public AccessPackageAnswer[]? Answers { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public AccessPackageAssignmentRequestAccessPackageRequestType RequestType { get; set; }
        public EntitlementManagementSchedule? Schedule { get; set; }
        public AccessPackageAssignmentRequestAccessPackageRequestState State { get; set; }
        public string? Status { get; set; }
        public AccessPackage? AccessPackage { get; set; }
        public AccessPackageAssignment? Assignment { get; set; }
        public AccessPackageSubject? Requestor { get; set; }
    }
    public partial class EntitlementManagementPostAssignmentrequestsResponse : RestApiResponse
    {
        public enum AccessPackageAssignmentRequestAccessPackageRequestType
        {
            NotSpecified,
            UserAdd,
            UserExtend,
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
            Eq,
        }

        public AccessPackageAnswer[]? Answers { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public AccessPackageAssignmentRequestAccessPackageRequestType RequestType { get; set; }
        public EntitlementManagementSchedule? Schedule { get; set; }
        public AccessPackageAssignmentRequestAccessPackageRequestState State { get; set; }
        public string? Status { get; set; }
        public AccessPackage? AccessPackage { get; set; }
        public AccessPackageAssignment? Assignment { get; set; }
        public AccessPackageSubject? Requestor { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAssignmentrequestsResponse> EntitlementManagementPostAssignmentrequestsAsync()
        {
            var p = new EntitlementManagementPostAssignmentrequestsParameter();
            return await this.SendAsync<EntitlementManagementPostAssignmentrequestsParameter, EntitlementManagementPostAssignmentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAssignmentrequestsResponse> EntitlementManagementPostAssignmentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementPostAssignmentrequestsParameter();
            return await this.SendAsync<EntitlementManagementPostAssignmentrequestsParameter, EntitlementManagementPostAssignmentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAssignmentrequestsResponse> EntitlementManagementPostAssignmentrequestsAsync(EntitlementManagementPostAssignmentrequestsParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementPostAssignmentrequestsParameter, EntitlementManagementPostAssignmentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAssignmentrequestsResponse> EntitlementManagementPostAssignmentrequestsAsync(EntitlementManagementPostAssignmentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementPostAssignmentrequestsParameter, EntitlementManagementPostAssignmentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
