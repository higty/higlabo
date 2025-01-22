using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/audioconferencing?view=graph-rest-1.0
/// </summary>
public partial class AudioConferencing
{
    public string? ConferenceId { get; set; }
    public string? DialinUrl { get; set; }
    public String[]? TollFreeNumbers { get; set; }
    public String[]? TollNumbers { get; set; }
}
