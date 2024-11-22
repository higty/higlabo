using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/orgcontact?view=graph-rest-1.0
/// </summary>
public partial class OrgContact
{
    public PhysicalOfficeAddress[]? Addresses { get; set; }
    public string? CompanyName { get; set; }
    public string? Department { get; set; }
    public string? DisplayName { get; set; }
    public string? GivenName { get; set; }
    public string? Id { get; set; }
    public string? JobTitle { get; set; }
    public string? Mail { get; set; }
    public string? MailNickname { get; set; }
    public DateTimeOffset? OnPremisesLastSyncDateTime { get; set; }
    public OnPremisesProvisioningError[]? OnPremisesProvisioningErrors { get; set; }
    public bool? OnPremisesSyncEnabled { get; set; }
    public Phone[]? Phones { get; set; }
    public String[]? ProxyAddresses { get; set; }
    public string? Surname { get; set; }
    public DirectoryObject[]? DirectReports { get; set; }
    public DirectoryObject? Manager { get; set; }
    public DirectoryObject[]? MemberOf { get; set; }
    public DirectoryObject[]? TransitiveMemberOf { get; set; }
}
