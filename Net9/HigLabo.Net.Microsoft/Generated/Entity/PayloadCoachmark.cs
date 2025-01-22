using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/payloadcoachmark?view=graph-rest-1.0
/// </summary>
public partial class PayloadCoachmark
{
    public CoachmarkLocation? CoachmarkLocation { get; set; }
    public string? Description { get; set; }
    public string? Indicator { get; set; }
    public bool? IsValid { get; set; }
    public string? Language { get; set; }
    public string? Order { get; set; }
}
