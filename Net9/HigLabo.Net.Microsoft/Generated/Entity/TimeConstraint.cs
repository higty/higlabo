using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/timeconstraint?view=graph-rest-1.0
/// </summary>
public partial class TimeConstraint
{
    public enum TimeConstraintActivityDomain
    {
        Work,
        Personal,
        Unrestricted,
        Unknown,
    }

    public TimeConstraintActivityDomain ActivityDomain { get; set; }
    public TimeSlot[]? Timeslots { get; set; }
}
