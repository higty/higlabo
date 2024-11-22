using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/outgoingcalloptions?view=graph-rest-1.0
/// </summary>
public partial class OutgoingCallOptions
{
    public bool? HideBotAfterEscalation { get; set; }
    public bool? IsContentSharingNotificationEnabled { get; set; }
}
