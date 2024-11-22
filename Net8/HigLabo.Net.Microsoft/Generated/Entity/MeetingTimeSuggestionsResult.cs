using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/meetingtimesuggestionsresult?view=graph-rest-1.0
/// </summary>
public partial class MeetingTimeSuggestionsResult
{
    public string? EmptySuggestionsReason { get; set; }
    public MeetingTimeSuggestion[]? MeetingTimeSuggestions { get; set; }
}
