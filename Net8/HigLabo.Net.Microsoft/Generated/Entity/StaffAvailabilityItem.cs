using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/staffavailabilityitem?view=graph-rest-1.0
/// </summary>
public partial class StaffAvailabilityItem
{
    public AvailabilityItem[]? AvailabilityItems { get; set; }
    public string? StaffId { get; set; }
}
