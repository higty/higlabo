using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/educationsubmissionresource?view=graph-rest-1.0
/// </summary>
public partial class EducationSubmissionResource
{
    public string? AssignmentResourceUrl { get; set; }
    public string? Id { get; set; }
    public EducationResource? Resource { get; set; }
}
