using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/delegatedadminrelationshiprequest?view=graph-rest-1.0
/// </summary>
public partial class DelegatedAdminRelationshipRequest
{
    public enum DelegatedAdminRelationshipRequestDelegatedAdminRelationshipRequestStatus
    {
        Created,
        Pending,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }

    public DelegatedAdminRelationshipRequestAction? Action { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DelegatedAdminRelationshipRequestDelegatedAdminRelationshipRequestStatus Status { get; set; }
}
