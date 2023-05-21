using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageassignment?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignment
    {
        public enum AccessPackageAssignmentAccessPackageAssignmentState
        {
            Delivering,
            PartiallyDelivered,
            Delivered,
            Expired,
            DeliveryFailed,
            UnknownFutureValue,
            Eq,
        }

        public DateTimeOffset? ExpiredDateTime { get; set; }
        public string? Id { get; set; }
        public EntitlementManagementSchedule? Schedule { get; set; }
        public AccessPackageAssignmentAccessPackageAssignmentState State { get; set; }
        public string? Status { get; set; }
        public AccessPackage? AccessPackage { get; set; }
        public AccessPackageSubject? Target { get; set; }
        public AccessPackageAssignmentPolicy? AssignmentPolicy { get; set; }
    }
}
