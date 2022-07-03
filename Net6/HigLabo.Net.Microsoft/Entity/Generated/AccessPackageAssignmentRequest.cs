using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/accesspackageassignmentrequest?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentRequest
    {
        public DateTimeOffset CompletedDateTime { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Id { get; set; }
        public AccessPackageAssignmentRequestAccessPackageRequestType RequestType { get; set; }
        public EntitlementManagementSchedule? Schedule { get; set; }
        public AccessPackageAssignmentRequestAccessPackageRequestState State { get; set; }
        public string Status { get; set; }
    }
}
