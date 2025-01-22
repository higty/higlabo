using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-usersummary?view=graph-rest-1.0
/// </summary>
public partial class UserSummary
{
    public Int32? FailedTasks { get; set; }
    public Int32? FailedUsers { get; set; }
    public Int32? SuccessfulUsers { get; set; }
    public Int32? TotalTasks { get; set; }
    public Int32? TotalUsers { get; set; }
}
