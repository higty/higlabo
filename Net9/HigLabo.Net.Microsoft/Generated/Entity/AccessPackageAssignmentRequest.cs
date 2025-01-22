using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageassignmentrequest?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageAssignmentRequest
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
