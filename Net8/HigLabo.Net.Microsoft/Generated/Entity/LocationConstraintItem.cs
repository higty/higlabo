using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/locationconstraintitem?view=graph-rest-1.0
/// </summary>
public partial class LocationConstraintItem
{
    public PhysicalAddress? Address { get; set; }
    public string? DisplayName { get; set; }
    public string? LocationEmailAddress { get; set; }
    public bool? ResolveAvailability { get; set; }
}
