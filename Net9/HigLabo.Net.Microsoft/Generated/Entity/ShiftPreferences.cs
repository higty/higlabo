using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/shiftpreferences?view=graph-rest-1.0
/// </summary>
public partial class ShiftPreferences
{
    public ShiftAvailability[]? Availability { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public String? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
}
