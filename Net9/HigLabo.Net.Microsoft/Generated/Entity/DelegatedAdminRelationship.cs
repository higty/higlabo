using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/delegatedadminrelationship?view=graph-rest-1.0
/// </summary>
public partial class DelegatedAdminRelationship
{
    public enum DelegatedAdminRelationshipDelegatedAdminRelationshipStatus
    {
        Activating,
        Active,
        ApprovalPending,
        Approved,
        Created,
        Expired,
        Expiring,
        Terminated,
        Terminating,
        TerminationRequested,
        UnknownFutureValue,
    }

    public DelegatedAdminAccessDetails? AccessDetails { get; set; }
    public DateTimeOffset? ActivatedDateTime { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public DelegatedAdminRelationshipCustomerParticipant? Customer { get; set; }
    public string? DisplayName { get; set; }
    public string? Duration { get; set; }
    public DateTimeOffset? EndDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DelegatedAdminRelationshipDelegatedAdminRelationshipStatus Status { get; set; }
    public DelegatedAdminAccessAssignment[]? AccessAssignments { get; set; }
    public DelegatedAdminRelationshipOperation[]? Operations { get; set; }
    public DelegatedAdminRelationshipRequest[]? Requests { get; set; }
}
