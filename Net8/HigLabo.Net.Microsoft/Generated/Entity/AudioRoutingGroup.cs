using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/audioroutinggroup?view=graph-rest-1.0
/// </summary>
public partial class AudioRoutingGroup
{
    public enum AudioRoutingGroupstring
    {
        OneToOne,
        Multicast,
    }

    public string? Id { get; set; }
    public string[]? Receivers { get; set; }
    public AudioRoutingGroupstring RoutingMode { get; set; }
    public string[]? Sources { get; set; }
}
