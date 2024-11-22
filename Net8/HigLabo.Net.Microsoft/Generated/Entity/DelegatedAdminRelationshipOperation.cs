using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/delegatedadminrelationshipoperation?view=graph-rest-1.0
/// </summary>
public partial class DelegatedAdminRelationshipOperation
{
    public enum DelegatedAdminRelationshipOperationDelegatedAdminRelationshipOperationType
    {
        DelegatedAdminAccessAssignmentUpdate,
        UnknownFutureValue,
    }
    public enum DelegatedAdminRelationshipOperationLongRunningOperationStatus
    {
        NotStarted,
        Running,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Data { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DelegatedAdminRelationshipOperationDelegatedAdminRelationshipOperationType OperationType { get; set; }
    public DelegatedAdminRelationshipOperationLongRunningOperationStatus Status { get; set; }
}
