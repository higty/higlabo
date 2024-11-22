using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-runsummary?view=graph-rest-1.0
/// </summary>
public partial class RunSummary
{
    public Int32? FailedRuns { get; set; }
    public Int32? FailedTasks { get; set; }
    public Int32? SuccessfulRuns { get; set; }
    public Int32? TotalRuns { get; set; }
    public Int32? TotalTasks { get; set; }
    public Int32? TotalUsers { get; set; }
}
