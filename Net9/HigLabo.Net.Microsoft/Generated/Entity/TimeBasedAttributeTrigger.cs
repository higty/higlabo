using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-timebasedattributetrigger?view=graph-rest-1.0
/// </summary>
public partial class TimeBasedAttributeTrigger
{
    public enum TimeBasedAttributeTriggerIdentityGovernanceWorkflowTriggerTimeBasedAttribute
    {
        EmployeeHireDate,
        EmployeeLeaveDateTime,
        CreatedDateTime,
        UnknownFutureValue,
    }

    public Int32? OffsetInDays { get; set; }
    public TimeBasedAttributeTriggerIdentityGovernanceWorkflowTriggerTimeBasedAttribute TimeBasedAttribute { get; set; }
}
