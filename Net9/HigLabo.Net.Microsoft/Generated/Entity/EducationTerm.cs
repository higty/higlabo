using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/educationterm?view=graph-rest-1.0
/// </summary>
public partial class EducationTerm
{
    public string? DisplayName { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? ExternalId { get; set; }
    public DateOnly? StartDate { get; set; }
}
