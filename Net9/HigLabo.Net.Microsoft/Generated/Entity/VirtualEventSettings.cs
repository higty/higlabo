using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/virtualeventsettings?view=graph-rest-1.0
/// </summary>
public partial class VirtualEventSettings
{
    public bool? IsAttendeeEmailNotificationEnabled { get; set; }
    public VirtualEvent? VirtualEvents { get; set; }
}
