using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/delegatedadminaccessassignment?view=graph-rest-1.0
/// </summary>
public partial class DelegatedAdminAccessAssignment
{
    public enum DelegatedAdminAccessAssignmentDelegatedAdminAccessAssignmentStatus
    {
        Pending,
        Active,
        Deleting,
        Deleted,
        Error,
        UnknownFutureValue,
    }

    public DelegatedAdminAccessContainer? AccessContainer { get; set; }
    public DelegatedAdminAccessDetails? AccessDetails { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DelegatedAdminAccessAssignmentDelegatedAdminAccessAssignmentStatus Status { get; set; }
}
