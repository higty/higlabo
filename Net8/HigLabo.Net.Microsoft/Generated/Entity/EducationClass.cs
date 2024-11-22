using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/educationclass?view=graph-rest-1.0
/// </summary>
public partial class EducationClass
{
    public enum EducationClassEducationExternalSource
    {
        Sis,
        Manual,
    }

    public string? ClassCode { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? ExternalId { get; set; }
    public EducationClassEducationExternalSource ExternalSource { get; set; }
    public string? ExternalSourceDetail { get; set; }
    public string? ExternalName { get; set; }
    public string? Grade { get; set; }
    public string? Id { get; set; }
    public string? MailNickname { get; set; }
    public EducationTerm? Term { get; set; }
    public EducationAssignment[]? Assignments { get; set; }
    public EducationCategory[]? AssignmentCategories { get; set; }
    public EducationAssignmentDefaults[]? AssignmentDefaults { get; set; }
    public EducationAssignmentSettings[]? AssignmentSettings { get; set; }
    public Group? Group { get; set; }
    public EducationUser[]? Members { get; set; }
    public EducationSchool[]? Schools { get; set; }
    public EducationUser[]? Teachers { get; set; }
}
