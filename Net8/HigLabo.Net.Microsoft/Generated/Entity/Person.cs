using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/person?view=graph-rest-1.0
/// </summary>
public partial class Person
{
    public string? Birthday { get; set; }
    public string? CompanyName { get; set; }
    public string? Department { get; set; }
    public string? DisplayName { get; set; }
    public string? GivenName { get; set; }
    public string? Id { get; set; }
    public string? ImAddress { get; set; }
    public bool? IsFavorite { get; set; }
    public string? JobTitle { get; set; }
    public string? OfficeLocation { get; set; }
    public string? PersonNotes { get; set; }
    public PersonType? PersonType { get; set; }
    public Phone[]? Phones { get; set; }
    public Location[]? PostalAddresses { get; set; }
    public string? Profession { get; set; }
    public ScoredEmailAddress[]? ScoredEmailAddresses { get; set; }
    public string? Surname { get; set; }
    public string? UserPrincipalName { get; set; }
    public Website[]? Websites { get; set; }
    public string? YomiCompany { get; set; }
}
