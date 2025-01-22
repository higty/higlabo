using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/coachmarklocation?view=graph-rest-1.0
/// </summary>
public partial class CoachmarkLocation
{
    public enum CoachmarkLocationCoachmarkLocationType
    {
        Unknown,
        FromEmail,
        Subject,
        ExternalTag,
        DisplayName,
        MessageBody,
        UnknownFutureValue,
    }

    public Int32? Length { get; set; }
    public Int32? Offset { get; set; }
    public CoachmarkLocationCoachmarkLocationType Type { get; set; }
}
