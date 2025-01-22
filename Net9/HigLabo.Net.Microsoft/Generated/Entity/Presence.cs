using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/presence?view=graph-rest-1.0
/// </summary>
public partial class Presence
{
    public enum Presencestring
    {
        Available,
        Away,
        BeRightBack,
        Busy,
        DoNotDisturb,
        InACall,
        InAConferenceCall,
        Inactive,
        InAMeeting,
        Offline,
        OffWork,
        OutOfOffice,
        PresenceUnknown,
        Presenting,
        UrgentInterruptionsOnly,
    }

    public Presencestring Activity { get; set; }
    public Presencestring Availability { get; set; }
    public string? Id { get; set; }
}
