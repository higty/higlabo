using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-lifecyclemanagementsettings?view=graph-rest-1.0
/// </summary>
public partial class LifecycleManagementSettings
{
    public Int32? WorkflowScheduleIntervalInHours { get; set; }
    public EmailSettings? EmailSettings { get; set; }
}
