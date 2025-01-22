using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-taskreportsummary?view=graph-rest-1.0
/// </summary>
public partial class TaskReportSummary
{
    public Int32? FailedTasks { get; set; }
    public Int32? SuccessfulTasks { get; set; }
    public Int32? TotalTasks { get; set; }
    public Int32? UnprocessedTasks { get; set; }
}
