using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-fileplandescriptor?view=graph-rest-1.0
/// </summary>
public partial class FilePlanDescriptor
{
    public FilePlanAuthority? Authority { get; set; }
    public FilePlanAppliedCategory? AppliedCategory { get; set; }
    public FilePlanCitation? Citation { get; set; }
    public FilePlanDepartment? Department { get; set; }
    public FilePlanReference? FilePlanReference { get; set; }
    public AuthorityTemplate? AuthorityTemplate { get; set; }
    public CategoryTemplate? CategoryTemplate { get; set; }
    public CitationTemplate? CitationTemplate { get; set; }
    public DepartmentTemplate? DepartmentTemplate { get; set; }
    public FilePlanReferenceTemplate? FilePlanReferenceTemplate { get; set; }
}
