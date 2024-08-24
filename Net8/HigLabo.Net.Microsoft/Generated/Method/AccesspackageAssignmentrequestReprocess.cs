using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-reprocess?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentRequestReprocessParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_Id_Reprocess: return $"/identityGovernance/entitlementManagement/assignmentRequests/{Id}/reprocess";
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
            IdentityGovernance_EntitlementManagement_AssignmentRequests_Id_Reprocess,
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
    public partial class AccessPackageAssignmentRequestReprocessResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-reprocess?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-reprocess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentRequestReprocessResponse> AccessPackageAssignmentRequestReprocessAsync()
        {
            var p = new AccessPackageAssignmentRequestReprocessParameter();
            return await this.SendAsync<AccessPackageAssignmentRequestReprocessParameter, AccessPackageAssignmentRequestReprocessResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-reprocess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentRequestReprocessResponse> AccessPackageAssignmentRequestReprocessAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageAssignmentRequestReprocessParameter();
            return await this.SendAsync<AccessPackageAssignmentRequestReprocessParameter, AccessPackageAssignmentRequestReprocessResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-reprocess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentRequestReprocessResponse> AccessPackageAssignmentRequestReprocessAsync(AccessPackageAssignmentRequestReprocessParameter parameter)
        {
            return await this.SendAsync<AccessPackageAssignmentRequestReprocessParameter, AccessPackageAssignmentRequestReprocessResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-reprocess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentRequestReprocessResponse> AccessPackageAssignmentRequestReprocessAsync(AccessPackageAssignmentRequestReprocessParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageAssignmentRequestReprocessParameter, AccessPackageAssignmentRequestReprocessResponse>(parameter, cancellationToken);
        }
    }
}
